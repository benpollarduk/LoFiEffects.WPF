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

### Grayscale
Grayscale applies a simple grayscale effect, converting the target into grayscale. The following purposely crude algorithm is used:

```
gray = (red + green + blue) / 3
```

Example:

```xaml
<Button>
    <Button.Effect>
        <GrayscaleEffect/>
    </Button.Effect>
</Button>
```

### Negative
Negative applies a simple negative effect, converting the target into a negative.

Example:

```xaml
<Button>
    <Button.Effect>
        <NegativeEffect/>
    </Button.Effect>
</Button>
```

### Posterize

### Posterize Multi Channel

### Noise

### Degrade

### Pixelate
Creates a pixelated effect reminiscent of the 8 bit era.

Example:

```xaml
<Button>
    <Button.Effect>
        <PixelateEffect Intensity="0.5"/>
    </Button.Effect>
</Button>
```

### Crt


## Hello World
For a Hello World example with a simple UI see [LoFiEffects.WPF.TestApp/MainWindow.xaml](https://github.com/benpollarduk/LoFiEffects.WPF/blob/main/LoFiEffects.WPF.TestApp/MainWindow.xaml)
