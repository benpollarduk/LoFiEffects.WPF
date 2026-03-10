sampler2D implicitInput : register(s0);
float Key : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 c = tex2D(implicitInput, uv);
    
    // Simplistic mod math to simulate XOR if true bitwise is unavailable in ps_2_0
    float keyF = fmod(Key * 255.0, 255.0);
    c.r = fmod(c.r * 255.0 + keyF, 255.0) / 255.0;
    c.g = fmod(c.g * 255.0 + keyF, 255.0) / 255.0;
    c.b = fmod(c.b * 255.0 + keyF, 255.0) / 255.0;
    
    return c;
}