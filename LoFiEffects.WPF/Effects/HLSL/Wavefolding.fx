sampler2D implicitInput : register(s0);
float Intensity : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
    color.rgb = color.rgb * Intensity;
    color.rgb = fmod(color.rgb, 1.999);
    // fold above 1.0
    if (color.r > 1.0) color.r = 2.0 - color.r;
    if (color.g > 1.0) color.g = 2.0 - color.g;
    if (color.b > 1.0) color.b = 2.0 - color.b;
    return color;
}