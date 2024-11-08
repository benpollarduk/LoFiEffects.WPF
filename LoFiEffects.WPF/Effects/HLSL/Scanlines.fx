sampler2D implicitInput : register(s0);
float xSpacing : register(c0);
float ySpacing : register(c1);
float textureWidth : register(c2);
float textureHeight : register(c3);
float renderOverTransparent : register(c4);
float4 scanlineColor : register(c5);
float cornerRadius : register(c6);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
    float xDist = fmod(uv.x * textureWidth, xSpacing);
    float yDist = fmod(uv.y * textureHeight, ySpacing);
    float lineDistance = min(xDist, ySpacing - xDist) + min(yDist, ySpacing - yDist);

    if ((color.a != 0 || renderOverTransparent > 0) && 
        (xDist < 1.0 || yDist < 1.0 || lineDistance < cornerRadius))
    {
        color = scanlineColor;
    }

    return color;
}
