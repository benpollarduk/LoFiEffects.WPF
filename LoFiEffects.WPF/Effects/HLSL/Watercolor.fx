sampler2D implicitInput : register(s0);
float intensity : register(c0); // Controls blur and overall intensity of the effect
float textureWidth : register(c1);
float textureHeight : register(c2);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float2 texel = float2(1.0 / textureWidth, 1.0 / textureHeight);
    float4 color = float4(0.0, 0.0, 0.0, 0.0);

    // Define the blur kernel offsets
    float2 offsets[9] = {
        float2(-1, -1), float2( 0, -1), float2( 1, -1),
        float2(-1,  0), float2( 0,  0), float2( 1,  0),
        float2(-1,  1), float2( 0,  1), float2( 1,  1)
    };

    // Define the weights for the blur kernel
    float weights[9] = {
        1.0 / 16.0, 2.0 / 16.0, 1.0 / 16.0,
        2.0 / 16.0, 4.0 / 16.0, 2.0 / 16.0,
        1.0 / 16.0, 2.0 / 16.0, 1.0 / 16.0
    };

    // Apply the blur kernel with greater intensity scaling
    for (int i = 0; i < 9; i++)
    {
        // Scale the offset by a larger factor based on intensity
        float2 sampleUV = uv + offsets[i] * texel * intensity * 5.0; // 5.0 increases the blur significantly
        color += tex2D(implicitInput, sampleUV) * weights[i];
    }

    // Enhance color saturation
    float luminance = dot(color.rgb, float3(0.299, 0.587, 0.114)); // Calculate luminance
    float3 gray = float3(luminance, luminance, luminance);          // Grayscale color
    float saturationFactor = lerp(1.0, 1.5, intensity);             // Increase saturation by up to 1.5x
    color.rgb = lerp(gray, color.rgb, saturationFactor);

    // Dynamically adjust brightness to prevent darkening
    float brightnessFactor = 1.0 + intensity * 0.5; // Increase brightness up to 1.5x
    color.rgb *= brightnessFactor;

    // Adjust opacity
    color.a = color.a - (intensity / 4.0);

    return color;
}
