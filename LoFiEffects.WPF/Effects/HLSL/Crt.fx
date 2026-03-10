sampler2D implicitInput : register(s0);
float textureWidth : register(c0);
float textureHeight : register(c1);
float includeScanlines : register(c2);
float intensity : register(c3);
float curvatureIntensity : register(c4);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float clampedIntensity = saturate(intensity);
    float clampedCurvature = saturate(curvatureIntensity);

    // CRT Curvature
    float2 dc = uv - 0.5;
    float dist = dot(dc, dc);
    float2 warpedUV = uv + dc * dist * (0.3 * clampedCurvature);

    // Check bounds to draw black borders where curvature pulls in edges
    float inBounds = step(0.0, warpedUV.x) * step(warpedUV.x, 1.0) * step(0.0, warpedUV.y) * step(warpedUV.y, 1.0);

    // Chromatic Aberration
    float offset = 0.005 * clampedIntensity;
    float r = tex2D(implicitInput, warpedUV + float2(offset, 0)).r;
    float g = tex2D(implicitInput, warpedUV).g;
    float b = tex2D(implicitInput, warpedUV - float2(offset, 0)).b;
    float a = tex2D(implicitInput, warpedUV).a;

    float3 color = float3(r, g, b) * inBounds;

    // Vignette (darken corners)
    color *= saturate(1.0 - (dist * 1.5 * clampedIntensity));

    // Scanlines (horizontal bands)
    float scanline = sin(warpedUV.y * textureHeight * 3.14159);
    float scanMultiplier = lerp(1.0, scanline * 0.3 + 0.7, clampedIntensity);
    color *= lerp(1.0, scanMultiplier, step(0.5, includeScanlines));

    // Phosphor effect (vertical bands acting like subpixels)
    float phosphor = sin(warpedUV.x * textureWidth * 3.14159);
    color *= lerp(1.0, phosphor * 0.2 + 0.8, clampedIntensity);

    return float4(saturate(color), a);
}
