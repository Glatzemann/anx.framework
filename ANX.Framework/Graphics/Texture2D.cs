#region Using Statements
using System;
using System.IO;
using System.Runtime.InteropServices;
using ANX.Framework.NonXNA;
using ANX.Framework.NonXNA.Development;
using ANX.Framework.NonXNA.RenderSystem;

#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Graphics
{
    [PercentageComplete(70)]
    [Developer("Glatzemann")]
    [TestState(TestStateAttribute.TestState.Untested)]
    public class Texture2D : Texture, IGraphicsResource
    {
        #region Private
        internal float OneOverWidth;
        internal float OneOverHeight;

        private INativeTexture2D nativeTexture2D;
        private INativeTexture2D NativeTexture2D
        {
            get
            {
                if (nativeTexture2D == null)
                    CreateNativeTextureSurface();

                return nativeTexture2D;
            }
        }
        #endregion

        #region Public
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(0, 0, this.Width, this.Height);
            }
        }

        public int Width
        {
            get;
            protected set;
        }

        public int Height
        {
            get;
            protected set;
        }
        #endregion

        #region Constructor (TODO)
        internal Texture2D(GraphicsDevice graphicsDevice)
            : base(graphicsDevice)
        {
        }

        public Texture2D(GraphicsDevice graphicsDevice, int width, int height)
            : base(graphicsDevice)
        {
            this.Width = width;
            this.Height = height;
            OneOverWidth = 1f / width;
            OneOverHeight = 1f / height;

            base.LevelCount = 1;
            base.Format = SurfaceFormat.Color;

            CreateNativeTextureSurface();
        }

        public Texture2D(GraphicsDevice graphicsDevice, int width, int height, [MarshalAsAttribute(UnmanagedType.U1)] bool mipMap,
            SurfaceFormat format)
            : base(graphicsDevice)
        {
            this.Width = width;
            this.Height = height;
            OneOverWidth = 1f / width;
            OneOverHeight = 1f / height;

            // TODO: pass the mipmap parameter to the creation of the texture to let the graphics card generate mipmaps!
            base.LevelCount = 1;
            base.Format = format;

            CreateNativeTextureSurface();
        }

        internal Texture2D(GraphicsDevice graphicsDevice, int width, int height, int mipCount, SurfaceFormat format)
            : base(graphicsDevice)
        {
            this.Width = width;
            this.Height = height;
            OneOverWidth = 1f / width;
            OneOverHeight = 1f / height;

            base.LevelCount = mipCount;
            base.Format = format;

            CreateNativeTextureSurface();
        }
        #endregion

        #region FromStream (TODO)
        public static Texture2D FromStream(GraphicsDevice graphicsDevice, Stream stream)
        {
            throw new NotImplementedException();
        }

        public static Texture2D FromStream(GraphicsDevice graphicsDevice, Stream stream, int width, int height,
            [MarshalAsAttribute(UnmanagedType.U1)] bool zoom)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GetData
        public void GetData<T>(int level, Nullable<Rectangle> rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            NativeTexture2D.GetData(level, rect, data, startIndex, elementCount);
        }

        public void GetData<T>(T[] data) where T : struct
        {
            NativeTexture.GetData(data);
        }

        public void GetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            NativeTexture.GetData(data, startIndex, elementCount);
        }
        #endregion

        #region SetData
        public void SetData<T>(int level, Nullable<Rectangle> rect, T[] data, int startIndex, int elementCount) where T : struct
        {
            NativeTexture2D.SetData(level, rect, data, startIndex, elementCount);
        }

        public void SetData<T>(T[] data) where T : struct
        {
            NativeTexture.SetData(data);
        }

        public void SetData<T>(T[] data, int startIndex, int elementCount) where T : struct
        {
            NativeTexture.SetData<T>(data, startIndex, elementCount);
        }
        #endregion

        #region SaveAsJpeg
        public void SaveAsJpeg(Stream stream, int width, int height)
        {
            NativeTexture2D.SaveAsJpeg(stream, width, height);
        }
        #endregion

        #region SaveAsPng
        public void SaveAsPng(Stream stream, int width, int height)
        {
            NativeTexture2D.SaveAsPng(stream, width, height);
        }
        #endregion

        #region ReCreateNativeTextureSurface
        internal override void ReCreateNativeTextureSurface()
        {
            CreateNativeTextureSurface();
        }
        #endregion

        #region CreateNativeTextureSurface
        private void CreateNativeTextureSurface()
        {
            var creator = AddInSystemFactory.Instance.GetDefaultCreator<IRenderSystemCreator>();
            nativeTexture2D = creator.CreateTexture(GraphicsDevice, Format, Width, Height, LevelCount);
            base.nativeTexture = nativeTexture2D;
        }
        #endregion
    }
}
