#region Using Statements
using System;
using ANX.Framework.NonXNA.Development;

#endregion // Using Statements

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.GamerServices
{
    [PercentageComplete(10)]
    [Developer("Glatzemann")]
    [TestState(TestStateAttribute.TestState.Untested)]
    public sealed class FriendCollection : GamerCollection<FriendGamer>, IDisposable
	{
		public bool IsDisposed
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		~FriendCollection()
		{
			Dispose();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
