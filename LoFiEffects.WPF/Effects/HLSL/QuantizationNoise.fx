sampler2D implicitInput : register(s0);
float Levels : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 c = tex2D(implicitInput, uv);
    c.r = floor(c.r * Levels) / Levels;
    c.g = floor(c.g * Levels) / Levels;
    c.b = floor(c.b * Levels) / Levels;
    return c;
}