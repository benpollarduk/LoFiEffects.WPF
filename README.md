<div align="center">

# LoFiEffects.WPF

A WPF control that displays content in reduced fidelity. Supports .Net 8.0.

[![main-ci](https://github.com/benpollarduk/lofieffects.wpf/actions/workflows/main-ci.yml/badge.svg)]
[![GitHub release](https://img.shields.io/github/release/benpollarduk/lofieffects.wpf.svg)](https://github.com/benpollarduk/lofieffects.wpf/releases)
[![NuGet](https://img.shields.io/nuget/v/lofieffects.wpf.svg)](https://www.nuget.org/packages/lofieffects.wpf/)
![NuGet Downloads](https://img.shields.io/nuget/dt/lofieffects.wpf)
[![codecov](https://codecov.io/gh/benpollarduk/LoFiEffects.WPF/graph/badge.svg?token=CXNSB6K0QN)](https://codecov.io/gh/benpollarduk/LoFiEffects.WPF)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=benpollarduk_LoFiEffects.WPF&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=benpollarduk_LoFiEffects.WPF)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=benpollarduk_LoFiEffects.WPF&metric=bugs)](https://sonarcloud.io/summary/new_code?id=benpollarduk_LoFiEffects.WPF)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=benpollarduk_LoFiEffects.WPF&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=benpollarduk_LoFiEffects.WPF)
[![License](https://img.shields.io/github/license/benpollarduk/lofieffects.wpf.svg)](https://opensource.org/licenses/MIT)

</div>

## Introduction
There aren't many options available for rendering WPF UIElements in artificially low resolution.
LoFiPresenter provides a simple control that can display content at a reduced resolution and frame rate.

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

### Use
```xml
<LoFiPresenter Reduction="3" FramesPerSecond="20">
    <Label Content="This is an example label" FontSize="20"/>
</LoFiPresenter>
```

### Example
Reduction 1:

![image](https://github.com/benpollarduk/LoFiEffects.WPF/assets/129943363/cfb4cdf6-2657-4e38-aeff-04612c1cf7a8)

Reduction 2:

![image](https://github.com/benpollarduk/LoFiEffects.WPF/assets/129943363/f4208e65-53af-49c2-8f59-7fd60d6dc024)

Reduction 3:

![image](https://github.com/benpollarduk/LoFiEffects.WPF/assets/129943363/a63ba834-fa3f-459f-877f-7fd89363e139)

Reduction 4:

![image](https://github.com/benpollarduk/LoFiEffects.WPF/assets/129943363/264664e1-e06b-4359-bd25-5504bd0bdcaf)

Reduction 5:

![image](https://github.com/benpollarduk/LoFiEffects.WPF/assets/129943363/0468753b-727b-4ea0-ab15-c044d6110ea2)

### Hello World
For a Hello World example with a simple UI see [LoFiEffects.WPF.TestApp/MainWindow.xaml](https://github.com/benpollarduk/LoFiEffects.WPF/blob/main/LoFiEffects.WPF.TestApp/MainWindow.xaml)

![lofi-example](https://github.com/benpollarduk/LoFiEffects.WPF/assets/129943363/d209cf53-4607-4735-b2c8-f19ed36b4fce)

## How it works
LoFiControl is a simple codebase with 2 main classes, LoFiPresenter and LoFiMask.
* LoFiPresenter hosts WPF content and a LoFiMask.
* LoFiMask creates a bitmap at a lower resolution from the hosted content.
* LoFiMask then renders this bitmap as its background at the same size as the hostesd content using BitmapScalingMode.NearestNeighbor to get the pixelated effect.
* The LoFiMask isn't visible to hit testing so allows the UI beneath it to function as usual.
