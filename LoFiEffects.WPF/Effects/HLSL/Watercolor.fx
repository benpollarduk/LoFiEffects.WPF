sampler2D implicitInput : register(s0);
float intensity : register(c0);
float textureWidth : register(c1);
float textureHeight : register(c2);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float2 texel = float2(1.0 / textureWidth, 1.0 / textureHeight);

    // Single noise calculation for both wobble and granulation
    float noise = frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453);

    // Wobble UVs
    float2 wobble = (float2(noise, frac(noise * 2.0)) - 0.5) * intensity * 6.0 * texel;
    float2 warpedUV = uv + wobble;

    // Take just 3 samples to blend colors and keep instruction count low
    float4 c1 = tex2D(implicitInput, warpedUV);
    float4 c2 = tex2D(implicitInput, warpedUV + texel * intensity * 3.0);
    float4 c3 = tex2D(implicitInput, warpedUV - texel * intensity * 3.0);

    float4 color = (c1 + c2 + c3) * 0.3333;

    // Edge darkening (pseudo-edge detection based on sample differences)
    float edge = distance(c2.rgb, c3.rgb);
    color.rgb -= saturate(edge) * intensity * 0.8;

    // Posterize to flatten color regions like dried paint
    float steps = lerp(20.0, 8.0, intensity);
    color.rgb = floor(color.rgb * steps) / steps;

    // Apply paper-like granulation
    color.rgb += (noise - 0.5) * intensity * 0.15;

    // Keep bright, wash-like tone
    color.rgb *= (1.0 + 0.15 * intensity);

    return float4(saturate(color.rgb), color.a);
}