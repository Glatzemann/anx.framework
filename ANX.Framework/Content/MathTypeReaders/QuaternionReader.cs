﻿#region Using Statements
using ANX.Framework.NonXNA.Development;
#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Content
{
    [PercentageComplete(100)]
    [Developer("GinieDP")]
    [TestState(TestStateAttribute.TestState.Untested)]
    internal class QuaternionReader : ContentTypeReader<Quaternion>
    {
        protected internal override Quaternion Read(ContentReader input, Quaternion existingInstance)
        {
            return new Quaternion(input.ReadSingle(), input.ReadSingle(), input.ReadSingle(), input.ReadSingle());
        }
    }
}
