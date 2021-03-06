﻿using System;
using System.Collections.Generic;
using StringPair = System.Collections.Generic.KeyValuePair<string, string>;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content.Pipeline.Helpers.HLSLParser
{
	public class Sampler : IShaderElement
	{
		#region Public
		public string Type
		{
			get;
			private set;
		}

		public string Name
		{
			get;
			private set;
		}

		public string Register
		{
			get;
			private set;
		}

		public List<StringPair> States
		{
			get;
			private set;
		}
		#endregion
		
		#region Constructor
		public Sampler(ParseTextWalker walker)
		{
			States = new List<StringPair>();

			ParseType(walker);
			ParseName(walker);
			ParseRegister(walker);
			ParseStates(walker);
		}
		#endregion

		#region ParseType
		private void ParseType(ParseTextWalker walker)
		{
			int indexOfTypeEndSpace = walker.Text.IndexOf(' ');
			Type = walker.Text.Substring(0, indexOfTypeEndSpace);
			walker.Seek(indexOfTypeEndSpace + 1);
		}
		#endregion

		#region ParseName
		private void ParseName(ParseTextWalker walker)
		{
			string text = walker.Text;
			Name = "";
			int nameParseIndex = 0;
			while (nameParseIndex < text.Length)
			{
				char currentChar = text[nameParseIndex];
				if (currentChar == ' ' ||
					currentChar == '{' ||
					currentChar == ':' ||
					currentChar == '=')
				{
					break;
				}

				Name += currentChar;
				nameParseIndex++;
			}

			Name = Name.Trim(' ', '\t', '\n', '\r');

			walker.Seek(nameParseIndex);
		}
		#endregion

		#region ParseRegister
		private void ParseRegister(ParseTextWalker walker)
		{
			string text = walker.Text;
			if (text.StartsWith(":"))
			{
				int lengthBeforeCut = text.Length; 
				text = text.Substring(1).TrimStart(' ', '\t');
				int cutLength = lengthBeforeCut - text.Length;

				Register = "";
				int registerParseIndex = 0;
				while (registerParseIndex < text.Length)
				{
					char currentChar = text[registerParseIndex];
					if (currentChar == ' ' ||
						currentChar == '{' ||
						currentChar == ';' ||
						currentChar == '=')
					{
						break;
					}

					Register += currentChar;
					registerParseIndex++;
				}

				Register = Register.Trim(' ', '\t', '\n', '\r');

				walker.Seek(registerParseIndex + cutLength);
			}
		}
		#endregion

		#region ParseStates
		private void ParseStates(ParseTextWalker walker)
		{
			string text = walker.Text;

			if (text[0] == ';')
				return;

			int indexOfOpenBrace = text.IndexOf('{');

			walker.Seek(indexOfOpenBrace + 1);

			text = walker.Text;

			int indexOfStatesEndBrace = text.IndexOf('}');
			string statesSubText = text.Substring(0, indexOfStatesEndBrace);
			statesSubText = statesSubText.Replace("\n", "");
			statesSubText = statesSubText.Replace("\r", "");
			statesSubText = statesSubText.Replace("\t", "");

			indexOfStatesEndBrace = text.IndexOf(';', indexOfStatesEndBrace);
			walker.Seek(indexOfStatesEndBrace + 1);

			string[] parts = statesSubText.Split(new char[] { '=', ';' },
				StringSplitOptions.RemoveEmptyEntries);
			for (int partIndex = 0; partIndex < parts.Length; partIndex += 2)
			{
				States.Add(new StringPair(parts[partIndex].Trim(), parts[partIndex + 1].Trim()));
			}
		}
		#endregion

		#region TryParse
		public static Sampler TryParse(ParseTextWalker walker)
		{
			if (walker.Text.StartsWith("sampler") ||
				walker.Text.StartsWith("SamplerComparisonState") ||
				walker.Text.StartsWith("SamplerState"))
			{
				return new Sampler(walker);
			}

			return null;
		}
		#endregion

		#region ToString
		public override string ToString()
		{
			string result = Type + " " + Name;

			if (String.IsNullOrEmpty(Register) == false)
			{
				result += " : " + Register;
			}
			else
			{
				result += "\n{";

				foreach (StringPair state in States)
				{
					result += "\n\t" + state.Key + " = " + state.Value + ";";
				}

				result += "\n}";
			}

			return result + ";";
		}
		#endregion
	}
}
