using System;
using System.Runtime.InteropServices;
using ANX.Framework.NonXNA;
using ANX.Framework.NonXNA.Development;
using ANX.Framework.NonXNA.RenderSystem;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.Framework.Graphics
{
	[PercentageComplete(100)]
	[TestState(TestStateAttribute.TestState.Untested)]
    [Developer("Glatzemann")]
	public class VertexBuffer : GraphicsResource, IGraphicsResource
	{
		#region Public
		// This is now internal because via befriending the assemblies
		// it's usable in the modules but doesn't confuse the enduser.
        internal INativeVertexBuffer NativeVertexBuffer
        {
            get;
            set;
        }

		public BufferUsage BufferUsage { get; private set; }
		public int VertexCount { get; private set; }
		public VertexDeclaration VertexDeclaration { get; private set; }
		#endregion

		#region Constructor
		public VertexBuffer(GraphicsDevice graphicsDevice, Type vertexType, int vertexCount, BufferUsage usage)
			: this(graphicsDevice, VertexTypeHelper.GetDeclaration(vertexType), vertexCount, usage)
		{
		}

		public VertexBuffer(GraphicsDevice graphicsDevice, VertexDeclaration vertexDeclaration, int vertexCount, BufferUsage usage)
			: base(graphicsDevice)
		{
			VertexCount = vertexCount;
			VertexDeclaration = vertexDeclaration;
			BufferUsage = usage;

			base.GraphicsDevice.ResourceCreated += GraphicsDevice_ResourceCreated;
			base.GraphicsDevice.ResourceDestroyed += GraphicsDevice_ResourceDestroyed;

			CreateNativeBuffer();
		}
		#endregion

		#region GraphicsDevice_ResourceDestroyed
		private void GraphicsDevice_ResourceDestroyed(object sender, ResourceDestroyedEventArgs e)
		{
			if (NativeVertexBuffer != null)
			{
                NativeVertexBuffer.Dispose();
                NativeVertexBuffer = null;
			}
		}
		#endregion

		#region GraphicsDevice_ResourceCreated
		private void GraphicsDevice_ResourceCreated(object sender, ResourceCreatedEventArgs e)
		{
            if (NativeVertexBuffer != null)
			{
                NativeVertexBuffer.Dispose();
                NativeVertexBuffer = null;
			}

			CreateNativeBuffer();
		}
		#endregion

		#region CreateNativeBuffer
		internal virtual void CreateNativeBuffer()
		{
			var creator = AddInSystemFactory.Instance.GetDefaultCreator<IRenderSystemCreator>();
			this.NativeVertexBuffer = creator.CreateVertexBuffer(GraphicsDevice, this, VertexDeclaration, VertexCount, BufferUsage);
		}
		#endregion

		#region GetData
		public void GetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride) where T : struct
		{
			NativeVertexBuffer.GetData(offsetInBytes, data, startIndex, elementCount, vertexStride);
		}

		public void GetData<T>(T[] data) where T : struct
		{
            NativeVertexBuffer.GetData(data);
		}

		public void GetData<T>(T[] data, int startIndex, int elementCount) where T : struct
		{
			NativeVertexBuffer.GetData(data, startIndex, elementCount);
		}
		#endregion

		#region SetData
		public void SetData<T>(int offsetInBytes, T[] data, int startIndex, int elementCount, int vertexStride) where T : struct
		{
			NativeVertexBuffer.SetData(offsetInBytes, data, startIndex, elementCount, vertexStride);
		}

		public void SetData<T>(T[] data) where T : struct
		{
			NativeVertexBuffer.SetData(data);
		}

		public void SetData<T>(T[] data, int startIndex, int elementCount) where T : struct
		{
			NativeVertexBuffer.SetData(data, startIndex, elementCount);
		}
		#endregion

		protected override void Dispose(bool disposeManaged)
		{
			if (disposeManaged)
			{
                if (NativeVertexBuffer != null)
                {
                    NativeVertexBuffer.Dispose();
                    NativeVertexBuffer = null;
                }

                // do not dispose the VertexDeclaration here, because it's only a reference
                if (VertexDeclaration != null)
                    VertexDeclaration = null;

                base.GraphicsDevice.ResourceCreated -= GraphicsDevice_ResourceCreated;
                base.GraphicsDevice.ResourceDestroyed -= GraphicsDevice_ResourceDestroyed;
			}

            base.Dispose(disposeManaged);
		}
	}
}
