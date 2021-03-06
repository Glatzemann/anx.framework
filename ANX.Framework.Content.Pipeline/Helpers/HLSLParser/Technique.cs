﻿using System;
using System.Collections.Generic;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content.Pipeline.Helpers.HLSLParser
{
	public class Technique : IShaderElement
	{
		#region Public
		public string Name
		{
			get;
			private set;
		}

		public List<Pass> Passes
		{
			get;
			private set;
		}
		#endregion

		#region Constructor
		public Technique(ParseTextWalker walker)
		{
			Passes = new List<Pass>();

			string text = walker.Text;

			int indexOfNameStart = text.IndexOf(' ') + 1;
			int indexOfNameEnd = text.IndexOf('{');

			Name = text.Substring(indexOfNameStart, indexOfNameEnd - indexOfNameStart);
			Name = Name.TrimEnd('\n', '\r', '\t', ' ');

			walker.Seek(indexOfNameEnd + 1);

			Pass newPass = null;
			while ((newPass = Pass.TryParse(walker)) != null)
			{
				Passes.Add(newPass);
			}

			walker.Seek(walker.Text.IndexOf('}') + 1);
		}
		#endregion

		#region TryParse
		public static Technique TryParse(ParseTextWalker walker)
		{
			if (walker.Text.StartsWith("technique"))
			{
				return new Technique(walker);
			}

			return null;
		}
		#endregion

		#region ToString
		public override string ToString()
		{
			string text = "technique10 " + Name + "\n{";
			
			foreach (Pass pass in Passes)
			{
				text += "\n" + pass.ToStringIndented(1);
			}

			return text + "\n}";
		}
		#endregion
	}
}
