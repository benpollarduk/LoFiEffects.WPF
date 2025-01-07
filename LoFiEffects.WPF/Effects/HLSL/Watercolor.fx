sampler2D implicitInput : register(s0);
float intensity : register(c0); // Controls blur and overall intensity of the effect
float textureWidth : register(c1);
float textureHeight : register(c2);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float2 texel = float2(1.0 / textureWidth, 1.0 / textureHeight);
    float4 color = float4(0.0, 0.0, 0.0, 0.0);

    // define the blur kernel offsets
    float2 offsets[9] = {
        float2(-1, -1), float2( 0, -1), float2( 1, -1),
        float2(-1,  0), float2( 0,  0), float2( 1,  0),
        float2(-1,  1), float2( 0,  1), float2( 1,  1)
    };

    // define the weights for the blur kernel
    float weights[9] = {
        1.0 / 16.0, 2.0 / 16.0, 1.0 / 16.0,
        2.0 / 16.0, 4.0 / 16.0, 2.0 / 16.0,
        1.0 / 16.0, 2.0 / 16.0, 1.0 / 16.0
    };

    // apply the blur kernel
    for (int i = 0; i < 9; i++)
    {
        float2 sampleUV = uv + offsets[i] * texel * intensity * 2;
        color += tex2D(implicitInput, sampleUV) * weights[i];
    }

    // enhance saturation
    float luminance = dot(color.rgb, float3(0.299, 0.587, 0.114));
    float3 gray = float3(luminance, luminance, luminance);
    float saturationFactor = lerp(1.0, 1.5, intensity);
    color.rgb = lerp(gray, color.rgb, saturationFactor);

    // posterize
    float steps = 100 - (255.0 * intensity);
    float clampedSteps = clamp(steps, 3.0, 255.0);
    color.r = floor(color.r * clampedSteps) / clampedSteps;
    color.g = floor(color.g * clampedSteps) / clampedSteps;
    color.b = floor(color.b * clampedSteps) / clampedSteps;

    // Dynamically adjust brightness to prevent darkening
    float brightnessFactor = 1.0 + intensity * 0.25;
    color.rgb *= brightnessFactor;

    // Adjust opacity (optional)
    color.a = lerp(color.a, 1.0, 1.0 - intensity);

    return color;
}
