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
using System.Diagnostics;
using System.Globalization;

namespace NShader
{
    public class NShaderScannerFactory {
        private static NShaderScanner hlslScanner;
        private static NShaderScanner glslScanner;
        private static NShaderScanner cgScanner;
        private static NShaderScanner unityScanner;
        private static Dictionary<string, NShaderScanner> mapExtensionToScanner;
        private static Dictionary<string, NShaderScanner> mapTypeToScanner;

        static void Init() {
            if (mapExtensionToScanner == null)
            {
                mapExtensionToScanner = new Dictionary<string, NShaderScanner>();
                mapTypeToScanner = new Dictionary<string, NShaderScanner>();

                // HLSL Scanner
                hlslScanner = new NShaderScanner(new HLSLShaderTokenProvider());
                // GLSL Scanner
                glslScanner = new NShaderScanner(new GLSLShaderTokenProvider());
                // CG Scanner
                cgScanner = new NShaderScanner(new HLSLShaderTokenProvider());
                //Unity Scanner
                unityScanner = new NShaderScanner(new UNITYShaderTokenProvider());

                mapTypeToScanner.Add("hlsl", hlslScanner);
                mapTypeToScanner.Add("glsl", glslScanner);
                mapTypeToScanner.Add("cg", cgScanner);
                mapTypeToScanner.Add("unity", unityScanner);

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

            try
            {
                using (var sr = new StreamReader(filepath))
                {
                    var line = sr.ReadLine();

                    /*
                     * If the first line contains @shadertype=xxxx then xxxx will be used to determine the syntax highlighting.
                     */
                    var marker = "// shadertype=";
                    if (line.StartsWith(marker))
                    {
                        var shaderType = line.Substring(marker.Length);
                        mapTypeToScanner.TryGetValue(shaderType, out scanner);
                    }
                }
            }
            catch (System.Exception e)
            {
                Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Warning: Couldn't parse file {0}", filepath));
                Trace.WriteLine(e.Message);
            }

            return scanner;
        }

        public static NShaderScanner GetShaderScanner(IVsTextLines buffer)
        {
            return GetShaderScanner(FilePathUtilities.GetFilePath(buffer));
        }
    }
}