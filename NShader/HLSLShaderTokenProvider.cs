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
    public class HLSLShaderTokenProvider : IShaderTokenProvider
    {
        private static Dictionary<string,ShaderToken> map;
        private static Dictionary<string, ShaderToken> mapSemantics;

        private static void AddToDictionary(string text, ShaderToken token)
        {
            map.Add(text.ToLower(), token);
        }

        private static void AddToSemantics(string text)
        {
            mapSemantics.Add(text.ToLower(), ShaderToken.KEYWORD_SPECIAL);
        }

        static HLSLShaderTokenProvider()
        {
            map = new Dictionary<string, ShaderToken>();
            mapSemantics = new Dictionary<string, ShaderToken>();
            AddToDictionary("bool", ShaderToken.TYPE);
            AddToDictionary("int", ShaderToken.TYPE);
            AddToDictionary("double", ShaderToken.TYPE);
            AddToDictionary("float", ShaderToken.TYPE);
            AddToDictionary("string", ShaderToken.TYPE);
            AddToDictionary("bool1",ShaderToken.TYPE);
            AddToDictionary("bool2",ShaderToken.TYPE);
            AddToDictionary("bool3",ShaderToken.TYPE);
            AddToDictionary("bool4",ShaderToken.TYPE);
            AddToDictionary("int1",ShaderToken.TYPE);
            AddToDictionary("int2",ShaderToken.TYPE);
            AddToDictionary("int3",ShaderToken.TYPE);
            AddToDictionary("int4",ShaderToken.TYPE);
            AddToDictionary("uint1",ShaderToken.TYPE);
            AddToDictionary("uint2",ShaderToken.TYPE);
            AddToDictionary("uint3",ShaderToken.TYPE);
            AddToDictionary("uint4",ShaderToken.TYPE);
            AddToDictionary("half1",ShaderToken.TYPE);
            AddToDictionary("half2",ShaderToken.TYPE);
            AddToDictionary("half3",ShaderToken.TYPE);
            AddToDictionary("half4",ShaderToken.TYPE);
            AddToDictionary("float1",ShaderToken.TYPE);
            AddToDictionary("float2",ShaderToken.TYPE);
            AddToDictionary("float3",ShaderToken.TYPE);
            AddToDictionary("float4",ShaderToken.TYPE);
            AddToDictionary("double1",ShaderToken.TYPE);
            AddToDictionary("double2",ShaderToken.TYPE);
            AddToDictionary("double3",ShaderToken.TYPE);
            AddToDictionary("double4",ShaderToken.TYPE);
            AddToDictionary("vector",ShaderToken.TYPE);
            AddToDictionary("float1x1",ShaderToken.TYPE);
            AddToDictionary("float1x2",ShaderToken.TYPE);
            AddToDictionary("float1x3",ShaderToken.TYPE);
            AddToDictionary("float1x4",ShaderToken.TYPE);
            AddToDictionary("float2x1",ShaderToken.TYPE);
            AddToDictionary("float2x2",ShaderToken.TYPE);
            AddToDictionary("float2x3",ShaderToken.TYPE);
            AddToDictionary("float2x4",ShaderToken.TYPE);
            AddToDictionary("float3x1",ShaderToken.TYPE);
            AddToDictionary("float3x2",ShaderToken.TYPE);
            AddToDictionary("float3x3",ShaderToken.TYPE);
            AddToDictionary("float3x4",ShaderToken.TYPE);
            AddToDictionary("float4x1",ShaderToken.TYPE);
            AddToDictionary("float4x2",ShaderToken.TYPE);
            AddToDictionary("float4x3",ShaderToken.TYPE);
            AddToDictionary("float4x4",ShaderToken.TYPE);
            AddToDictionary("matrix",ShaderToken.TYPE);
            AddToDictionary("break",ShaderToken.KEYWORD);
            AddToDictionary("buffer",ShaderToken.KEYWORD);
            AddToDictionary("cbuffer",ShaderToken.KEYWORD);
            AddToDictionary("const",ShaderToken.KEYWORD);
            AddToDictionary("continue",ShaderToken.KEYWORD);
            AddToDictionary("discard",ShaderToken.KEYWORD);
            AddToDictionary("do",ShaderToken.KEYWORD);
            AddToDictionary("else",ShaderToken.KEYWORD);
            AddToDictionary("extern",ShaderToken.KEYWORD);
            AddToDictionary("false",ShaderToken.KEYWORD);
            AddToDictionary("for",ShaderToken.KEYWORD);
            AddToDictionary("if",ShaderToken.KEYWORD);
            AddToDictionary("in",ShaderToken.KEYWORD);
            AddToDictionary("inline",ShaderToken.KEYWORD);
            AddToDictionary("inout",ShaderToken.KEYWORD);
            AddToDictionary("namespace",ShaderToken.KEYWORD);
            AddToDictionary("nointerpolation",ShaderToken.KEYWORD);
            AddToDictionary("out",ShaderToken.KEYWORD);
            AddToDictionary("return",ShaderToken.KEYWORD);
            AddToDictionary("register",ShaderToken.KEYWORD);
            AddToDictionary("shared",ShaderToken.KEYWORD);
            AddToDictionary("stateblock",ShaderToken.KEYWORD);
            AddToDictionary("stateblock_state",ShaderToken.KEYWORD);
            AddToDictionary("static",ShaderToken.KEYWORD);
            AddToDictionary("struct",ShaderToken.KEYWORD);
            AddToDictionary("switch",ShaderToken.KEYWORD);
            AddToDictionary("tbuffer",ShaderToken.KEYWORD);
            AddToDictionary("texture",ShaderToken.KEYWORD);
            AddToDictionary("texture1d",ShaderToken.KEYWORD);
            AddToDictionary("texture1darray",ShaderToken.KEYWORD);
            AddToDictionary("texture2d",ShaderToken.KEYWORD);
            AddToDictionary("texture2darray",ShaderToken.KEYWORD);
            AddToDictionary("texture2dms",ShaderToken.KEYWORD);
            AddToDictionary("texture2dmsarray",ShaderToken.KEYWORD);
            AddToDictionary("texture3d",ShaderToken.KEYWORD);
            AddToDictionary("texturecube",ShaderToken.KEYWORD);
            AddToDictionary("texturecubearray",ShaderToken.KEYWORD);
            AddToDictionary("true",ShaderToken.KEYWORD);
            AddToDictionary("typedef",ShaderToken.KEYWORD);
            AddToDictionary("uniform",ShaderToken.KEYWORD);
            AddToDictionary("void",ShaderToken.KEYWORD);
            AddToDictionary("volatile",ShaderToken.KEYWORD);
            AddToDictionary("while",ShaderToken.KEYWORD);
            AddToDictionary("abs",ShaderToken.INTRINSIC);
            AddToDictionary("acos",ShaderToken.INTRINSIC);
            AddToDictionary("all",ShaderToken.INTRINSIC);
            AddToDictionary("any",ShaderToken.INTRINSIC);
            AddToDictionary("asfloat",ShaderToken.INTRINSIC);
            AddToDictionary("asin",ShaderToken.INTRINSIC);
            AddToDictionary("asint",ShaderToken.INTRINSIC);
            AddToDictionary("asuint",ShaderToken.INTRINSIC);
            AddToDictionary("atan",ShaderToken.INTRINSIC);
            AddToDictionary("atan2",ShaderToken.INTRINSIC);
            AddToDictionary("ceil",ShaderToken.INTRINSIC);
            AddToDictionary("clamp",ShaderToken.INTRINSIC);
            AddToDictionary("clip",ShaderToken.INTRINSIC);
            AddToDictionary("cos",ShaderToken.INTRINSIC);
            AddToDictionary("cosh",ShaderToken.INTRINSIC);
            AddToDictionary("cross",ShaderToken.INTRINSIC);
            AddToDictionary("ddx",ShaderToken.INTRINSIC);
            AddToDictionary("ddy",ShaderToken.INTRINSIC);
            AddToDictionary("degrees",ShaderToken.INTRINSIC);
            AddToDictionary("determinant",ShaderToken.INTRINSIC);
            AddToDictionary("distance",ShaderToken.INTRINSIC);
            AddToDictionary("dot",ShaderToken.INTRINSIC);
            AddToDictionary("exp",ShaderToken.INTRINSIC);
            AddToDictionary("exp2",ShaderToken.INTRINSIC);
            AddToDictionary("faceforward",ShaderToken.INTRINSIC);
            AddToDictionary("floor",ShaderToken.INTRINSIC);
            AddToDictionary("fmod",ShaderToken.INTRINSIC);
            AddToDictionary("frac",ShaderToken.INTRINSIC);
            AddToDictionary("frexp",ShaderToken.INTRINSIC);
            AddToDictionary("fwidth",ShaderToken.INTRINSIC);
            AddToDictionary("isfinite",ShaderToken.INTRINSIC);
            AddToDictionary("isinf",ShaderToken.INTRINSIC);
            AddToDictionary("isnan",ShaderToken.INTRINSIC);
            AddToDictionary("ldexp",ShaderToken.INTRINSIC);
            AddToDictionary("length",ShaderToken.INTRINSIC);
            AddToDictionary("lerp",ShaderToken.INTRINSIC);
            AddToDictionary("lit",ShaderToken.INTRINSIC);
            AddToDictionary("log",ShaderToken.INTRINSIC);
            AddToDictionary("log10",ShaderToken.INTRINSIC);
            AddToDictionary("log2",ShaderToken.INTRINSIC);
            AddToDictionary("max",ShaderToken.INTRINSIC);
            AddToDictionary("min",ShaderToken.INTRINSIC);
            AddToDictionary("modf",ShaderToken.INTRINSIC);
            AddToDictionary("mul",ShaderToken.INTRINSIC);
            AddToDictionary("noise",ShaderToken.INTRINSIC);
            AddToDictionary("normalize",ShaderToken.INTRINSIC);
            AddToDictionary("pow",ShaderToken.INTRINSIC);
            AddToDictionary("radians",ShaderToken.INTRINSIC);
            AddToDictionary("reflect",ShaderToken.INTRINSIC);
            AddToDictionary("refract",ShaderToken.INTRINSIC);
            AddToDictionary("round",ShaderToken.INTRINSIC);
            AddToDictionary("rsqrt",ShaderToken.INTRINSIC);
            AddToDictionary("saturate",ShaderToken.INTRINSIC);
            AddToDictionary("sign",ShaderToken.INTRINSIC);
            AddToDictionary("sin",ShaderToken.INTRINSIC);
            AddToDictionary("sincos",ShaderToken.INTRINSIC);
            AddToDictionary("sinh",ShaderToken.INTRINSIC);
            AddToDictionary("smoothstep",ShaderToken.INTRINSIC);
            AddToDictionary("sqrt",ShaderToken.INTRINSIC);
            AddToDictionary("step",ShaderToken.INTRINSIC);
            AddToDictionary("tan",ShaderToken.INTRINSIC);
            AddToDictionary("tanh",ShaderToken.INTRINSIC);
            AddToDictionary("tex1D",ShaderToken.INTRINSIC);
            AddToDictionary("tex1Dbias",ShaderToken.INTRINSIC);
            AddToDictionary("tex1Dgrad",ShaderToken.INTRINSIC);
            AddToDictionary("tex1Dlod",ShaderToken.INTRINSIC);
            AddToDictionary("tex1Dproj",ShaderToken.INTRINSIC);
            AddToDictionary("tex2D",ShaderToken.INTRINSIC);
            AddToDictionary("tex2Dbias",ShaderToken.INTRINSIC);
            AddToDictionary("tex2Dgrad",ShaderToken.INTRINSIC);
            AddToDictionary("tex2Dlod",ShaderToken.INTRINSIC);
            AddToDictionary("tex2Dproj",ShaderToken.INTRINSIC);
            AddToDictionary("tex3D",ShaderToken.INTRINSIC);
            AddToDictionary("tex3Dbias",ShaderToken.INTRINSIC);
            AddToDictionary("tex3Dgrad",ShaderToken.INTRINSIC);
            AddToDictionary("tex3Dlod",ShaderToken.INTRINSIC);
            AddToDictionary("tex3Dproj",ShaderToken.INTRINSIC);
            AddToDictionary("texCUBE",ShaderToken.INTRINSIC);
            AddToDictionary("texCUBEbias",ShaderToken.INTRINSIC);
            AddToDictionary("texCUBEgrad",ShaderToken.INTRINSIC);
            AddToDictionary("texCUBElod",ShaderToken.INTRINSIC);
            AddToDictionary("texCUBEproj",ShaderToken.INTRINSIC);
            AddToDictionary("transpose",ShaderToken.INTRINSIC);
            AddToDictionary("trunc",ShaderToken.INTRINSIC);
            AddToDictionary("sampler", ShaderToken.KEYWORD_FX);
            AddToDictionary("samplerstate", ShaderToken.KEYWORD_FX);
            AddToDictionary("SamplerComparisonState", ShaderToken.KEYWORD_FX);
            AddToDictionary("blendstate",ShaderToken.KEYWORD_FX);
            AddToDictionary("compile",ShaderToken.KEYWORD_FX);
            AddToDictionary("depthstencilstate",ShaderToken.KEYWORD_FX);
            AddToDictionary("depthstencilview",ShaderToken.KEYWORD_FX);
            AddToDictionary("geometryshader",ShaderToken.KEYWORD_FX);
            AddToDictionary("pass",ShaderToken.KEYWORD_FX);
            AddToDictionary("pixelshader",ShaderToken.KEYWORD_FX);
            AddToDictionary("rasterizerstate",ShaderToken.KEYWORD_FX);
            AddToDictionary("rendertargetview",ShaderToken.KEYWORD_FX);
            AddToDictionary("technique",ShaderToken.KEYWORD_FX);
            AddToDictionary("technique10",ShaderToken.KEYWORD_FX);
            AddToDictionary("vertexshader",ShaderToken.KEYWORD_FX);


            AddToSemantics("SV_ClipDistance");
            AddToSemantics("SV_ClipDistance1");
            AddToSemantics("SV_ClipDistance2");
            AddToSemantics("SV_ClipDistance3");
            AddToSemantics("SV_ClipDistance4");
            AddToSemantics("SV_ClipDistance5");
            AddToSemantics("SV_ClipDistance6");
            AddToSemantics("SV_ClipDistance7");
            AddToSemantics("SV_ClipDistance8");
            AddToSemantics("SV_ClipDistance9");
            AddToSemantics("SV_ClipDistance10");
            AddToSemantics("SV_ClipDistance11");
            AddToSemantics("SV_CullDistance");
            AddToSemantics("SV_CullDistance1");
            AddToSemantics("SV_CullDistance2");
            AddToSemantics("SV_CullDistance3");
            AddToSemantics("SV_CullDistance4");
            AddToSemantics("SV_CullDistance5");
            AddToSemantics("SV_CullDistance6");
            AddToSemantics("SV_CullDistance7");
            AddToSemantics("SV_CullDistance8");
            AddToSemantics("SV_CullDistance9");
            AddToSemantics("SV_CullDistance10");
            AddToSemantics("SV_CullDistance11");
            AddToSemantics("SV_Coverage");
            AddToSemantics("SV_Depth");
            AddToSemantics("SV_DispatchThreadID");
            AddToSemantics("SV_DomainLocation");
            AddToSemantics("SV_GroupID");
            AddToSemantics("SV_GroupIndex");
            AddToSemantics("SV_GroupThreadID");
            AddToSemantics("SV_GSInstanceID");
            AddToSemantics("SV_InsideTessFactor");
            AddToSemantics("SV_IsFrontFace");
            AddToSemantics("SV_OutputControlPointID");
            AddToSemantics("SV_Position");
            AddToSemantics("SV_RenderTargetArrayIndex");
            AddToSemantics("SV_SampleIndex");
            AddToSemantics("SV_Target0");
            AddToSemantics("SV_Target1");
            AddToSemantics("SV_Target2");
            AddToSemantics("SV_Target3");
            AddToSemantics("SV_Target4");
            AddToSemantics("SV_Target5");
            AddToSemantics("SV_Target6");
            AddToSemantics("SV_Target7");
            AddToSemantics("SV_TessFactor");
            AddToSemantics("SV_ViewportArrayIndex");
            AddToSemantics("SV_InstanceID");
            AddToSemantics("SV_PrimitiveID");
            AddToSemantics("SV_VertexID");
            AddToSemantics("BINORMAL");
            AddToSemantics("BINORMAL0");
            AddToSemantics("BINORMAL1");
            AddToSemantics("BINORMAL10");
            AddToSemantics("BINORMAL11");
            AddToSemantics("BINORMAL2");
            AddToSemantics("BINORMAL3");
            AddToSemantics("BINORMAL4");
            AddToSemantics("BINORMAL5");
            AddToSemantics("BINORMAL6");
            AddToSemantics("BINORMAL7");
            AddToSemantics("BINORMAL8");
            AddToSemantics("BINORMAL9");
            AddToSemantics("BLENDINDICES");
            AddToSemantics("BLENDINDICES0");
            AddToSemantics("BLENDINDICES1");
            AddToSemantics("BLENDINDICES10");
            AddToSemantics("BLENDINDICES11");
            AddToSemantics("BLENDINDICES2");
            AddToSemantics("BLENDINDICES3");
            AddToSemantics("BLENDINDICES4");
            AddToSemantics("BLENDINDICES5");
            AddToSemantics("BLENDINDICES6");
            AddToSemantics("BLENDINDICES7");
            AddToSemantics("BLENDINDICES8");
            AddToSemantics("BLENDINDICES9");
            AddToSemantics("BLENDWEIGHTS");
            AddToSemantics("BLENDWEIGHTS0");
            AddToSemantics("BLENDWEIGHTS1");
            AddToSemantics("BLENDWEIGHTS10");
            AddToSemantics("BLENDWEIGHTS11");
            AddToSemantics("BLENDWEIGHTS2");
            AddToSemantics("BLENDWEIGHTS3");
            AddToSemantics("BLENDWEIGHTS4");
            AddToSemantics("BLENDWEIGHTS5");
            AddToSemantics("BLENDWEIGHTS6");
            AddToSemantics("BLENDWEIGHTS7");
            AddToSemantics("BLENDWEIGHTS8");
            AddToSemantics("BLENDWEIGHTS9");
            AddToSemantics("COLOR0");
            AddToSemantics("COLOR1");
            AddToSemantics("COLOR10");
            AddToSemantics("COLOR11");
            AddToSemantics("COLOR12");
            AddToSemantics("COLOR13");
            AddToSemantics("COLOR14");
            AddToSemantics("COLOR15");
            AddToSemantics("COLOR2");
            AddToSemantics("COLOR3");
            AddToSemantics("COLOR4");
            AddToSemantics("COLOR5");
            AddToSemantics("COLOR6");
            AddToSemantics("COLOR7");
            AddToSemantics("COLOR8");
            AddToSemantics("COLOR9");
            AddToSemantics("DIFFUSE");
            AddToSemantics("DIFFUSE0");
            AddToSemantics("DIFFUSE1");
            AddToSemantics("DIFFUSE10");
            AddToSemantics("DIFFUSE11");
            AddToSemantics("DIFFUSE2");
            AddToSemantics("DIFFUSE3");
            AddToSemantics("DIFFUSE4");
            AddToSemantics("DIFFUSE5");
            AddToSemantics("DIFFUSE6");
            AddToSemantics("DIFFUSE7");
            AddToSemantics("DIFFUSE8");
            AddToSemantics("DIFFUSE9");
            AddToSemantics("FOG");
            AddToSemantics("NORMAL");
            AddToSemantics("NORMAL0");
            AddToSemantics("NORMAL1");
            AddToSemantics("NORMAL10");
            AddToSemantics("NORMAL11");
            AddToSemantics("NORMAL2");
            AddToSemantics("NORMAL3");
            AddToSemantics("NORMAL4");
            AddToSemantics("NORMAL5");
            AddToSemantics("NORMAL6");
            AddToSemantics("NORMAL7");
            AddToSemantics("NORMAL8");
            AddToSemantics("NORMAL9");
            AddToSemantics("POSITION");
            AddToSemantics("POSITION0");
            AddToSemantics("POSITION1");
            AddToSemantics("POSITION10");
            AddToSemantics("POSITION11");
            AddToSemantics("POSITION2");
            AddToSemantics("POSITION3");
            AddToSemantics("POSITION4");
            AddToSemantics("POSITION5");
            AddToSemantics("POSITION6");
            AddToSemantics("POSITION7");
            AddToSemantics("POSITION8");
            AddToSemantics("POSITION9");
            AddToSemantics("PSIZE");
            AddToSemantics("PSIZE0");
            AddToSemantics("PSIZE1");
            AddToSemantics("PSIZE10");
            AddToSemantics("PSIZE11");
            AddToSemantics("PSIZE2");
            AddToSemantics("PSIZE3");
            AddToSemantics("PSIZE4");
            AddToSemantics("PSIZE5");
            AddToSemantics("PSIZE6");
            AddToSemantics("PSIZE7");
            AddToSemantics("PSIZE8");
            AddToSemantics("PSIZE9");
            AddToSemantics("SPECULAR");
            AddToSemantics("SPECULAR0");
            AddToSemantics("SPECULAR1");
            AddToSemantics("SPECULAR10");
            AddToSemantics("SPECULAR11");
            AddToSemantics("SPECULAR2");
            AddToSemantics("SPECULAR3");
            AddToSemantics("SPECULAR4");
            AddToSemantics("SPECULAR5");
            AddToSemantics("SPECULAR6");
            AddToSemantics("SPECULAR7");
            AddToSemantics("SPECULAR8");
            AddToSemantics("SPECULAR9");
            AddToSemantics("TANGENT");
            AddToSemantics("TANGENT0");
            AddToSemantics("TANGENT1");
            AddToSemantics("TANGENT10");
            AddToSemantics("TANGENT11");
            AddToSemantics("TANGENT2");
            AddToSemantics("TANGENT3");
            AddToSemantics("TANGENT4");
            AddToSemantics("TANGENT5");
            AddToSemantics("TANGENT6");
            AddToSemantics("TANGENT7");
            AddToSemantics("TANGENT8");
            AddToSemantics("TANGENT9");
            AddToSemantics("TESSFACTOR");
            AddToSemantics("TESSFACTOR0");
            AddToSemantics("TESSFACTOR1");
            AddToSemantics("TESSFACTOR10");
            AddToSemantics("TESSFACTOR11");
            AddToSemantics("TESSFACTOR2");
            AddToSemantics("TESSFACTOR3");
            AddToSemantics("TESSFACTOR4");
            AddToSemantics("TESSFACTOR5");
            AddToSemantics("TESSFACTOR6");
            AddToSemantics("TESSFACTOR7");
            AddToSemantics("TESSFACTOR8");
            AddToSemantics("TESSFACTOR9");
            AddToSemantics("TEXCOORD");
            AddToSemantics("TEXCOORD0");
            AddToSemantics("TEXCOORD1");
            AddToSemantics("TEXCOORD10");
            AddToSemantics("TEXCOORD11");
            AddToSemantics("TEXCOORD12");
            AddToSemantics("TEXCOORD13");
            AddToSemantics("TEXCOORD14");
            AddToSemantics("TEXCOORD15");
            AddToSemantics("TEXCOORD19");
            AddToSemantics("TEXCOORD2");
            AddToSemantics("TEXCOORD3");
            AddToSemantics("TEXCOORD4");
            AddToSemantics("TEXCOORD5");
            AddToSemantics("TEXCOORD6");
            AddToSemantics("TEXCOORD7");
            AddToSemantics("TEXCOORD8");
            AddToSemantics("TEXCOORD9");
            AddToSemantics("VFACE");
            AddToSemantics("VPOS");
        }

        public ShaderToken GetTokenFromSemantics(string text)
        {
            text = text.Substring(1, text.Length - 1);
            text = text.Replace(" ", "");
            ShaderToken token;
            if (!mapSemantics.TryGetValue(text.ToLower(), out token))
            {
                token = ShaderToken.IDENTIFIER;
            }
            return token;
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