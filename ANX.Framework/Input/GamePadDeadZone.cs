using ANX.Framework.NonXNA.Development;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Input
{
    [PercentageComplete(100)]
    [TestState(TestStateAttribute.TestState.Tested)]
    public enum GamePadDeadZone : byte
    {
        None,
        IndependentAxes,
        Circular
    }
}
