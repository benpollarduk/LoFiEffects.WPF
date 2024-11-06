sampler2D implicitInput : register(s0);

float4 main(float2 uv : TEXCOORD) : COLOR {
    float4 inverted = tex2D(implicitInput, uv);
    inverted.rgb = 1 - inverted.rgb;
    return inverted;
}