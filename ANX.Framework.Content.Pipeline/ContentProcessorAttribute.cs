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
    [AttributeUsage(AttributeTargets.Class)]
    [Serializable]
    public class ContentProcessorAttribute : Attribute
    {
        public ContentProcessorAttribute()
        {
        }

        public virtual string DisplayName
        {
            get;
            set;
        }
    }
}
