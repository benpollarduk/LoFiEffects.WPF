sampler2D inputTexture : register(s0);
float steps : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(inputTexture, uv);
    color.r = floor(color.r * steps) / steps;
    color.g = floor(color.g * steps) / steps;
    color.b = floor(color.b * steps) / steps;

    return color;
}