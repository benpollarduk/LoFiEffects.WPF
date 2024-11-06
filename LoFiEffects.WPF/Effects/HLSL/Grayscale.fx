sampler2D implicitInput : register(s0);
float factor : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
    float gray = (color.r + color.g + color.b) / 3;   
    
    float4 result;
    result.r = gray;
    result.g = gray;
    result.b = gray;
    result.a = color.a;
    
    return result;
}