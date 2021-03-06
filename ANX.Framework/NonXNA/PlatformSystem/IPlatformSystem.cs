using System.Collections.Generic;
using System.IO;
using ANX.Framework.Media;
using ANX.Framework.Storage;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.NonXNA.PlatformSystem
{
	public interface IPlatformSystem
	{
		GameHost CreateGameHost(Game game);
		INativeStorageDevice CreateStorageDevice(StorageDevice device, PlayerIndex player, int sizeInBytes, int directoryCount);
		INativeStorageContainer CreateStorageContainer(StorageContainer container);
		INativeTitleContainer CreateTitleContainer();
		INativeGameTimer CreateGameTimer();
		INativeContentManager CreateContentManager();

		Stream OpenReadFilestream(string filepath);

		INativeMediaLibrary CreateMediaLibrary();
		IList<MediaSource> GetAvailableMediaSources();
	}
}
