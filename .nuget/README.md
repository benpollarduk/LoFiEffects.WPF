# LoFiEffects.WPF

A WPF library for displaying content in reduced fidelity. Supports .Net 8.0.

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

### Hello World
For a Hello World example with a simple UI see [LoFiEffects.WPF.TestApp/MainWindow.xaml](https://github.com/benpollarduk/LoFiEffects.WPF/blob/main/LoFiEffects.WPF.TestApp/MainWindow.xaml)

## How it works
**LoFiControl** is a simple codebase with 2 main classes, **LoFiPresenter** and **LoFiMask**.
* **LoFiPresenter** hosts WPF content and a **LoFiMask**.
* **LoFiMask** creates a bitmap at a lower resolution from the hosted content.
* **LoFiMask** then renders this bitmap as its background at the same size as the hostesd content using *BitmapScalingMode.NearestNeighbor* to get the pixelated effect.
* **LoFiMask** isn't visible to hit testing so allows the UI beneath it to function as usual.
