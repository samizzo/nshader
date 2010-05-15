:: Copyright (c) Microsoft Corporation. All rights reserved.
:: This code is licensed under the Visual Studio SDK license terms.
:: THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
:: ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
:: IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
:: PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

:: Build the binaries then build the WiX sources that install them

setlocal
call "C:\Program Files\Microsoft Visual Studio 9.0\VC\vcvarsall.bat" x86
echo on

:: Strange bug. Need to remove sln cache before calling MSBuild (working directory issue?)
del %~dp0\..\..\NShader.sln.cache

MSBuild %~dp0\..\..\NShader.sln /p:Configuration=Release /p:RegisterOutputPackage=false

set WIXDIR=%VSSDK90INSTALL%\VisualStudioIntegration\Tools\Wix
set ObjDir=%~dp0Obj
set VariablesFile=%~dp0Variables.wxi

if not exist "%ObjDir%" mkdir "%ObjDir%"

"%WIXDIR%\candle.exe" -dVariablesFile="%VariablesFile%" -dProductLanguage=1033 -out "%ObjDir%\\" Integration.wxs Product.wxs
"%WIXDIR%\light.exe" "%ObjDir%\Integration.wixobj" "%ObjDir%\Product.wixobj" "%WIXDIR%\wixui.wixlib" -out NShader.msi -loc "%WIXDIR%\WixUI_en-us.wxl"

pause
