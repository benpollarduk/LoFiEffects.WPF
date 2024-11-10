sampler2D implicitInput : register(s0);

float4 main(float2 uv : TEXCOORD) : COLOR {
    float4 color = tex2D(implicitInput, uv);
    
    if (color.a != 0)
    {
        color.rgb = 1 - color.rgb;
    }

    return color;
}