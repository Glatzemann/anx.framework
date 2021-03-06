#region Using Statements
using System;
using System.Collections.Generic;
using System.IO;
using ANX.Framework;
using ANX.Framework.Graphics;
using ANX.Framework.NonXNA;
using ANX.Framework.NonXNA.RenderSystem;
using SharpDX.DXGI;
using ANX.Framework.NonXNA.Development;
using System.Collections.ObjectModel;

#endregion

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.RenderSystem.Windows.DX11
{
    [Developer("Glatzemann")]
	public class Creator : IRenderSystemCreator
	{
		#region Public
		public string Name
		{
			get { return "DirectX11"; }
		}

		public int Priority
		{
			get { return 15; }
		}

		public bool IsSupported
		{
			get
			{
                //Default to false
                bool isSupported = false;
                //Vista SP2 build number is 6002
                Version vistaSP2Version = new Version(6, 0, 002);
                Version sevenVersion = new Version(6, 1);

                //DirectX 11 is available on Vista SP2 and later
                if (OSInformation.IsWindows && Environment.OSVersion.Version.CompareTo(vistaSP2Version) > 0)
                {
                    //KB971512 installed on Vista SP2 adds library C:\Windows\System32\d3d11.dll.
                    //This file also exits on Windows 7.
                    isSupported = (Environment.OSVersion.Version.CompareTo(sevenVersion) > 0 || 
                                    File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "System32", "d3d11.dll")));
                }

                return isSupported;
			}
		}

		public EffectSourceLanguage GetStockShaderSourceLanguage
		{
			get
			{
				return EffectSourceLanguage.HLSL_FX;
			}
		}
		#endregion

		#region CreateGraphicsDevice
		public INativeGraphicsDevice CreateGraphicsDevice(PresentationParameters presentationParameters)
		{
			PreventSystemChange();
			return new GraphicsDeviceDX(presentationParameters);
		}
		#endregion

		#region CreateIndexBuffer
		public INativeIndexBuffer CreateIndexBuffer(GraphicsDevice graphics, IndexBuffer managedBuffer, IndexElementSize size,
			int indexCount, BufferUsage usage)
		{
			PreventSystemChange();
			return new DxIndexBuffer((GraphicsDeviceDX)graphics.NativeDevice, size, indexCount, usage, false);
		}

        public INativeIndexBuffer CreateDynamicIndexBuffer(GraphicsDevice graphics, IndexBuffer managedBuffer, IndexElementSize size, int indexCount, BufferUsage usage)
        {
            PreventSystemChange();
            return new DxIndexBuffer((GraphicsDeviceDX)graphics.NativeDevice, size, indexCount, usage, true);
        }
		#endregion

		#region CreateVertexBuffer
		public INativeVertexBuffer CreateVertexBuffer(GraphicsDevice graphics, VertexBuffer managedBuffer,
			VertexDeclaration vertexDeclaration, int vertexCount, BufferUsage usage)
		{
			PreventSystemChange();
            return new DxVertexBuffer((GraphicsDeviceDX)graphics.NativeDevice, vertexDeclaration, vertexCount, usage, false);
		}

        public INativeVertexBuffer CreateDynamicVertexBuffer(GraphicsDevice graphics, DynamicVertexBuffer managedBuffer, VertexDeclaration vertexDeclaration, int vertexCount, BufferUsage usage)
        {
            PreventSystemChange();
            return new DxVertexBuffer((GraphicsDeviceDX)graphics.NativeDevice, vertexDeclaration, vertexCount, usage, true);
        }
		#endregion

#if XNAEXT
        #region CreateConstantBuffer
        public INativeConstantBuffer CreateConstantBuffer(GraphicsDevice graphics, ConstantBuffer managedBuffer, 
			BufferUsage usage)
		{
			PreventSystemChange();

            throw new NotImplementedException();
        }
        #endregion
#endif

		#region CreateEffect
		public INativeEffect CreateEffect(GraphicsDevice graphics, Effect managedEffect, Stream vertexShaderByteCode,
			Stream pixelShaderByteCode)
		{
			PreventSystemChange();
			return new EffectDX(graphics, managedEffect, vertexShaderByteCode, pixelShaderByteCode);
		}

		public INativeEffect CreateEffect(GraphicsDevice graphics, Effect managedEffect, Stream byteCode)
		{
			PreventSystemChange();
			return new EffectDX(graphics, managedEffect, byteCode);
		}
		#endregion

		#region CreateBlendState
		public INativeBlendState CreateBlendState()
		{
			PreventSystemChange();
			return new BlendState_DX11();
		}
		#endregion

		#region CreateRasterizerState
		public INativeRasterizerState CreateRasterizerState()
		{
			PreventSystemChange();
			return new RasterizerState_DX11();
		}
		#endregion

		#region CreateDepthStencilState
		public INativeDepthStencilState CreateDepthStencilState()
		{
			PreventSystemChange();
			return new DepthStencilState_DX11();
		}
		#endregion

		#region CreateSamplerState
		public INativeSamplerState CreateSamplerState()
		{
			PreventSystemChange();
			return new SamplerState_DX11();
		}
		#endregion

		#region GetShaderByteCode
		public byte[] GetShaderByteCode(PreDefinedShader type)
		{
			PreventSystemChange();

			switch (type)
			{
				case PreDefinedShader.SpriteBatch:
					return ShaderByteCode.SpriteBatchByteCode;
				case PreDefinedShader.DualTextureEffect:
					return ShaderByteCode.DualTextureEffectByteCode;
				case PreDefinedShader.AlphaTestEffect:
					return ShaderByteCode.AlphaTestEffectByteCode;
				case PreDefinedShader.EnvironmentMapEffect:
					return ShaderByteCode.EnvironmentMapEffectByteCode;
				case PreDefinedShader.BasicEffect:
					return ShaderByteCode.BasicEffectByteCode;
				case PreDefinedShader.SkinnedEffect:
					return ShaderByteCode.SkinnedEffectByteCode;
			}

			throw new NotImplementedException("ByteCode for built-in effect '" + type + "' is not yet available.");
		}
		#endregion

		#region GetAdapterList
		public ReadOnlyCollection<INativeGraphicsAdapter> GetAdapterList()
		{
            PreventSystemChange();

            var adapterList = new List<INativeGraphicsAdapter>();
            bool firstOutput = true;

            using (Factory factory = new Factory())
            {
                foreach (Adapter adapter in factory.Adapters)
                {
                    foreach (Output output in adapter.Outputs)
                    {
                        //By definition, the first returned output is always the default adapter.
                        adapterList.Add(new DirectXGraphicsAdapter(adapter, output, firstOutput));
                        firstOutput = false;
                    }
                }
            }

            return new ReadOnlyCollection<INativeGraphicsAdapter>(adapterList);
		}
		#endregion

		#region CreateTexture
		public INativeTexture2D CreateTexture(GraphicsDevice graphics, SurfaceFormat surfaceFormat, int width, int height,
			int mipCount)
		{
			PreventSystemChange();
            return new DxTexture2D((GraphicsDeviceDX)graphics.NativeDevice, width, height, surfaceFormat, mipCount);
		}
		#endregion

		#region CreateRenderTarget
		public INativeRenderTarget2D CreateRenderTarget(GraphicsDevice graphics, int width, int height, bool mipMap,
			SurfaceFormat preferredFormat, DepthFormat preferredDepthFormat, int preferredMultiSampleCount,
			RenderTargetUsage usage)
		{
			PreventSystemChange();
			return new RenderTarget2D_DX11((GraphicsDeviceDX)graphics.NativeDevice, width, height, mipMap, preferredFormat, preferredDepthFormat,
				preferredMultiSampleCount, usage);
		}
		#endregion

		#region IsLanguageSupported
		public bool IsLanguageSupported(EffectSourceLanguage sourceLanguage)
        {
            return sourceLanguage == EffectSourceLanguage.HLSL_FX || sourceLanguage == EffectSourceLanguage.HLSL;
        }
		#endregion

		#region CreateOcclusionQuery (TODO)
		public IOcclusionQuery CreateOcclusionQuery()
		{
			PreventSystemChange();
			throw new NotImplementedException();
		}
		#endregion

		#region SetTextureSampler (TODO)
		public void SetTextureSampler(int index, Texture value)
		{
			PreventSystemChange();
			throw new NotImplementedException();
		}
		#endregion

		#region PreventSystemChange
		private void PreventSystemChange()
		{
			AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);
		}
		#endregion
    }
}
