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
using System;

namespace NShader
{
    static class GuidList
    {
        public const string guidNShaderPkgString = "dd9b8cde-96a0-4442-bf6f-083a7f43d453";
        public const string guidNShaderCmdSetString = "79e82a67-e862-42df-ab79-d496ec57cf48";
        public const string guidNShaderLanguageService = "E1E045DA-7E8D-4DA1-94CC-93E9A1C1E289";
        public const string guidNShaderEditorFactory = "3224B0DB-6280-470B-B57A-D6E31B8A5856";

        public static readonly Guid guidNShaderCmdSet = new Guid(guidNShaderCmdSetString);
    };
}