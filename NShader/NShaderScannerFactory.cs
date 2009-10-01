#region Header Licence
//  ---------------------------------------------------------------------
// 
//  Copyright (c) 2009 Alexandre Mutel and Microsoft Corporation.  
//  All rights reserved.
// 
//  This code module is part of NShader, a plugin for visual studio
//  to provide syntax highlighting for shader languages (hlsl, glsl, cg)
// 
//  ------------------------------------------------------------------
// 
//  This code is licensed under the Microsoft Public License. 
//  See the file License.txt for the license details.
//  More info on: http://nshader.codeplex.com
// 
//  ------------------------------------------------------------------
#endregion
using System.Collections.Generic;
using System.IO;

namespace NShader
{
    public class NShaderScannerFactory {
        private static NShaderScanner hlslScanner;
        private static NShaderScanner glslScanner;
        private static NShaderScanner cgScanner;
        private static Dictionary<string, NShaderScanner> mapExtensionToScanner;

        static NShaderScannerFactory() {

            mapExtensionToScanner = new Dictionary<string, NShaderScanner>();

            // HLSL Scanner
            hlslScanner = new NShaderScanner(new HLSLShaderTokenProvider());
            mapExtensionToScanner.Add(NShaderSupportedExtensions.HLSL_FX,hlslScanner);

            // GLSL Scanner
            glslScanner = new NShaderScanner(new GLSLShaderTokenProvider());
            mapExtensionToScanner.Add(NShaderSupportedExtensions.GLSL_FRAG, glslScanner);
            mapExtensionToScanner.Add(NShaderSupportedExtensions.GLSL_VERT, glslScanner);
            mapExtensionToScanner.Add(NShaderSupportedExtensions.GLSL_FP, glslScanner);
            mapExtensionToScanner.Add(NShaderSupportedExtensions.GLSL_VP, glslScanner);
            mapExtensionToScanner.Add(NShaderSupportedExtensions.GLSL_GLSL, glslScanner);

            // CG Scanner
            cgScanner = new NShaderScanner(new HLSLShaderTokenProvider());
            mapExtensionToScanner.Add(NShaderSupportedExtensions.CG_CG, cgScanner);
            mapExtensionToScanner.Add(NShaderSupportedExtensions.CG_CGFX, cgScanner);
        }

        public static NShaderScanner GetScannerFromFilename(string filepath)
        {
            string ext = Path.GetExtension(filepath).ToLower();
            NShaderScanner scanner;
            if ( ! mapExtensionToScanner.TryGetValue(ext, out scanner) )
            {
                scanner = hlslScanner;
            }
            return scanner;
        }
    }
}