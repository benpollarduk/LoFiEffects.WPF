# LoFiEffects.WPF

A WPF library for displaying content in reduced fidelity. Supports .Net 8.0.

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

## Shader Effects
All visual effects are created with shader effects.

### Pixelate
Creates a pixelated effect reminiscent of the 8 bit era.

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

#### Example
```xml
<Button>
    <Button.Effect>
        <CrtEffect TextureWidth="100" TextureHeight="35" IncludeScanlines="False"/>
    </Button.Effect>
</Button>
```

#### Properties
* **TextureWidth**: A double specifying the rendered width of the texture in WPF units.
* **TextureHeight**: A double specifying the rendered height of the texture in WPF units.
* **IncludeScanlines**: A boolean specifying if scan lines should be included.

### Degrade
Adds overall degradation to the visual. Similar to the *Noise* effect but works in a subtractive manner.

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

#### Example
```xml
<Button>
    <Button.Effect>
        <PosterizeMultiChannelEffect StepsR="3" StepsG="11" StepsB="5"/>
    </Button.Effect>
</Button>
```

#### Properties
* **StepsR**: Sets the number of steps used to represent the red channel. Supports values between 1 and 255. Low values will have a more pronounced effect, higher values will be subtle.
* **StepsG**: Sets the number of steps used to represent the green channel. Supports values between 1 and 255. Low values will have a more pronounced effect, higher values will be subtle.
* **StepsB**: Sets the number of steps used to represent the blue channel. Supports values between 1 and 255. Low values will have a more pronounced effect, higher values will be subtle.

### Watercolor
Applies some simple filtering to produce a subtle watercolor effect.

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

## Hello World
For a Hello World example with a simple UI see [LoFiEffects.WPF.TestApp/MainWindow.xaml](https://github.com/benpollarduk/LoFiEffects.WPF/blob/main/LoFiEffects.WPF.TestApp/MainWindow.xaml)

## Compiling Shaders
Shaders can be compiled using FXC.exe. The *LoiEffects.WPF* project has a pre-build event that can be used to compile a shader effect when it is built.

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
