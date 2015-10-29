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
namespace NShader
{
    /// <summary>
    /// Supported extensions. Loaded by NShaderScannerFactory.
    /// WARNING, you need also to add those extensions manually to NShader.cs and NShader.pkgdef!
    /// </summary>
    public class NShaderSupportedExtensions
    {
        // HLSL file extensions
        public const string HLSL_FX = ".fx";
        public const string HLSL_FXH = ".fxh";
        public const string HLSL_HLSL = ".hlsl";
        public const string HLSL_VSH = ".vsh";
        public const string HLSL_FSH = ".fsh";
        public const string HLSL_PSH = ".psh";
        public const string SL_FX = ".slfx";
        public const string UNREAL_SHADER = ".usf";

        // GLSL file extensions
        public const string GLSL_FRAG = ".frag";
        public const string GLSL_VERT = ".vert";
        public const string GLSL_FP = ".fp";
        public const string GLSL_VP = ".vp";
        public const string GLSL_GEOM = ".geom";
        public const string GLSL_GLSL = ".glsl";
        public const string GLSL_XSH = ".xsh";

        // CG file extensions
        public const string CG_CG = ".cg";
        public const string CG_CGFX = ".cgfx";

        // Unity file extensions
        public const string UNITY_SHADER = ".shader";
        public const string UNITY_CGINC = ".cginc";
        public const string UNITY_COMPUTE = ".compute";
    }
}