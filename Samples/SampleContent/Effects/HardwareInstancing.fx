// This file is part of the ANX.Framework created by the
// "ANX.Framework developer group" and released under the Ms-PL license.
// For details see: http://anxframework.codeplex.com/license

float4x4 World;
float4x4 View;
float4x4 Projection;

struct VertexShaderInput
{
    float4 Position : POSITION0;
    float4 Color : COLOR0;
};

struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
};

VertexShaderOutput HardwareInstancingVertexShader(VertexShaderInput input, float4x4 instanceTransform : BLENDWEIGHT)
{
    VertexShaderOutput output;

    // Apply the world and camera matrices to compute the output position.
    float4 worldPosition = mul(input.Position, mul(World, transpose(instanceTransform)));
    float4 viewPosition = mul(worldPosition, View);
    output.Position = mul(viewPosition, Projection);

    output.Color = input.Color;

    return output;
}

float4 PixelShaderFunction(VertexShaderOutput input) : SV_Target
{
    return input.Color;
}

technique10 HardwareInstancing
{
    pass Pass1
    {
        VertexShader = compile vs_4_0 HardwareInstancingVertexShader();
        PixelShader = compile ps_4_0 PixelShaderFunction();
    }
}

/*
technique HardwareInstancing
{
    pass Pass1
    {
        VertexShader = compile vs_2_0 HardwareInstancingVertexShader();
        PixelShader = compile ps_2_0 PixelShaderFunction();
    }
}
*/