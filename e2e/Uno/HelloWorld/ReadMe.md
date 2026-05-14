# Prism Uno playground (e2e)

Single-project Uno sample: **regions** (`NavigationView` + nested `ContentControl`), **dialogs**, **modularity** (`Playground.Module`), **DryIoc**, **`ILoadableShell`** / splash, and **`InvokeCommandAction`** on Home.

## Build from repo root

Prism packages are **project references**; builds compile `src/Uno` as needed.

**Skia / workloads:** This sample omits `SkiaRenderer` in `UnoFeatures` so `dotnet workload restore` succeeds on Android/iOS heads (Uno `ReplaceUnoRuntime` / `RuntimeAssetsSelectorTask` issue when Skia is forced for those TFMs).

### `dotnet build` (CLI-friendly TFMs)

```powershell
dotnet build .\e2e\Uno\HelloWorld\HelloWorld.csproj -f net10.0-desktop
dotnet build .\e2e\Uno\HelloWorld\HelloWorld.csproj -f net10.0-browserwasm
```

### WinUI (`net10.0-windows10.0.*`)

Uno blocks **`dotnet build`** for WinUI class libraries that contain XAML (error **UNOB0008**). Build the **Windows** TFM with **Visual Studio** or **`msbuild`** (same as CI for `Prism.Uno`):

```powershell
msbuild .\e2e\Uno\HelloWorld\HelloWorld.csproj -restore -p:TargetFramework=net10.0-windows10.0.26100
```

### Full solution file

`HelloWorld.slnx` includes Prism library projects. Do **not** pass a single `-f` to the whole solution: that forces every project (including `Prism.Core`) onto one TFM. Prefer building **`HelloWorld.csproj`** per TFM as above.

## Getting started (Uno)

https://aka.platform.uno/get-started

https://aka.platform.uno/using-uno-sdk
