#region Using Statements
using System;
using System.Collections.Generic;
using ANX.Framework.Graphics;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.NonXNA
{
    public interface INativeEffectPass : IDisposable
    {
        string Name { get; }

        EffectAnnotationCollection Annotations { get; }

        void Apply();
    }
}
