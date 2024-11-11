sampler2D implicitInput;
float textureWidth : register(c0);
float textureHeight : register(c1);
float includeScanlines : register(c2);
float intensity : register(c3);

float4 main(float2 uv : TEXCOORD0) : COLOR
{
    float2 pixelCoords = uv * float2(textureWidth, textureHeight);
    int x = int(pixelCoords.x);
    int y = int(pixelCoords.y);
    float4 color = tex2D(implicitInput, uv);
    float clampedIntensity = clamp(intensity, 0.0, 1.0);

    if (includeScanlines > 0 && y % 2 == 1)
    {
        return float4 (0.0, 0.0, 0.0, color.a);
    }

    float redChannel = (x % 3 == 0) ? color.r : (1.0 - clampedIntensity) * color.r;
    float greenChannel = (x % 3 == 1) ? color.g : (1.0 - clampedIntensity) * color.g;
    float blueChannel = (x % 3 == 2) ? color.b : (1.0 - clampedIntensity) * color.b;

    return float4(redChannel, greenChannel, blueChannel, color.a);
}
