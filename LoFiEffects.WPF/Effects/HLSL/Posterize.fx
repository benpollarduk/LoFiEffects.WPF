sampler2D inputTexture : register(s0);
float levels : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    // Sample the color from the texture
    float4 color = tex2D(inputTexture, uv);
    
    // Quantize each color channel
    color.r = floor(color.r * levels) / levels;
    color.g = floor(color.g * levels) / levels;
    color.b = floor(color.b * levels) / levels;

    return color;
}