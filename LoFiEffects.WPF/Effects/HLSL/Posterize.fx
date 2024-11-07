sampler2D implicitInput : register(s0);
float steps : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);
    float clampedSteps = clamp(steps, 1.0, 255.0);
    color.r = floor(color.r * clampedSteps) / clampedSteps;
    color.g = floor(color.g * clampedSteps) / clampedSteps;
    color.b = floor(color.b * clampedSteps) / clampedSteps;

    return color;
}