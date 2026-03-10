sampler2D implicitInput : register(s0);
float Intensity : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    // simulate horizontal streaks
    float band = floor(uv.y * 50.0);
    float noise = frac(sin(band * 12.9898) * 43758.5453);
    if (noise < Intensity) {
        uv.x = floor(uv.x * 10.0) / 10.0;
    }
    return tex2D(implicitInput, uv);
}