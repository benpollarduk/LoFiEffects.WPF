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
    float2 offsetCoord = texCoord + offset;
    float noise = RandomNoise(offsetCoord);
    float4 color = tex2D(implicitInput, texCoord);
    color.rgb += noise * density * intensity;
    return color;
}
