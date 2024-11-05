sampler2D inputTexture : register(s0);
float3 colorLevels = float3(100, 100, 100); // Number of levels per color channel (RGB)

float4 main(float2 uv : TEXCOORD) : COLOR
{
    // Sample the color from the texture
    float4 color = tex2D(inputTexture, uv);
    
    // Quantize each color channel
    color.r = floor(color.r * colorLevels.r) / colorLevels.r;
    color.g = floor(color.g * colorLevels.g) / colorLevels.g;
    color.b = floor(color.b * colorLevels.b) / colorLevels.b;

    return color;
}