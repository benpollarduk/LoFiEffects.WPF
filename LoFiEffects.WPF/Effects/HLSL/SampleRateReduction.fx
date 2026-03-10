sampler2D implicitInput : register(s0);
float Scale : register(c0);
float Jitter : register(c1);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float2 quant = floor(uv * Scale) / Scale;
    float2 jitterUv = quant + (frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453) - 0.5) * Jitter;
    return tex2D(implicitInput, jitterUv);
}