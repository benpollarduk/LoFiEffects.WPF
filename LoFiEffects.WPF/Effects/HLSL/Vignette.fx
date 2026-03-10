sampler2D ImplicitInput : register(s0);

/// <summary>
/// Intensity of the vignette.
/// </summary>
float Intensity : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(ImplicitInput, uv);
    
    float2 center = float2(0.5, 0.5);
    float dist = distance(uv, center);
    
    // Smoothstep for vignette effect
    // As dist increases, v goes to 0
    float v = smoothstep(1.0, 1.0 - Intensity, dist * 1.5);
    
    return float4(color.rgb * v, color.a);
}