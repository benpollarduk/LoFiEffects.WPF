sampler2D implicitInput;
float textureWidth : register(c0);
float textureHeight : register(c1);
float includeScanlines : register(c2);

float4 main(float2 uv : TEXCOORD0) : COLOR
{
    float2 pixelCoords = uv * float2(textureWidth, textureHeight);
    int x = int(pixelCoords.x);
    int y = int(pixelCoords.y);
    float4 color = tex2D(implicitInput, uv);

    // scanline mode
    if (includeScanlines > 0)
    {
        if (y % 2 == 1)
        {
            return float4(0.0, 0.0, 0.0, color.a);
        }

        float redChannel = (x % 4 == 0) ? color.r : 0.0;
        float greenChannel = (x % 4 == 1) ? color.g : 0.0;
        float blueChannel = (x % 4 == 2) ? color.b : 0.0;

        return float4(redChannel, greenChannel, blueChannel, color.a);
    }

    // non-scanline mode
    float redChannel = (x % 3 == 0) ? color.r : 0.0;
    float greenChannel = (x % 3 == 1) ? color.g : 0.0;
    float blueChannel = (x % 3 == 2) ? color.b : 0.0;

    return float4(redChannel, greenChannel, blueChannel, color.a);
}
