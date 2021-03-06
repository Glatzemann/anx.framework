﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using StringPair = System.Collections.Generic.KeyValuePair<string, string>;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content.Pipeline.Helpers.GL3
{
    public static class ShaderHelper
    {
        #region SaveShaderCode (for external)
        public static byte[] SaveShaderCode(string effectCode)
        {
            effectCode = CleanCode(effectCode);

            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            // First of all writer the shader code (which is already preceeded
            // by a length identifier, making it harder to manipulate the code)
            writer.Write(effectCode);

            // And now we additionally generate a sha hash so it nearly becomes
            // impossible to manipulate the shader.
            using (SHA512Managed sha = new SHA512Managed())
            {
                byte[] data = stream.ToArray();
                byte[] hash = sha.ComputeHash(data);
                // The hash is added to the end of the stream.
                writer.Write(hash);
                writer.Flush();
            }

            return stream.ToArray();
        }
        #endregion

        #region LoadShaderCode
        public static string LoadShaderCode(Stream stream)
        {
            BinaryReader reader = new BinaryReader(stream);
            // First load the source.
            string source = reader.ReadString();
            byte[] hash;
            // And now check if it was manipulated.
            using (SHA512Managed sha = new SHA512Managed())
            {
                int lengthRead = (int)stream.Position;
                stream.Position = 0;
                byte[] data = reader.ReadBytes(lengthRead);
                hash = sha.ComputeHash(data);
            }
            byte[] loadedHash = reader.ReadBytes(64);
            for (int index = 0; index < hash.Length; index++)
            {
                if (hash[index] != loadedHash[index])
                {
                    throw new InvalidDataException("Failed to load the shader " +
                        "because the data got manipulated!");
                }
            }

            return source;
        }
        #endregion

        #region CleanCode
        private static string CleanCode(string input)
        {
            // We wanna clean up the shader a little bit, so we remove
            // empty lines, spaces and tabs at beginning and end and also
            // remove comments.
            List<string> lines = new List<string>(input.Split('\n'));
            input = "";
            for (int index = lines.Count - 1; index >= 0; index--)
            {
                lines[index] = lines[index].Trim();
                if (String.IsNullOrEmpty(lines[index]) ||
                    lines[index].StartsWith("//"))
                {
                    lines.RemoveAt(index);
                    continue;
                }

                input = lines[index] + input;
            }

            #region Multiline comment removing
            input = input.Replace("/*/*", "/* /*");
            input = input.Replace("*/*/", "*/ */");

            int length = input.Length;
            int foundStartIndex = -1;
            int openCommentsCount = 0;
            for (int index = 0; index < length - 1; index++)
            {
                if (input[index] == '/' &&
                    input[index + 1] == '*')
                {
                    if (openCommentsCount == 0)
                    {
                        foundStartIndex = index;
                    }
                    openCommentsCount++;
                }

                if (input[index] == '*' &&
                    input[index + 1] == '/')
                {
                    openCommentsCount--;
                    if (openCommentsCount == 0)
                    {
                        int commentLength = index - foundStartIndex + 2;
                        length -= commentLength;
                        index = foundStartIndex - 1;
                        input = input.Remove(foundStartIndex, commentLength);
                        foundStartIndex = -1;
                    }
                }
            }

            if (openCommentsCount > 0)
            {
                throw new Exception("Unable to clean the shader code because it seems " +
                    "some multiline comments interfere with each other or with the code. " +
                    "Please make sure your shader code and comments are well formatted!");
            }
            #endregion

            // Now to some additional cleanup
            string[] minimizables =
			{
				" * ", " = ", " + ", " / ", " - ", ", ",
			};

            foreach (string mizable in minimizables)
            {
                input = input.Replace(mizable, mizable.Trim());
            }

            return input;
        }
        #endregion

        #region ParseShaderCode
        public static ShaderData ParseShaderCode(string source)
        {
            ShaderData result = new ShaderData();

            string[] partIdentifiers =
			{
				"vertexglobal",
				"vertexshaders",
				"fragmentglobal",
				"fragmentshaders",
				"techniques",
			};

            int index = 0;
            while (index < source.Length)
            {
                for (int partIdsIndex = 0; partIdsIndex < partIdentifiers.Length; partIdsIndex++)
                {
                    string partId = partIdentifiers[partIdsIndex];
                    bool isValid = true;
                    for (int partIndex = 0; partIndex < partId.Length; partIndex++)
                    {
                        if (source[index + partIndex] != partId[partIndex])
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        int startIndex = index + partId.Length;
                        startIndex = source.IndexOf('{', startIndex) + 1;
                        string area = ExtractArea(source, startIndex);
                        index = startIndex + area.Length - 1;
                        switch (partIdsIndex)
                        {
                            case 0:
                                result.VertexGlobalCode = area;
                                break;
                            case 2:
                                result.FragmentGlobalCode = area;
                                break;
                            case 1:
                                ExtractNamedAreas(area, "shader", 0, result);
                                break;
                            case 3:
                                ExtractNamedAreas(area, "shader", 1, result);
                                break;
                            case 4:
                                ExtractNamedAreas(area, "technique", 2, result);
                                break;
                        }
                    }
                }

                index++;
            }

            return result;
        }
        #endregion

        #region ExtractNamedAreas
        private static void ExtractNamedAreas(string areaSource, string identifier,
            int addToId, ShaderData result)
        {
            int index = 0;
            while (index < areaSource.Length)
            {
                bool isValid = true;
                for (int partIndex = 0; partIndex < identifier.Length; partIndex++)
                {
                    if (areaSource[index + partIndex] != identifier[partIndex])
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    int startIndex = index + identifier.Length;
                    startIndex = areaSource.IndexOf('"', startIndex) + 1;

                    string name = areaSource.Substring(startIndex,
                        areaSource.IndexOf('"', startIndex) - startIndex);

                    startIndex = areaSource.IndexOf('{', startIndex) + 1;
                    string area = ExtractArea(areaSource, startIndex);

                    switch (addToId)
                    {
                        case 0:
                            result.VertexShaderCodes.Add(name, area);
                            break;
                        case 1:
                            result.FragmentShaderCodes.Add(name, area);
                            break;
                        case 2:
                            int vertexIndex = area.IndexOf("vertex");
                            vertexIndex = area.IndexOf('"', vertexIndex) + 1;
                            string vertexName = area.Substring(vertexIndex,
                                area.IndexOf('"', vertexIndex) - vertexIndex);

                            int fragmentIndex = area.IndexOf("fragment");
                            fragmentIndex = area.IndexOf('"', fragmentIndex) + 1;
                            string fragmentName = area.Substring(fragmentIndex,
                                area.IndexOf('"', fragmentIndex) - fragmentIndex);
                            result.Techniques.Add(name, new StringPair(vertexName, fragmentName));
                            break;
                    }
                }

                index++;
            }
        }
        #endregion

        #region ExtractArea
        private static string ExtractArea(string source, int startIndex)
        {
            int endIndex = startIndex;
            int openBraceCount = 0;
            for (int index = startIndex; index < source.Length; index++)
            {
                if (source[index] == '{')
                {
                    openBraceCount++;
                }
                if (source[index] == '}')
                {
                    openBraceCount--;
                }
                if (openBraceCount == -1)
                {
                    endIndex = index;
                    break;
                }
            }
            return source.Substring(startIndex, endIndex - startIndex);
        }
        #endregion

        private class Tests
        {
            #region TestCleanCode
            public static void TestCleanCode()
            {
                string input = File.ReadAllText(@"..\..\shader\GL3\SpriteBatch_GLSL.fx");
                Console.WriteLine(CleanCode(input));
            }
            #endregion

            #region TestCleanCodeWithExtendedComments
            public static void TestCleanCodeWithExtendedComments()
            {
                string input =
@"// This is a simple comment.

/*Hello
im a multiline comment*/

/* Multiline on a single line */

/* And now the hardcore...a multiline comment
/*in a multiline comment/*in another one
*/*/
Wow...
*/
";
                Console.WriteLine(CleanCode(input));
            }
            #endregion

            #region TestParseShaderCode
            public static void TestParseShaderCode()
            {
                string input = CleanCode(File.ReadAllText(
                    @"..\..\shader\GL3\SpriteBatch_GLSL.fx"));

                ShaderData data = ParseShaderCode(input);

                Console.WriteLine("Vertex globals:");
                Console.WriteLine(data.VertexGlobalCode);
                Console.WriteLine("-------------------------");
                Console.WriteLine("Fragment globals:");
                Console.WriteLine(data.FragmentGlobalCode);
                Console.WriteLine("-------------------------");
                foreach (StringPair pair in data.VertexShaderCodes)
                {
                    Console.WriteLine("vertex shader: " + pair.Key);
                    Console.WriteLine(pair.Value);
                    Console.WriteLine("-------------------------");
                }
                foreach (StringPair pair in data.FragmentShaderCodes)
                {
                    Console.WriteLine("fragment shader: " + pair.Key);
                    Console.WriteLine(pair.Value);
                    Console.WriteLine("-------------------------");
                }
                foreach (KeyValuePair<string, StringPair> pair in data.Techniques)
                {
                    Console.WriteLine("technique: " + pair.Key);
                    Console.WriteLine("vertex shader: " + pair.Value.Key);
                    Console.WriteLine("fragment shader: " + pair.Value.Value);
                    Console.WriteLine("-------------------------");
                }
            }
            #endregion
        }
    }
}
