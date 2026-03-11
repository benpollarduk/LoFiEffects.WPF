<div align="center">

# LoFiEffects.WPF

A WPF library for rendering content in reduced fidelity. Supports .Net 8.0.

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
* **FrameRateReductionMask** creates a bitmap of the hosted content.
* **FrameRateReductionMask** then renders this bitmap as its background.
* **FrameRateReductionMask** isn't visible to hit testing so allows the UI beneath it to function as usual.

## Sample Image
To illustrate the following shader effects this sample image will be used:

![image](https://raw.githubusercontent.com/benpollarduk/LoFiEffects.WPF/refs/heads/main/LoFiEffects.WPF.TestApp/Images/Mugshot.jpg)

## Shader Effects
All visual effects are created with shader effects.

### Pixelate
Creates a pixelated effect reminiscent of the 8 bit era.

![image](https://github.com/user-attachments/assets/26a00dcb-01c3-449c-8e42-f58ea9e6de46)

#### Example
```xml
<Button>
    <Button.Effect>
        <PixelateEffect Intensity="0.15"/>
    </Button.Effect>
</Button>
```

#### Properties
* **Intensity**: A double specifying the intensity of the effect within a normalised range of 0-1.

### Crt
An effect that aims to create the impression that the visual is being displayed on a cathode ray tube (CRT) display.

<img width="506" height="612" alt="image" src="https://github.com/user-attachments/assets/76a9d73f-0d22-4177-a46f-d0a724255aa8" />

#### Example
```xml
<Button>
    <Button.Effect>
        <CrtEffect TextureWidth="100" TextureHeight="35" IncludeScanlines="False" Intensity="1" CurvatureIntensity="1" Brightness="0.5"/>
    </Button.Effect>
</Button>
```

#### Properties
* **TextureWidth**: A double specifying the rendered width of the texture in WPF units.
* **TextureHeight**: A double specifying the rendered height of the texture in WPF units.
* **IncludeScanlines**: A boolean specifying if scan lines should be included.
* **Intensity**: A double specifying the intensity of the effect within a normalised range of 0-1.
* **CurvatureIntensity**: A double specifying the intensity of the curvature effect within a normalised range of 0-1.
* **Brightness**: A double specifying the brightness within a normalised range of 0-1.

### Degrade
Adds overall degradation to the visual. Similar to the *Noise* effect but works in a subtractive manner.

![image](https://github.com/user-attachments/assets/7a12dfdc-0809-4c17-a501-d52025fe6636)

#### Example
```xml
<Button>
    <Button.Effect>
        <DegradeEffect Intensity="0.3" Density="0.8" Offset="0"/>
    </Button.Effect>
</Button>
```

#### Properties
* **Intensity**: A double specifying the intensity of the effect within a normalised range of 0-1.
* **Density**: A double specifying the density of the effect within a normalised range of 0-1.
* **Offset**: A double specifying an offset to apply to the effect within a normalised range of 0-1. When this value changes different patterns are generated which can be used to add a pseudo-random effect.

### Noise
Adds noise to the visual. Similar to *Degrade* but is additive.

![image](https://github.com/user-attachments/assets/164989b9-f3ba-49d7-8dc4-c661f0a16f41)

#### Example
```xml
<Button>
    <Button.Effect>
        <NoiseEffect Intensity="0.3" Density="0.8" Offset="0"/>
    </Button.Effect>
</Button>
```

#### Properties
* **Intensity**: A double specifying the intensity of the effect within a normalised range of 0-1.
* **Density**: A double specifying the density of the effect within a normalised range of 0-1.
* **Offset**: A double specifying an offset to apply to the effect within a normalised range of 0-1. When this value changes different patterns are generated which can be used to add a pseudo-random effect.

### Grayscale
Applies a simple grayscale effect, converting the target into grayscale. The following purposely crude algorithm is used:
```
gray = (red + green + blue) / 3
```

![image](https://github.com/user-attachments/assets/d29e749c-f243-4390-8f88-2344cfee1b0e)

#### Example
```xml
<Button>
    <Button.Effect>
        <GrayscaleEffect/>
    </Button.Effect>
</Button>
```

### Negative
Applies a simple negative effect, inverting all channels except alpha, rendering the visual as a negative.

![image](https://github.com/user-attachments/assets/54195394-e0a8-43f8-9bf8-0cf35a0039a5)

#### Example
```xml
<Button>
    <Button.Effect>
        <NegativeEffect/>
    </Button.Effect>
</Button>
```

### Posterize
Reduces apparent bit depth across all channels to produce a banding effect.

![image](https://github.com/user-attachments/assets/e09458db-d79b-42d0-9c98-a0e30d15eb92)

#### Example
```xml
<Button>
    <Button.Effect>
        <PosterizeEffect Steps="5"/>
    </Button.Effect>
</Button>
```

#### Properties
* **Steps**: Sets the number of steps used to represent all channels. Supports values between 1 and 255. 1 will reduce a pure black visual as there will be only a single step, and 255 will have no effect as each channel will be represented in full. Low values will have a more pronounced effect, higher values will be subtle.

### Posterize Multi Channel
Reduces apparent bit depth across all channels individually to produce a banding effect.

![image](https://github.com/user-attachments/assets/49c67b3b-7a76-4f3e-8453-b1fcc67b9ff7)

#### Example
```xml
<Button>
    <Button.Effect>
        <PosterizeMultiChannelEffect StepsR="3" StepsG="11" StepsB="5"/>
    </Button.Effect>
</Button>
```

### Watercolor
Applies some simple filtering to produce a subtle watercolor effect.

<img width="506" height="612" alt="image" src="https://github.com/user-attachments/assets/8aac68ba-0a76-4aca-b7e7-49cf8ca43933" />

#### Example
```xml
<Button>
    <Button.Effect>
        <WatercolorEffect TextureWidth="100" TextureHeight="35" Intensity="0.5"/>
    </Button.Effect>
</Button>
```

#### Properties
* **TextureWidth**: A double specifying the rendered width of the texture in WPF units.
* **TextureHeight**: A double specifying the rendered height of the texture in WPF units.
* **Intensity**: A double specifying the intensity of the effect within a normalised range of 0-1.

### Block Displacement
Displaces blocks of pixels in the visual to create a glitch or digital transmission error effect.

<img width="506" height="612" alt="image" src="https://github.com/user-attachments/assets/9518a9fa-29c4-44bb-9419-3cff0a850d25" />

#### Example
```xml
<Button>
    <Button.Effect>
        <BlockDisplacementEffect Intensity="0.1" Resolution="50" Time="50"/>
    </Button.Effect>
</Button>
```

#### Properties
* **Intensity**: A double specifying the intensity of the effect within a normalised range of 0-1.
* **Resolution**: A double specifying the resolution of the blocks.
* **Time**: A double specifying a time offset to animate the displacement over time.

### Chromatic Aberration
Simulates the effect of chromatic aberration by separating color channels and shifting them.

<img width="506" height="612" alt="image" src="https://github.com/user-attachments/assets/aafc9d12-fcf5-4e97-884e-827850234283" />

#### Example
```xml
<Button>
    <Button.Effect>
        <ChromaticAberrationEffect Intensity="10" TextureWidth="100" TextureHeight="35"/>
    </Button.Effect>
</Button>
```

#### Properties
* **Intensity**: A double specifying the intensity of the effect.
* **TextureWidth**: A double specifying the rendered width of the texture in WPF units.
* **TextureHeight**: A double specifying the rendered height of the texture in WPF units.

### Sample And Hold
Simulates a sample and hold effect, keeping the color value of pixels over a region.

<img width="506" height="612" alt="image" src="https://github.com/user-attachments/assets/dfebdbcc-2261-4601-be94-1094324b04f4" />

#### Example
```xml
<Button>
    <Button.Effect>
        <SampleAndHoldEffect Intensity="0.5"/>
    </Button.Effect>
</Button>
```

#### Properties
* **Intensity**: A double specifying the intensity of the effect within a normalised range of 0-1.

### Sample Rate Reduction
Reduces the sample rate of the visual, effectively lowering its fidelity.

<img width="506" height="612" alt="image" src="https://github.com/user-attachments/assets/32784dea-3d6d-4fc7-8005-feb1b1cd3c3f" />

#### Example
```xml
<Button>
    <Button.Effect>
        <SampleRateReductionEffect Scale="50" Jitter="0.05"/>
    </Button.Effect>
</Button>
```

#### Properties
* **Scale**: A double specifying the scale of the reduction.
* **Jitter**: A double specifying the level of jitter applied.

### Wavefolding
Applies a wavefolding effect to the color channels of the visual to create distortion.

<img width="506" height="612" alt="image" src="https://github.com/user-attachments/assets/724eb185-c620-4418-9649-8652ac789836" />

#### Example
```xml
<Button>
    <Button.Effect>
        <WavefoldingEffect Intensity="5"/>
    </Button.Effect>
</Button>
```

#### Properties
* **Intensity**: A double specifying the intensity of the effect.

## Hello World
For a Hello World example with a simple UI see [LoFiEffects.WPF.TestApp/MainWindow.xaml](https://github.com/benpollarduk/LoFiEffects.WPF/blob/main/LoFiEffects.WPF.TestApp/MainWindow.xaml)

<img width="1734" height="829" alt="image" src="https://github.com/user-attachments/assets/9897a38f-7cfc-4705-870b-06fa0f833ea7" />

## Compiling Shaders
Shaders can be compiled using FXC.exe. The *LoFiEffects.WPF* project has a pre-build event that can be used to compile a shader effect when it is built.

The *Shader* variable needs to be set to the name of the shader effect to compile:

```
set Shader=Noise
```

> Note: The path to fxc.exe may need to be changed to suit your build environment depending on the version installed.

```
REM to compile a shader specify the name of the shader, e.g:
REM set Shader=Crt
REM Otherwise use "", e.g:
REM set Shader=""
set Shader=""

set Fxc=C:\Program Files (x86)\Windows Kits\10\bin\10.0.22621.0\x86\fxc.exe
set Input=$(ProjectDir)Effects\HLSL\%Shader%.fx
set Output=$(ProjectDir)Effects\Shaders\%Shader%.ps

if %Shader% == "" (
  echo Not compiling shader as no shader has been set. To compile a shader edit the $(ProjectName) pre-build event.
) else (
  echo Compiling shader %Input%...
  "%Fxc%" /O0 /Zi /T ps_2_0 /Fo "%Output%" "%Input%"
  echo Shader compiled to %Output%. Don't forget to set compiled shader build action to "Resource".
)
```

> Note: If a shader is built for the first time its *Build Action* will need to be manually set to *Resource* to be used by the project.






