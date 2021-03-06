using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using ANX.Framework;
using ANX.Framework.Graphics;
using ANX.Framework.NonXNA;
using ANX.Framework.NonXNA.Development;
using ANX.Framework.NonXNA.RenderSystem;
using ANX.Framework.GL3;
using OpenTK;
using OpenTK.Graphics.OpenGL;

// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

namespace ANX.RenderSystem.GL3
{
	[PercentageComplete(90)]
	[TestState(TestStateAttribute.TestState.Untested)]
	[Developer("AstrorEnales")]
	public class Creator : IRenderSystemCreator
	{
		#region Public
		public string Name
		{
			get
			{
				return "OpenGL3";
			}
		}

		public int Priority
		{
			get
			{
				return 100;
			}
		}

		public bool IsSupported
		{
			get
			{
				//TODO: this is just a very basic version of test for support
				PlatformName os = OSInformation.GetName();
				return OSInformation.IsWindows ||
					os == PlatformName.Linux ||
					os == PlatformName.MacOSX;
			}
		}

		public EffectSourceLanguage GetStockShaderSourceLanguage
		{
			get
			{
				return EffectSourceLanguage.GLSL_FX;
			}
		}
		#endregion

		#region CreateEffect
		public INativeEffect CreateEffect(GraphicsDevice graphics, Effect managedEffect,
			Stream byteCode)
		{
			AddInSystemFactory.Instance.PreventSystemChange(
				AddInType.RenderSystem);

			return new EffectGL3(managedEffect, byteCode);
		}

		public INativeEffect CreateEffect(GraphicsDevice graphics, Effect managedEffect,
			Stream vertexShaderByteCode, Stream pixelShaderByteCode)
		{
			AddInSystemFactory.Instance.PreventSystemChange(
				AddInType.RenderSystem);

			return new EffectGL3(managedEffect, vertexShaderByteCode, pixelShaderByteCode);
		}
		#endregion

		#region CreateGraphicsDevice
		INativeGraphicsDevice IRenderSystemCreator.CreateGraphicsDevice(PresentationParameters presentationParameters)
		{
			AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);
			return new GraphicsDeviceWindowsGL3(presentationParameters);
		}
		#endregion

		#region CreateTexture
		/// <summary>
		/// Create a new native texture.
		/// </summary>
		/// <param name="graphics">Graphics device.</param>
		/// <param name="surfaceFormat">The format of the texture.</param>
		/// <param name="width">The width of the texture.</param>
		/// <param name="height">The height of the texture.</param>
		/// <param name="mipCount">The number of mipmaps in the texture.</param>
		/// <returns></returns>
		public INativeTexture2D CreateTexture(GraphicsDevice graphics,
			SurfaceFormat surfaceFormat, int width, int height, int mipCount)
		{
			AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);
			return new Texture2DGL3(surfaceFormat, width, height, mipCount);
		}
		#endregion

		#region CreateIndexBuffer
		/// <summary>
		/// Create a native index buffer.
		/// </summary>
		/// <param name="graphics">The current graphics device.</param>
		/// <param name="size">The size of a single index element.</param>
		/// <param name="indexCount">The number of indices stored in the buffer.
		/// </param>
		/// <param name="usage">The usage type of the buffer.</param>
		/// <returns>Native OpenGL index buffer.</returns>
		public INativeIndexBuffer CreateIndexBuffer(GraphicsDevice graphics,
			IndexBuffer managedBuffer, IndexElementSize size, int indexCount,
			BufferUsage usage)
		{
			AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);
			return new IndexBufferGL3(managedBuffer, size, indexCount, usage);
		}

        public INativeIndexBuffer CreateDynamicIndexBuffer(GraphicsDevice graphics, IndexBuffer managedBuffer, IndexElementSize size, int indexCount, BufferUsage usage)
        {
            AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);
            return new IndexBufferGL3(managedBuffer, size, indexCount, usage);
        }
		#endregion

		#region CreateVertexBuffer
		/// <summary>
		/// Create a native vertex buffer.
		/// </summary>
		/// <param name="graphics">The current graphics device.</param>
		/// <param name="size">The vertex declaration for the buffer.</param>
		/// <param name="indexCount">The number of vertices stored in the buffer.
		/// </param>
		/// <param name="usage">The usage type of the buffer.</param>
		/// <returns>Native OpenGL vertex buffer.</returns>
		public INativeVertexBuffer CreateVertexBuffer(GraphicsDevice graphics,
			VertexBuffer managedBuffer, VertexDeclaration vertexDeclaration,
			int vertexCount, BufferUsage usage)
		{
			AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);
			return new VertexBufferGL3(managedBuffer, vertexDeclaration, vertexCount,
				usage);
		}

        public INativeVertexBuffer CreateDynamicVertexBuffer(GraphicsDevice graphics, DynamicVertexBuffer managedBuffer, VertexDeclaration vertexDeclaration, int vertexCount, BufferUsage usage)
        {
            AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);
            return new VertexBufferGL3(managedBuffer, vertexDeclaration, vertexCount,
                usage);
        }
		#endregion

#if XNAEXT
        #region CreateConstantBuffer (TODO)
        public INativeConstantBuffer CreateConstantBuffer(GraphicsDevice graphics, ConstantBuffer managedBuffer,
			BufferUsage usage)
        {
            AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);
            
            throw new NotImplementedException();
        }
        #endregion
#endif

		#region CreateBlendState
		/// <summary>
		/// Create a new native blend state.
		/// </summary>
		/// <returns>Native Blend State.</returns>
		public INativeBlendState CreateBlendState()
		{
			AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);
			return new BlendStateGL3();
		}
		#endregion

		#region CreateBlendState
		/// <summary>
		/// Create a new native rasterizer state.
		/// </summary>
		/// <returns>Native Rasterizer State.</returns>
		public INativeRasterizerState CreateRasterizerState()
		{
			AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);
			return new RasterizerStateGL3();
		}
		#endregion

		#region CreateDepthStencilState
		/// <summary>
		/// Create a new native Depth Stencil State.
		/// </summary>
		/// <returns>Native Depth Stencil State.</returns>
		public INativeDepthStencilState CreateDepthStencilState()
		{
			AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);
			return new DepthStencilStateGL3();
		}
		#endregion

		#region CreateSamplerState
		/// <summary>
		/// Create a new native sampler state.
		/// </summary>
		/// <returns>Native Sampler State.</returns>
		public INativeSamplerState CreateSamplerState()
		{
			AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);
			return new SamplerStateGL3();
		}
		#endregion

		#region GetShaderByteCode
		/// <summary>
		/// Get the byte code of a pre defined shader.
		/// </summary>
		/// <param name="type">Pre defined shader type.</param>
		/// <returns>Byte code of the shader.</returns>
		public byte[] GetShaderByteCode(PreDefinedShader type)
		{
			AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);

			if (type == PreDefinedShader.SpriteBatch)
			{
				return ShaderByteCode.SpriteBatchByteCode;
			}
			else if (type == PreDefinedShader.AlphaTestEffect)
			{
				return ShaderByteCode.AlphaTestEffectByteCode;
			}
			else if (type == PreDefinedShader.BasicEffect)
			{
				return ShaderByteCode.BasicEffectByteCode;
			}
			else if (type == PreDefinedShader.DualTextureEffect)
			{
				return ShaderByteCode.DualTextureEffectByteCode;
			}
			else if (type == PreDefinedShader.EnvironmentMapEffect)
			{
				return ShaderByteCode.EnvironmentMapEffectByteCode;
			}
			else if (type == PreDefinedShader.SkinnedEffect)
			{
				return ShaderByteCode.SkinnedEffectByteCode;
			}

			throw new NotImplementedException("ByteCode for '" + type.ToString() + "' is not yet available");
		}
		#endregion

		#region GetAdapterList (TODO)
		/// <summary>
		/// Get a list of available graphics adapter information.
		/// </summary>
		/// <returns>List of graphics adapters.</returns>
		public ReadOnlyCollection<INativeGraphicsAdapter> GetAdapterList()
		{
            AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);
            
            var result = new List<INativeGraphicsAdapter>();
            foreach (DisplayDevice device in DisplayDevice.AvailableDisplays)
            {
                var resultingModes = new List<DisplayMode>();
                foreach (string format in Enum.GetNames(typeof(SurfaceFormat)))
                {
                    SurfaceFormat surfaceFormat = (SurfaceFormat)Enum.Parse(typeof(SurfaceFormat), format);

                    // TODO: device.BitsPerPixel
                    if (surfaceFormat != SurfaceFormat.Color)//adapter.Supports(surfaceFormat) == false)
                    {
                        continue;
                    }
                }

                var newAdapter = new GraphicsAdapterGL3(device, SurfaceFormat.Color);

                result.Add(newAdapter);
            }

            return new ReadOnlyCollection<INativeGraphicsAdapter>(result);
		}
		#endregion

		#region CreateRenderTarget
		public INativeRenderTarget2D CreateRenderTarget(GraphicsDevice graphics,
			int width, int height, bool mipMap, SurfaceFormat preferredFormat,
			DepthFormat preferredDepthFormat, int preferredMultiSampleCount,
			RenderTargetUsage usage)
		{
			AddInSystemFactory.Instance.PreventSystemChange(AddInType.RenderSystem);
			return new RenderTarget2DGL3(width, height, mipMap, preferredFormat,
				preferredDepthFormat, preferredMultiSampleCount, usage);
		}
		#endregion

		#region IsLanguageSupported
		public bool IsLanguageSupported(EffectSourceLanguage sourceLanguage)
        {
            return sourceLanguage == EffectSourceLanguage.GLSL_FX || sourceLanguage == EffectSourceLanguage.GLSL;
		}
		#endregion

		#region CreateOcclusionQuery
		public IOcclusionQuery CreateOcclusionQuery()
		{
			return new OcclusionQueryGL3();
		}
		#endregion

		#region SetTextureSampler (TODO)
		public void SetTextureSampler(int index, Texture value)
		{
			TextureUnit textureUnit = TextureUnit.Texture0 + index;
			GL.ActiveTexture(textureUnit);
			int handle = (value.NativeTexture as Texture2DGL3).NativeHandle;
			GL.BindTexture(TextureTarget.Texture2D, handle);
			int unitIndex = (int)(textureUnit - TextureUnit.Texture0);
			//GL.Uniform1(UniformIndex, 1, ref unitIndex);
		}
		#endregion

    }
}
