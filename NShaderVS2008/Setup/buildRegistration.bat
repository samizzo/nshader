:: Copyright (c) Microsoft Corporation. All rights reserved.
:: This code is licensed under the Visual Studio SDK license terms.
:: THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
:: ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
:: IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
:: PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

:: Build the binaries then extract their registry attributes as a WiX include file
setlocal
call "C:\Program Files (x86)\Microsoft Visual Studio 9.0\VC\vcvarsall.bat" x86
echo on

del ..\..\NShader.sln.cache

MSBuild ..\..\NShader.sln /p:Configuration=Release /p:RegisterOutputPackage=false
"C:\Program Files (x86)\Microsoft Visual Studio 2008 SDK\VisualStudioIntegration\Tools\Bin\RegPkg.exe" /codebase /root:Software\Microsoft\VisualStudio\9.0 /wixfile:NShader.wxi %~dp0\..\bin\Release\NShader.dll

pause