sampler2D implicitInput : register(s0);
float xSpacing : register(c0);
float ySpacing : register(c1);
float textureWidth : register(c2);
float textureHeight : register(c3);
float renderOverTransparent : register(c4);
float4 scanlineColor : register(c5);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);

    if ((color.a != 0 || renderOverTransparent > 0) && (fmod(uv.x * textureWidth, xSpacing) < 1.0 || fmod(uv.y * textureHeight, ySpacing) < 1.0))
    {
        color = scanlineColor;
    }

    return color;
}
