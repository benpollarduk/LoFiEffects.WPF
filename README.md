<div align="center">

# LoFiEffects.WPF

A WPF library for displaying content in reduced fidelity. Supports .Net 8.0.

[![main-ci](https://github.com/benpollarduk/lofieffects.wpf/actions/workflows/main-ci.yml/badge.svg)](https://github.com/benpollarduk/lofieffects.wpf/actions/workflows/main-ci.yml)
[![GitHub release](https://img.shields.io/github/release/benpollarduk/lofieffects.wpf.svg)](https://github.com/benpollarduk/lofieffects.wpf/releases)
[![NuGet](https://img.shields.io/nuget/v/lofieffects.wpf.svg)](https://www.nuget.org/packages/lofieffects.wpf/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/lofieffects.wpf)](https://www.nuget.org/packages/lofieffects.wpf/)
[![codecov](https://codecov.io/gh/benpollarduk/LoFiEffects.WPF/graph/badge.svg?token=CXNSB6K0QN)](https://codecov.io/gh/benpollarduk/LoFiEffects.WPF)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=benpollarduk_LoFiEffects.WPF&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=benpollarduk_LoFiEffects.WPF)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=benpollarduk_LoFiEffects.WPF&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=benpollarduk_LoFiEffects.WPF)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=benpollarduk_LoFiEffects.WPF&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=benpollarduk_LoFiEffects.WPF)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=benpollarduk_LoFiEffects.WPF&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=benpollarduk_LoFiEffects.WPF)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=benpollarduk_LoFiEffects.WPF&metric=bugs)](https://sonarcloud.io/summary/new_code?id=benpollarduk_LoFiEffects.WPF)
[![License](https://img.shields.io/github/license/benpollarduk/lofieffects.wpf.svg)](https://opensource.org/licenses/MIT)

</div>

## Introduction
A library of controls and shader effects that can display content with reduced frame rates and other visual effects aimed at degrading visual quality.

## Getting Started

### Clone the repo/pull NuGet
Clone the repo:
```bash
git clone https://github.com/benpollarduk/lofieffects.wpf.git
```
Or add the NuGet package:
```bash
dotnet add package LoFiEffects.WPF
```

## Controls

### Frame Rate Reduction
The **FrameRateReductionPresenter** can be used to reduce the frame rate that the content is rendered at.

#### Use
```xml
<FrameRateReductionPresenter FramesPerSecond="5">
    <Button Content="This is an example button"/>
</FrameRateReductionPresenter>
```

The **FramesPerSecond** property can be used to reduce the frame rate.

> Note: Values higher than 60 will disable the effect and normal rendering will be resumed.

#### How it works
* **FrameRateReductionPresenter** hosts WPF content and a **FrameRateReductionMask**.
* **FrameRateReductionMask** creates a bitmap of the the hosted content.
* **FrameRateReductionMask** then renders this bitmap as its background.
* **FrameRateReductionMask** isn't visible to hit testing so allows the UI beneath it to function as usual.

## Shader Effects
All visual effects are created with shader effects.

### Pixelate
Creates a pixelated effect reminiscent of the 8 bit era.

#### Example
```xaml
<Button>
    <Button.Effect>
        <PixelateEffect Intensity="0.5"/>
    </Button.Effect>
</Button>
```

#### Properties
* Intensity. A double specifying the intensity of the effect within a normalised range of 0-1.

### Crt
An effect that aims to create the impression that the visual is being displayed on a cathode-ray tube (CRT) display.

#### Example
```xaml
<Button>
    <Button.Effect>
        <CrtEffect TextureWidth="100" TextureHeight="35" IncludeScanlines="False"/>
    </Button.Effect>
</Button>
```

#### Properties
* TextureWidth. A double specifying the rendered width of the texture in WPF units.
* TextureHeight. A double specifying the rendered height of the texture in WPF units.
* IncludeScanlines. A boolean specifying if scan lines should be included.

### Degrade
Adds overall degradation to the visual. Simpliar to the *Noise* effect but works in a subtractive manner.

#### Example
```xaml
<Button>
    <Button.Effect>
        <DegradeEffect Intensity="0.5" Density="0.5" Offset="0"/>
    </Button.Effect>
</Button>
```

#### Properties
* Intensity. A double specifying the intensity of the effect within a normalised range of 0-1.
* Density. A double specifying the density of the effect within a normalised range of 0-1.
* Offset. A double specifying an offset to apply to the effect within a normalised range of 0-1. When this value changes different patterns are generated which can be used to add a pseudo-random effect.

### Noise
Adds noise to the visual. Similar to *Degrade* but is additive.

#### Example
```xaml
<Button>
    <Button.Effect>
        <NoiseEffect Intensity="0.5" Density="0.5" Offset="0"/>
    </Button.Effect>
</Button>
```

#### Properties
* Intensity. A double specifying the intensity of the effect within a normalised range of 0-1.
* Density. A double specifying the density of the effect within a normalised range of 0-1.
* Offset. A double specifying an offset to apply to the effect within a normalised range of 0-1. When this value changes different patterns are generated which can be used to add a pseudo-random effect.

### Grayscale
Applies a simple grayscale effect, converting the target into grayscale. The following purposely crude algorithm is used:
```
gray = (red + green + blue) / 3
```

#### Example
```xaml
<Button>
    <Button.Effect>
        <GrayscaleEffect/>
    </Button.Effect>
</Button>
```

### Negative
Applies a simple negative effect, inverting all channels except alpha, rendering the visual as a negative.

#### Example
```xaml
<Button>
    <Button.Effect>
        <NegativeEffect/>
    </Button.Effect>
</Button>
```

### Posterize

#### Example
```xaml
<Button>
    <Button.Effect>
        <PosterizeEffect/>
    </Button.Effect>
</Button>
```

#### Properties

### Posterize Multi Channel

#### Example
```xaml
<Button>
    <Button.Effect>
        <PosterizeMultiChannelEffect/>
    </Button.Effect>
</Button>
```

#### Properties

## Hello World
For a Hello World example with a simple UI see [LoFiEffects.WPF.TestApp/MainWindow.xaml](https://github.com/benpollarduk/LoFiEffects.WPF/blob/main/LoFiEffects.WPF.TestApp/MainWindow.xaml)
