﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content.Pipeline
{
    public sealed class OpaqueDataDictionary : NamedValueDictionary<Object>
    {
        public OpaqueDataDictionary()
        {
            throw new NotImplementedException();
        }

        public string GetContentAsXml()
        {
            throw new NotImplementedException();
        }

        public T GetValue<T>(string key, T defaultValue)
        {
            throw new NotImplementedException();
        }


    }
}