sampler2D implicitInput : register(s0);
float stepsR : register(c0);
float stepsG : register(c1);
float stepsB : register(c2);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
    color.r = floor(color.r * stepsR) / stepsR;
    color.g = floor(color.g * stepsG) / stepsG;
    color.b = floor(color.b * stepsB) / stepsB;

    return color;
}