sampler2D ImplicitInput : register(s0);

/// <summary>
/// Intensity of the chromatic aberration.
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
    float offsetX = Intensity / TextureWidth;
    float offsetY = Intensity / TextureHeight;
    
    float2 redUV = float2(uv.x - offsetX, uv.y - offsetY);
    float2 blueUV = float2(uv.x + offsetX, uv.y + offsetY);
    
    float4 color = tex2D(ImplicitInput, uv);
    float4 rColor = tex2D(ImplicitInput, redUV);
    float4 bColor = tex2D(ImplicitInput, blueUV);
    
    return float4(rColor.r, color.g, bColor.b, color.a);
}