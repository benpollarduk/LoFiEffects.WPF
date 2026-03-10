sampler2D implicitInput : register(s0);
float Intensity : register(c0);
float Resolution : register(c1);
float Time : register(c2);

// simple hash function
float hash(float2 p) { return frac(sin(dot(p, float2(12.9898, 78.233))) * 43758.5453); }

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float2 blockUv = floor(uv * float2(Resolution, Resolution));
    float offset = (hash(blockUv + Time) - 0.5) * Intensity;
    float2 displacedUv = uv + float2(offset, 0.0);
    return tex2D(implicitInput, displacedUv);
}