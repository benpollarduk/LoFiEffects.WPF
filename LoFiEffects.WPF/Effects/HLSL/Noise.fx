sampler2D implicitInput : register(s0);
float density : register(c0);
float intensity : register(c1);
float offset : register(c2);

float RandomNoise(float2 st)
{
    float n = dot(st, float2(12.9898, 78.233));
    n = frac(sin(n) * 43758.5453);
    return n;
}

float4 main(float2 texCoord : TEXCOORD) : COLOR
{
    float clampedDensity = clamp(density, 0.0, 1.0);
    float clampedIntensity = clamp(intensity, 0.0, 1.0);
    float2 offsetCoord = texCoord + offset;
    float4 color = tex2D(implicitInput, texCoord);

    if (color.a > 0.0)
    {
        float noise = RandomNoise(offsetCoord);
        color.rgb += noise * clampedDensity * clampedIntensity;
    }

    return color;
}
