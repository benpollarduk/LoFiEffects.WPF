sampler2D implicitInput : register(s0);
float intensity : register(c0);
float min = 0;
float max = 0.03;

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float clampedIntensity = saturate(intensity);
    float size =  min + ((max - min) * clampedIntensity);
    float2 coord = floor(uv / size) * size;
    return tex2D(implicitInput, coord);
}
