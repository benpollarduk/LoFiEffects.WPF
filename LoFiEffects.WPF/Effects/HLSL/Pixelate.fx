sampler2D implicitInput : register(s0);
float intensity : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float min = 0.0001;
    float max = 0.03;
    float clampedIntensity = clamp(intensity, 0.0, 1.0);
    float size =  min + ((max - min) * clampedIntensity);
    float2 coord = floor(uv / size) * size;
    return tex2D(implicitInput, coord);
}
