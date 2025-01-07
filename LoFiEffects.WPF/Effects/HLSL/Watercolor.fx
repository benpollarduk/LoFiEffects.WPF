sampler2D implicitInput : register(s0);
float intensity : register(c0);
float textureWidth : register(c1);
float textureHeight : register(c2);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float2 texel = float2(1.0 / textureWidth, 1.0 / textureHeight);
    float4 color = tex2D(implicitInput, uv);

    // edge detection
    float edge = abs(tex2D(implicitInput, uv + texel).r - tex2D(implicitInput, uv - texel).r) * 0.5;
    edge += abs(tex2D(implicitInput, uv + float2(texel.x, 0)).r - tex2D(implicitInput, uv - float2(texel.x, 0)).r) * 0.5;
    edge = saturate(edge * 2);

    // granulation (single noise layer)
    float noise = frac(sin(dot(uv * 5.0, float2(12.9898, 78.233))) * 43758.5453);
    color.rgb += (noise - 0.5) * intensity * 0.1;

    // enhance edges
    color.rgb *= 1.0 - edge * intensity;

    // posterize
    float steps = lerp(40.0, 5.0, intensity);
    color.rgb = floor(color.rgb * steps) / steps;

    // brightness adjustment to maintain consistency
    float averageBrightness = dot(color.rgb, float3(0.299, 0.587, 0.114)); // Luminance
    float brightnessFactor = lerp(1.0, 1.0 / max(averageBrightness, 0.1), intensity * 0.5);
    color.rgb *= brightnessFactor;

    return color;
}