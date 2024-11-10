sampler2D implicitInput : register(s0);
float stepsR : register(c0);
float stepsG : register(c1);
float stepsB : register(c2);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
    float clampedStepsR = clamp(stepsR, 1.0, 255.0);
    float clampedStepsG = clamp(stepsG, 1.0, 255.0);
    float clampedStepsB = clamp(stepsB, 1.0, 255.0);
    color.r = floor(color.r * clampedStepsR) / clampedStepsR;
    color.g = floor(color.g * clampedStepsG) / clampedStepsG;
    color.b = floor(color.b * clampedStepsB) / clampedStepsB;

    return color;
}