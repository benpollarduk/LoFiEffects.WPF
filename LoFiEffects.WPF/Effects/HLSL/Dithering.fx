sampler2D ImplicitInput : register(s0);

/// <summary>
/// Intensity of the dithering effect.
/// </summary>
float Intensity : register(c0);

/// <summary>
/// Width of the texture.
/// </summary>
float TextureWidth : register(c1);

/// <summary>
/// Height of the texture.
/// </summary>
float TextureHeight : register(c2);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(ImplicitInput, uv);
    
    // Evaluate luminance
    float luminance = dot(color.rgb, float3(0.299, 0.587, 0.114));

    // Simple 2x2 Bayer matrix approximation
    int x = (int)(uv.x * TextureWidth) % 2;
    int y = (int)(uv.y * TextureHeight) % 2;
    
    float threshold = 0.0;
    
    if (x == 0 && y == 0) threshold = 0.25;
    else if (x == 1 && y == 0) threshold = 0.75;
    else if (x == 0 && y == 1) threshold = 1.0;
    else if (x == 1 && y == 1) threshold = 0.5;

    // Apply dithering
    // Intensity modifies how intense the dithering applies
    float val = luminance < threshold * Intensity ? 0.0 : 1.0;
    
    return float4(val, val, val, color.a);
}