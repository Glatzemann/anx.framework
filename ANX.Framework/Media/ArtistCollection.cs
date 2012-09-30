using System;
using System.Collections;
using System.Collections.Generic;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Media
{
	public sealed class ArtistCollection : IEnumerable<Artist>, IEnumerable, IDisposable
	{
		private readonly List<Artist> artists;

	    public bool IsDisposed { get; private set; }

	    public int Count
	    {
	        get { return artists.Count; }
	    }

	    public Artist this[int index]
	    {
	        get { return artists[index]; }
	    }

	    internal ArtistCollection()
		{
			artists = new List<Artist>();
			IsDisposed = false;
		}

		~ArtistCollection()
		{
			Dispose();
		}

		#region GetEnumerator
		public IEnumerator<Artist> GetEnumerator()
		{
			return artists.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return artists.GetEnumerator();
		}
		#endregion

		#region Dispose
		public void Dispose()
		{
			IsDisposed = true;
			artists.Clear();
		}
		#endregion
	}
}
