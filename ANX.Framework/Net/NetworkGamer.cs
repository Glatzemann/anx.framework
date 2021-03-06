using System;
using ANX.Framework.GamerServices;
using ANX.Framework.NonXNA.Development;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Net
{
    [PercentageComplete(0)]
    [Developer("Glatzemann")]
    [TestState(TestStateAttribute.TestState.Untested)]
	public class NetworkGamer : Gamer
	{
		public bool IsHost
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsLocal
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsPrivateSlot
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool HasVoice
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsTalking
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsMutedByLocalUser
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsGuest
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool HasLeftSession
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public byte Id
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public TimeSpan RoundtripTime
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public NetworkSession Session
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public NetworkMachine Machine
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool IsReady
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
