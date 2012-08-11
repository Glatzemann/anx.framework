﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.NonXNA.Reflection
{
	/// <summary>
	/// The AssemblyListFile is a data holder of all available assembly names.
	/// This is necessary cause on some platforms we can't get all the *.dll files
	/// in the current directory. So we simply load this file from the
	/// content/assets/etc. and call Assembly.Load with the names.
	/// </summary>
	internal class AssemblyListFile
	{
		#region Constants
		private const string Filename = "AssemblyList.bin";
		#endregion

		#region Private
		private List<string> allAssemblyNames;
		private Stream assemblyListStream;
		#endregion

		#region Constructor
		public AssemblyListFile()
		{
			allAssemblyNames = new List<string>();
		}
		#endregion

		#region GetAllAssemblyNames
		public string[] GetAllAssemblyNames()
		{
			return allAssemblyNames.ToArray();
		}
		#endregion

		#region SetAllAssemblyNames
		public void SetAllAssemblyNames(Assembly[] assemblies)
		{
			allAssemblyNames.Clear();
			foreach (Assembly assembly in assemblies)
			{
				allAssemblyNames.Add(assembly.FullName);
			}
		}
		#endregion

		#region Load
		public void Load()
		{
#if WINDOWSMETRO
			LoadStreamFromMetroAssets();
#endif

			if (assemblyListStream != null)
			{
				LoadFromStream(assemblyListStream);
			}
		}
		#endregion

		#region LoadStreamFromMetroAssets
#if WINDOWSMETRO
		private async void LoadStreamFromMetroAssets()
		{
			var library = Windows.ApplicationModel.Package.Current.InstalledLocation;
			assemblyListStream = await library.OpenStreamForReadAsync("Assets\\" + Filename);
		}
#endif
		#endregion

		#region LoadFromStream
		private void LoadFromStream(Stream stream)
		{
			BinaryReader reader = new BinaryReader(stream);

			int numberOfAssemblyNames = reader.ReadInt32();
			for (int assemblyIndex = 0; assemblyIndex < numberOfAssemblyNames;
				assemblyIndex++)
			{
				allAssemblyNames.Add(reader.ReadString());
			}
		}
		#endregion

		#region Save
		public void Save(Stream stream)
		{
			BinaryWriter writer = new BinaryWriter(stream);

			writer.Write(allAssemblyNames.Count);
			foreach (string assemblyName in allAssemblyNames)
			{
				writer.Write(assemblyName);
			}
		}
		#endregion
	}
}