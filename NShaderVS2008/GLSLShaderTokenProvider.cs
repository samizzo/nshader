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
using NShader.Lexer;

namespace NShader
{
    public class GLSLShaderTokenProvider : IShaderTokenProvider
    {
        private static Dictionary<string,ShaderToken> map;

        private static void AddToDictionary(string text, ShaderToken token)
        {
            map.Add(text.ToLower(), token);
        }

        static GLSLShaderTokenProvider()
        {
            map = new Dictionary<string, ShaderToken>();
            AddToDictionary("attribute", ShaderToken.KEYWORD);
            AddToDictionary("const", ShaderToken.KEYWORD);
            AddToDictionary("uniform", ShaderToken.KEYWORD);
            AddToDictionary("varying", ShaderToken.KEYWORD);
            AddToDictionary("layout", ShaderToken.KEYWORD);
            AddToDictionary("centroid", ShaderToken.KEYWORD);
            AddToDictionary("flat", ShaderToken.KEYWORD);
            AddToDictionary("smooth", ShaderToken.KEYWORD);
            AddToDictionary("noperspective", ShaderToken.KEYWORD);
            AddToDictionary("break", ShaderToken.KEYWORD);
            AddToDictionary("continue", ShaderToken.KEYWORD);
            AddToDictionary("do", ShaderToken.KEYWORD);
            AddToDictionary("for", ShaderToken.KEYWORD);
            AddToDictionary("while", ShaderToken.KEYWORD);
            AddToDictionary("switch", ShaderToken.KEYWORD);
            AddToDictionary("case", ShaderToken.KEYWORD);
            AddToDictionary("default", ShaderToken.KEYWORD);
            AddToDictionary("if", ShaderToken.KEYWORD);
            AddToDictionary("else", ShaderToken.KEYWORD);
            AddToDictionary("in", ShaderToken.KEYWORD);
            AddToDictionary("out", ShaderToken.KEYWORD);
            AddToDictionary("inout", ShaderToken.KEYWORD);
            AddToDictionary("float", ShaderToken.TYPE);
            AddToDictionary("int", ShaderToken.TYPE);
            AddToDictionary("void", ShaderToken.TYPE);
            AddToDictionary("bool", ShaderToken.TYPE);
            AddToDictionary("true", ShaderToken.KEYWORD);
            AddToDictionary("false", ShaderToken.KEYWORD);
            AddToDictionary("invariant", ShaderToken.KEYWORD);
            AddToDictionary("discard", ShaderToken.KEYWORD);
            AddToDictionary("return", ShaderToken.KEYWORD);
            AddToDictionary("mat2", ShaderToken.TYPE);
            AddToDictionary("mat3", ShaderToken.TYPE);
            AddToDictionary("mat4", ShaderToken.TYPE);
            AddToDictionary("mat2x2", ShaderToken.TYPE);
            AddToDictionary("mat2x3", ShaderToken.TYPE);
            AddToDictionary("mat2x4", ShaderToken.TYPE);
            AddToDictionary("mat3x2", ShaderToken.TYPE);
            AddToDictionary("mat3x3", ShaderToken.TYPE);
            AddToDictionary("mat3x4", ShaderToken.TYPE);
            AddToDictionary("mat4x2", ShaderToken.TYPE);
            AddToDictionary("mat4x3", ShaderToken.TYPE);
            AddToDictionary("mat4x4", ShaderToken.TYPE);
            AddToDictionary("vec2", ShaderToken.TYPE);
            AddToDictionary("vec3", ShaderToken.TYPE);
            AddToDictionary("vec4", ShaderToken.TYPE);
            AddToDictionary("ivec2", ShaderToken.TYPE);
            AddToDictionary("ivec3", ShaderToken.TYPE);
            AddToDictionary("ivec4", ShaderToken.TYPE);
            AddToDictionary("bvec2", ShaderToken.TYPE);
            AddToDictionary("bvec3", ShaderToken.TYPE);
            AddToDictionary("bvec4", ShaderToken.TYPE);
            AddToDictionary("uint", ShaderToken.TYPE);
            AddToDictionary("uvec2", ShaderToken.TYPE);
            AddToDictionary("uvec3", ShaderToken.TYPE);
            AddToDictionary("uvec4", ShaderToken.TYPE);
            AddToDictionary("lowp", ShaderToken.KEYWORD);
            AddToDictionary("mediump", ShaderToken.KEYWORD);
            AddToDictionary("highp", ShaderToken.KEYWORD);
            AddToDictionary("precision", ShaderToken.KEYWORD);
            AddToDictionary("sampler1D", ShaderToken.TYPE);
            AddToDictionary("sampler2D", ShaderToken.TYPE);
            AddToDictionary("sampler3D", ShaderToken.TYPE);
            AddToDictionary("samplerCube", ShaderToken.TYPE);
            AddToDictionary("sampler1DShadow", ShaderToken.TYPE);
            AddToDictionary("sampler2DShadow", ShaderToken.TYPE);
            AddToDictionary("samplerCubeShadow", ShaderToken.TYPE);
            AddToDictionary("sampler1DArray", ShaderToken.TYPE);
            AddToDictionary("sampler2DArray", ShaderToken.TYPE);
            AddToDictionary("sampler1DArrayShadow", ShaderToken.TYPE);
            AddToDictionary("sampler2DArrayShadow", ShaderToken.TYPE);
            AddToDictionary("isampler1D", ShaderToken.TYPE);
            AddToDictionary("isampler2D", ShaderToken.TYPE);
            AddToDictionary("isampler3D", ShaderToken.TYPE);
            AddToDictionary("isamplerCube", ShaderToken.TYPE);
            AddToDictionary("isampler1DArray", ShaderToken.TYPE);
            AddToDictionary("isampler2DArray", ShaderToken.TYPE);
            AddToDictionary("usampler1D", ShaderToken.TYPE);
            AddToDictionary("usampler2D", ShaderToken.TYPE);
            AddToDictionary("usampler3D", ShaderToken.TYPE);
            AddToDictionary("usamplerCube", ShaderToken.TYPE);
            AddToDictionary("usampler1DArray", ShaderToken.TYPE);
            AddToDictionary("usampler2DArray", ShaderToken.TYPE);
            AddToDictionary("sampler2DRect", ShaderToken.TYPE);
            AddToDictionary("sampler2DRectShadow", ShaderToken.TYPE);
            AddToDictionary("isampler2DRect", ShaderToken.TYPE);
            AddToDictionary("usampler2DRect", ShaderToken.TYPE);
            AddToDictionary("samplerBuffer", ShaderToken.TYPE);
            AddToDictionary("isamplerBuffer", ShaderToken.TYPE);
            AddToDictionary("usamplerBuffer", ShaderToken.TYPE);
            AddToDictionary("sampler2DMS", ShaderToken.TYPE);
            AddToDictionary("isampler2DMS", ShaderToken.TYPE);
            AddToDictionary("usampler2DMS", ShaderToken.TYPE);
            AddToDictionary("sampler2DMSArray", ShaderToken.TYPE);
            AddToDictionary("isampler2DMSArray", ShaderToken.TYPE);
            AddToDictionary("usampler2DMSArray", ShaderToken.TYPE);
            AddToDictionary("struct", ShaderToken.KEYWORD);
            AddToDictionary("gl_Position", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_PointSize", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ClipVertex", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_FragCoord", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_FrontFacing", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_FragColor", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_FragData", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_FragDepth", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_Color", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_SecondaryColor", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_Normal", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_Vertex", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_FogCoord", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MultiTexCoord0", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MultiTexCoord1", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MultiTexCoord2", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MultiTexCoord3", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MultiTexCoord4", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MultiTexCoord5", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MultiTexCoord6", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MultiTexCoord7", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MultiTexCoord8", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MultiTexCoord9", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MultiTexCoord10", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MultiTexCoord11", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_FrontColor", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_BackColor", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_FrontSecondaryColor", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_BackSecondaryColor", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_TexCoord", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_FogFragCoord", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ModelViewMatrix", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ProjectionMatrix", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ModelViewProjectionMatrix", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_NormalMatrix", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_TextureMatrix", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_NormalScale", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_DepthRange", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ClipPlane", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_Point", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_FrontMaterial", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_BackMaterial", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_LightSource", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_LightModel", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_FrontLightModelProduct", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_BackLightModelProduct", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_FrontLightProduct", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_BackLightProduct", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_TextureEnvColor", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_Fog", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_EyePlaneS", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_EyePlaneT", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_EyePlaneR", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_EyePlaneQ", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ObjectPlaneS", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ObjectPlaneT", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ObjectPlaneR", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ObjectPlaneQ", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ModelViewMatrixInverse", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ProjectionMatrixInverse", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ModelViewProjectionMatrixInverse", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_TextureMatrixInverse", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ModelViewMatrixTranspose", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ProjectionMatrixTranspose", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ModelViewProjectionMatrixTranspose", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_TextureMatrixTranspose", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ModelViewMatrixInverseTranspose", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ProjectionMatrixInverseTranspose", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_ModelViewProjectionMatrixInverseTranspose", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_TextureMatrixInverseTranspose", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_DepthRangeParameters", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_PointParameters", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MaterialParameters", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_LightSourceParameters", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_LightModelParameters", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_LightModelProducts", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_LightProducts", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_FogParameters", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MaxLights", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MaxClipPlanes", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MaxTextureUnits", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MaxTextureCoords", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MaxVertexAttribs", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MaxVertexUniformComponents", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MaxVaryingFloats", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MaxVertexTextureImageUnits", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MaxCombinedTextureImageUnits", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MaxTextureImageUnits", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MaxFragmentUniformComponents", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("gl_MaxDrawBuffers", ShaderToken.KEYWORD_SPECIAL);
            AddToDictionary("radians", ShaderToken.INTRINSIC);
            AddToDictionary("degrees", ShaderToken.INTRINSIC);
            AddToDictionary("sin", ShaderToken.INTRINSIC);
            AddToDictionary("cos", ShaderToken.INTRINSIC);
            AddToDictionary("tan", ShaderToken.INTRINSIC);
            AddToDictionary("asin", ShaderToken.INTRINSIC);
            AddToDictionary("acos", ShaderToken.INTRINSIC);
            AddToDictionary("atan", ShaderToken.INTRINSIC);
            AddToDictionary("pow", ShaderToken.INTRINSIC);
            AddToDictionary("exp2", ShaderToken.INTRINSIC);
            AddToDictionary("log2", ShaderToken.INTRINSIC);
            AddToDictionary("sqrt", ShaderToken.INTRINSIC);
            AddToDictionary("inversesqrt", ShaderToken.INTRINSIC);
            AddToDictionary("abs", ShaderToken.INTRINSIC);
            AddToDictionary("sign", ShaderToken.INTRINSIC);
            AddToDictionary("floor", ShaderToken.INTRINSIC);
            AddToDictionary("ceil", ShaderToken.INTRINSIC);
            AddToDictionary("fract", ShaderToken.INTRINSIC);
            AddToDictionary("mod", ShaderToken.INTRINSIC);
            AddToDictionary("min", ShaderToken.INTRINSIC);
            AddToDictionary("max", ShaderToken.INTRINSIC);
            AddToDictionary("clamp", ShaderToken.INTRINSIC);
            AddToDictionary("mix", ShaderToken.INTRINSIC);
            AddToDictionary("step", ShaderToken.INTRINSIC);
            AddToDictionary("smoothstep", ShaderToken.INTRINSIC);
            AddToDictionary("length", ShaderToken.INTRINSIC);
            AddToDictionary("distance", ShaderToken.INTRINSIC);
            AddToDictionary("dot", ShaderToken.INTRINSIC);
            AddToDictionary("cross", ShaderToken.INTRINSIC);
            AddToDictionary("normalize", ShaderToken.INTRINSIC);
            AddToDictionary("ftransform", ShaderToken.INTRINSIC);
            AddToDictionary("faceforward", ShaderToken.INTRINSIC);
            AddToDictionary("reflect", ShaderToken.INTRINSIC);
            AddToDictionary("matrixcompmult", ShaderToken.INTRINSIC);
            AddToDictionary("lessThan", ShaderToken.INTRINSIC);
            AddToDictionary("lessThanEqual", ShaderToken.INTRINSIC);
            AddToDictionary("greaterThan", ShaderToken.INTRINSIC);
            AddToDictionary("greaterThanEqual", ShaderToken.INTRINSIC);
            AddToDictionary("equal", ShaderToken.INTRINSIC);
            AddToDictionary("notEqual", ShaderToken.INTRINSIC);
            AddToDictionary("any", ShaderToken.INTRINSIC);
            AddToDictionary("all", ShaderToken.INTRINSIC);
            AddToDictionary("not", ShaderToken.INTRINSIC);
            AddToDictionary("texture1D", ShaderToken.INTRINSIC);
            AddToDictionary("texture1DProj", ShaderToken.INTRINSIC);
            AddToDictionary("texture1DLod", ShaderToken.INTRINSIC);
            AddToDictionary("texture1DProjLod", ShaderToken.INTRINSIC);
            AddToDictionary("texture2D", ShaderToken.INTRINSIC);
            AddToDictionary("texture2DProj", ShaderToken.INTRINSIC);
            AddToDictionary("texture2DLod", ShaderToken.INTRINSIC);
            AddToDictionary("texture2DProjLod", ShaderToken.INTRINSIC);
            AddToDictionary("texture3D", ShaderToken.INTRINSIC);
            AddToDictionary("texture3DProj", ShaderToken.INTRINSIC);
            AddToDictionary("texture3DLod", ShaderToken.INTRINSIC);
            AddToDictionary("texture3DProjLod", ShaderToken.INTRINSIC);
            AddToDictionary("textureCube", ShaderToken.INTRINSIC);
            AddToDictionary("textureCubeLod", ShaderToken.INTRINSIC);
            AddToDictionary("shadow1D", ShaderToken.INTRINSIC);
            AddToDictionary("shadow1DProj", ShaderToken.INTRINSIC);
            AddToDictionary("shadow1DLod", ShaderToken.INTRINSIC);
            AddToDictionary("shadow1DProjLod", ShaderToken.INTRINSIC);
            AddToDictionary("shadow2D", ShaderToken.INTRINSIC);
            AddToDictionary("shadow2DProj", ShaderToken.INTRINSIC);
            AddToDictionary("shadow2DLod", ShaderToken.INTRINSIC);
            AddToDictionary("shadow2DProjLod", ShaderToken.INTRINSIC);
            AddToDictionary("dFdx", ShaderToken.INTRINSIC);
            AddToDictionary("dFdy", ShaderToken.INTRINSIC);
            AddToDictionary("fwidth", ShaderToken.INTRINSIC);
            AddToDictionary("noise1", ShaderToken.INTRINSIC);
            AddToDictionary("noise2", ShaderToken.INTRINSIC);
            AddToDictionary("noise3", ShaderToken.INTRINSIC);
            AddToDictionary("noise4", ShaderToken.INTRINSIC);
            AddToDictionary("refract", ShaderToken.INTRINSIC);
            AddToDictionary("exp", ShaderToken.INTRINSIC);
            AddToDictionary("log", ShaderToken.INTRINSIC);
        }

        public ShaderToken GetTokenFromSemantics(string text)
        {
            text = text.Substring(1, text.Length - 1);
            text = text.Replace(" ", "");
            return GetTokenFromIdentifier(text);
        }
        
        public ShaderToken GetTokenFromIdentifier(string text)
        {
            ShaderToken token;
            if ( ! map.TryGetValue(text.ToLower(), out token) )
            {
                token = ShaderToken.IDENTIFIER;
            }
            return token;
        }

    }
}