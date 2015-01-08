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
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace NShader
{
    public class NShaderScannerFactory {
        private static NShaderScanner hlslScanner;
        private static NShaderScanner glslScanner;
        private static NShaderScanner cgScanner;
        private static NShaderScanner unityScanner;
        private static Dictionary<string, NShaderScanner> mapExtensionToScanner;

        static void Init() {
            if (mapExtensionToScanner == null)
            {
                mapExtensionToScanner = new Dictionary<string, NShaderScanner>();

                // HLSL Scanner
                hlslScanner = new NShaderScanner(new HLSLShaderTokenProvider());
                // GLSL Scanner
                glslScanner = new NShaderScanner(new GLSLShaderTokenProvider());
                // CG Scanner
                cgScanner = new NShaderScanner(new HLSLShaderTokenProvider());
                //Unity Scanner
                unityScanner = new NShaderScanner(new UNITYShaderTokenProvider());

                foreach (var field in typeof (NShaderSupportedExtensions).GetFields())
                {
                    if (field.Name.StartsWith("HLSL_"))
                        mapExtensionToScanner.Add(field.GetValue(null).ToString(), hlslScanner);
                    if (field.Name.StartsWith("GLSL_"))
                        mapExtensionToScanner.Add(field.GetValue(null).ToString(), glslScanner);
                    if (field.Name.StartsWith("CG_"))
                        mapExtensionToScanner.Add(field.GetValue(null).ToString(), cgScanner);
                    if (field.Name.StartsWith("UNITY_"))
                        mapExtensionToScanner.Add(field.GetValue(null).ToString(), unityScanner);
                }
            }
        }

        public static NShaderScanner GetShaderScanner(string filepath)
        {
            Init();

            string ext = Path.GetExtension(filepath).ToLower();
            NShaderScanner scanner;
            if (!mapExtensionToScanner.TryGetValue(ext, out scanner))
            {
                scanner = hlslScanner;
            }
            return scanner;
        }

        public static NShaderScanner GetShaderScanner(IVsTextLines buffer)
        {
            return GetShaderScanner(FilePathUtilities.GetFilePath(buffer));
        }
    }
}