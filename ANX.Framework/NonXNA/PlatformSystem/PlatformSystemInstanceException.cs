﻿#region Using Statements
using System;

#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.NonXNA.PlatformSystem
{
    public class PlatformSystemInstanceException : Exception
    {
        public PlatformSystemInstanceException()
            : base()
        {
        }

        public PlatformSystemInstanceException(string message)
            : base(message)
        {
        }
    }
}
