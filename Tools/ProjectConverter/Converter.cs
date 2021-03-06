﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using ProjectConverter.Platforms;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ProjectConverter
{
	public abstract class Converter
	{
		protected const string XnaGameStudioTarget = "Microsoft.Xna.GameStudio.targets";
		protected const string XnaPipelineExtensionTarget =
			"Microsoft.Xna.GameStudio.ContentPipelineExtensions.targets";

		protected ProjectPath CurrentProject { get; private set; }

        /// <summary>
        /// The Postfix is used as a extension for a project file name
        /// </summary>
		public abstract string Postfix { get; }

        /// <summary>
        /// The Name is used to identify the converter
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// When set to false the source project file will not be written to disk after conversion
        /// </summary>
        public virtual bool WriteSourceProjectToDestination
        {
            get { return true; }
        }

        /// <summary>
        /// Nex extension to use for the target file
        /// </summary>
        public virtual string TargetFileExtension
        {
            get { return string.Empty; }
        }

        public virtual string ProjectFileTemplate 
        {
            get
            {
                return string.Empty;
            }
        }

		#region ConvertAllProjects
		public void ConvertAllProjects(string solutionFilepath, string destinationPath)
		{
			ProjectPath[] allProjects = CollectAllProjects(solutionFilepath, destinationPath);

			for (int index = 0; index < allProjects.Length; index++)
			{
				ConvertProject(allProjects[index]);
			}

			CreateTargetSolution(solutionFilepath, allProjects);
		}
		#endregion

        #region ConvertAnxContentProject
        public void ConvertAnxContentProject(string projectFilePath, string destinationPath)
        {
            ProjectPath projectPath = new ProjectPath(this, projectFilePath, ".", destinationPath, TargetFileExtension, ProjectFileTemplate);
            ConvertProject(projectPath);
        }

        #endregion

        #region ConvertProject
        public void ConvertProject(string projectFilePath, string destinationPath)
        {
            ProjectPath projectPath = new ProjectPath(this, projectFilePath, ".", destinationPath, TargetFileExtension);
            ConvertProject(projectPath);
        }

		public void ConvertProject(ProjectPath project)
		{
			CurrentProject = project;

            PreConvert();

			string namespaceName = project.Root.Name.NamespaceName;
			XName importName = XName.Get("Import", namespaceName);
			XName rootNamespaceName = XName.Get("RootNamespace", namespaceName);
			XName propertyGroupName = XName.Get("PropertyGroup", namespaceName);
			XName itemGroupName = XName.Get("ItemGroup", namespaceName);

			XName definesName = XName.Get("DefineConstants", namespaceName);
			XName referenceName = XName.Get("Reference", namespaceName);
			XName projectReferenceName = XName.Get("ProjectReference", namespaceName);
            XName outputPathName = XName.Get("OutputPath", namespaceName);

			var groups = project.Root.Elements().ToList();
            
            ConvertProject(project.Root);
			
            foreach (var group in groups)
			{
				if (group.Name == propertyGroupName)
				{
					XElement definesNode = group.Element(definesName);
					if (definesNode != null)
					{
						definesNode.Value =
							DefinesConverter.ConvertDefines(definesNode.Value, Postfix);
					}

                    XElement outputPathNode = group.Element(outputPathName);
                    if (outputPathNode != null)
                    {
                        outputPathNode.Value = ConvertOutputPath(outputPathNode.Value);
                    }

					if (group.Element(rootNamespaceName) != null)
					{
						ConvertMainPropertyGroup(group);
					}
					else
					{
						ConvertPropertyGroup(group);
					}
				}
                else if (group.Name == importName)
                {
                    XAttribute projectAttribute = group.Attribute("Project");
                    ConvertImport(group, projectAttribute);
                }
                else if (group.Name == itemGroupName)
                {
                    var allReferences = group.Elements(referenceName).ToList();
                    foreach (var reference in allReferences)
                        ConvertReference(reference);

                    var allProjectReferences = group.Elements(projectReferenceName).ToList();
                    foreach (var projectReference in allProjectReferences)
                    {
                        FixProjectReferencePath(projectReference);
                        ConvertProjectReference(projectReference);
                    }

                    ConvertItemGroup(group);
                }
			}

			PostConvert();

            if (WriteSourceProjectToDestination)
			    project.Save();
		}
		#endregion

		#region ConvertMainPropertyGroup
		protected virtual void ConvertMainPropertyGroup(XElement element)
		{
		}
		#endregion

		#region ConvertPropertyGroup
		protected virtual void ConvertPropertyGroup(XElement element)
		{
		}
		#endregion

		#region ConvertItemGroup
		protected virtual void ConvertItemGroup(XElement element)
		{
		}
		#endregion

		#region ConvertProjectReference
		protected virtual void ConvertProjectReference(XElement element)
		{
		}
		#endregion

		#region ConvertReference
		protected virtual void ConvertReference(XElement element)
		{
		}
		#endregion

        #region ConvertProject
        protected virtual void ConvertProject(XElement element)
        {
        }
        #endregion

        #region ConvertImport
        protected virtual void ConvertImport(XElement element, XAttribute projectAttribute)
		{
		}
		#endregion

        #region ConvertOutputPath
        protected virtual string ConvertOutputPath(string path)
        {
            return path;
        }
        #endregion

        #region PreConvert
        protected virtual void PreConvert()
        {
        }
        #endregion

        #region PostConvert
        protected virtual void PostConvert()
		{
		}
		#endregion

        #region DeleteNodeIfExists
        protected void DeleteNodeIfExists(XElement group, string nodeName)
		{
			XName name = XName.Get(nodeName, group.Name.NamespaceName);
			XElement element = group.Element(name);
			if (element != null)
			{
				element.Remove();
			}
		}
		#endregion

		#region GetXName
		protected XName GetXName(string nodeName)
		{
			return XName.Get(nodeName, CurrentProject.Document.Root.Name.NamespaceName);
		}
		#endregion

		#region GetOrCreateNode
		protected XElement GetOrCreateNode(XElement group, string nodeName)
		{
			XName name = XName.Get(nodeName, group.Name.NamespaceName);
			XElement element = group.Element(name);
			if (element == null)
			{
				element = new XElement(name);
				group.Add(element);
			}
			return element;
		}
		#endregion

		#region ChangeOrCreateNodeValue
		protected void ChangeOrCreateNodeValue(XElement group,
			string nodeName, string value)
		{
			GetOrCreateNode(group, nodeName).Value = value;
		}
		#endregion

		#region FixProjectReferencePath
		private void FixProjectReferencePath(XElement projectReference)
		{
			XAttribute includeAttribute = projectReference.Attribute("Include");
			if (includeAttribute != null)
			{
				string referencePath = includeAttribute.Value;
				if (referencePath.EndsWith(".csproj"))
				{
                    if (!string.IsNullOrEmpty(Postfix))
                    {
                        referencePath = referencePath.Replace(".csproj", "_" + Postfix + ".csproj");
                    }

					string basePath = Path.GetDirectoryName(CurrentProject.FullSourcePath);
					string fullReferencePath = Path.Combine(basePath, referencePath);
					if (File.Exists(fullReferencePath))
					{
						includeAttribute.Value = referencePath;
					}
				}
			}
		}
		#endregion

		#region CollectAllProjects
		private ProjectPath[] CollectAllProjects(string solutionFilepath, string destinationPath)
		{
			var solution = VsSolution.Load(solutionFilepath);
			var result = new List<ProjectPath>();

			string basePath = Path.GetDirectoryName(solutionFilepath);

			foreach (var project in solution.Projects)
				if (project.IsCsProject && project.RelativePath.Contains("Tools") == false)
					result.Add(new ProjectPath(this, project.RelativePath, basePath, destinationPath, string.Empty));

			return result.ToArray();
		}
		#endregion

		#region CreateTargetSolution
		private void CreateTargetSolution(string solutionFilepath,
			ProjectPath[] allProjects)
		{
			string[] allLines = File.ReadAllLines(solutionFilepath);
			for (int index = 0; index < allLines.Length; index++)
			{
				foreach (var project in allProjects)
				{
					string replaceText = "\"" + project.RelativeSourcePath + "\"";
					if (allLines[index].Contains(replaceText))
					{
						allLines[index] = allLines[index].Replace(replaceText,
							"\"" + project.RelativeDestinationPath + "\"");
					}
				}
			}

			string targetSolutionPath =
				solutionFilepath.Substring(0, solutionFilepath.Length - ".sln".Length);
			targetSolutionPath += "_" + Postfix + ".sln";

			File.WriteAllLines(targetSolutionPath, allLines);
		}
		#endregion

		private class ConverterTests
		{
			#region TestCollectAllProjects
			[Test]
			public static void TestCollectAllProjects()
			{
				const string filepath = @"D:\code\csharp\ANX.Framework\ANX.Framework.sln";
				var converter = new MetroConverter();
				ProjectPath[] result = converter.CollectAllProjects(filepath, string.Empty);
				
				Assert.Greater(result.Length, 0);
			}
			#endregion

			#region TestConvertSolutionMetro
			[Test]
			public static void TestConvertSolutionMetro()
			{
				const string filepath = @"D:\code\csharp\ANX.Framework\ANX.Framework.sln";
				var converter = new MetroConverter();
				converter.ConvertAllProjects(filepath, string.Empty);
			}
			#endregion

			#region TestConvertSolutionPsVita
			[Test]
			public static void TestConvertSolutionPsVita()
			{
				const string filepath = @"D:\code\csharp\ANX.Framework\ANX.Framework.sln";
				var converter = new PsVitaConverter();
				converter.ConvertAllProjects(filepath, string.Empty);
			}
			#endregion

			#region TestConvertSolutionLinux
			[Test]
			public static void TestConvertSolutionLinux()
			{
				const string filepath = @"D:\code\csharp\ANX.Framework\ANX.Framework.sln";
				var converter = new LinuxConverter();
				converter.ConvertAllProjects(filepath, string.Empty);
			}
			#endregion
		}
	}
}
