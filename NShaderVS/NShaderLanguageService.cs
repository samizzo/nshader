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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.Win32;

namespace NShader
{
    [Guid(GuidList.guidNShaderLanguageService)]
    public class NShaderLanguageService : LanguageService
    {
        private ColorableItem[] m_colorableItems;

        private LanguagePreferences m_preferences;

        //Make sure this match the new ColorableItem below
        public enum ColorID
        {
            Intrinsic = 6,
            Special,
            Preprocessor,
            Type,
            Unity_Structure,
            Unity_Type,
            Unity_Value,
            Unity_Fixed,
        }

        public NShaderLanguageService()
        {
            //You might need to clean VS experimental instance if changing this : http://blog.majcica.com/tag/createexpinstance/
            //http://msdn.microsoft.com/en-us/library/dd875761.aspx
            m_colorableItems = new ColorableItem[]
            {
                new NShaderColorableItem("NShader - PLAIN TEXT", COLORINDEX.CI_BLUE, COLORINDEX.CI_USERTEXT_BK, System.Drawing.Color.CornflowerBlue, System.Drawing.Color.Empty),
                new NShaderColorableItem("NShader - Keyword", COLORINDEX.CI_BLUE, COLORINDEX.CI_USERTEXT_BK, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Empty),
                new NShaderColorableItem("NShader - Comment", COLORINDEX.CI_DARKGREEN, COLORINDEX.CI_USERTEXT_BK, System.Drawing.Color.DarkGreen, System.Drawing.Color.Empty),
                new NShaderColorableItem("NShader - Identifier", COLORINDEX.CI_SYSPLAINTEXT_FG, COLORINDEX.CI_USERTEXT_BK),
                new NShaderColorableItem("NShader - String",COLORINDEX.CI_RED, COLORINDEX.CI_USERTEXT_BK, System.Drawing.Color.Crimson, System.Drawing.Color.Empty),
                new NShaderColorableItem("NShader - Number", COLORINDEX.CI_DARKBLUE, COLORINDEX.CI_USERTEXT_BK, System.Drawing.Color.Aqua, System.Drawing.Color.Empty),
                new NShaderColorableItem("NShader - Intrinsic", COLORINDEX.CI_MAROON, COLORINDEX.CI_USERTEXT_BK, System.Drawing.Color.Maroon, System.Drawing.Color.Empty, FONTFLAGS.FF_BOLD), //6
                new NShaderColorableItem("NShader - Special", COLORINDEX.CI_AQUAMARINE, COLORINDEX.CI_USERTEXT_BK, System.Drawing.Color.MediumBlue, System.Drawing.Color.Empty),        //7
                new NShaderColorableItem("NShader - Preprocessor", COLORINDEX.CI_DARKGRAY, COLORINDEX.CI_USERTEXT_BK, System.Drawing.Color.DimGray, System.Drawing.Color.Empty),        //8
                new NShaderColorableItem("NShader - Type", COLORINDEX.CI_GREEN, COLORINDEX.CI_USERTEXT_BK, System.Drawing.Color.Green, System.Drawing.Color.Empty),        //9
                new NShaderColorableItem("NShader - Unity - Structure", COLORINDEX.CI_MAROON, COLORINDEX.CI_USERTEXT_BK, System.Drawing.Color.Blue, System.Drawing.Color.Empty, FONTFLAGS.FF_BOLD), //10
                new NShaderColorableItem("NShader - Unity - Type", COLORINDEX.CI_AQUAMARINE, COLORINDEX.CI_USERTEXT_BK, System.Drawing.Color.DodgerBlue, System.Drawing.Color.Empty),        //11
                new NShaderColorableItem("NShader - Unity - Value", COLORINDEX.CI_DARKGRAY, COLORINDEX.CI_USERTEXT_BK, System.Drawing.Color.Maroon, System.Drawing.Color.Empty),        //12
                new NShaderColorableItem("NShader - Unity - Fixed", COLORINDEX.CI_DARKGRAY, COLORINDEX.CI_USERTEXT_BK, System.Drawing.Color.Maroon, System.Drawing.Color.Empty),        //13
            };
        }


        public override int GetItemCount(out int count)
        {
            count = m_colorableItems.Length - 1;   // -1 because the PLAIN TEXT is not included
            return VSConstants.S_OK;
        }

        public override int GetColorableItem(int index, out IVsColorableItem item)
        {
            if (index < 1)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            item = m_colorableItems[index];
            return VSConstants.S_OK;
        }

        public override LanguagePreferences GetLanguagePreferences()
        {
            if (m_preferences == null)
            {
                m_preferences = new LanguagePreferences(this.Site,
                                                        typeof(NShaderLanguageService).GUID,
                                                        this.Name);
                m_preferences.Init();
            }
            return m_preferences;
        }

        public override IScanner GetScanner(IVsTextLines buffer)
        {
            string filePath = FilePathUtilities.GetFilePath(buffer);
            // Return dynamic scanner based on file extension
            return NShaderScannerFactory.GetShaderScanner(filePath);
        }

        public override int GetFileExtensions(out string extensions)
        {
            extensions = NShaderSupportedExtensions.HLSL_FX + ";" + NShaderSupportedExtensions.HLSL_HLSL + ";" + NShaderSupportedExtensions.HLSL_PSH;
            return VSConstants.S_OK;
        }

        public override Source CreateSource(IVsTextLines buffer)
        {
            return new NShaderSource(this, buffer, GetColorizer(buffer));
        }

        public override AuthoringScope ParseSource(ParseRequest req)
        {
            // req.FileName
            return new TestAuthoringScope();
        }

        public override string GetFormatFilterList()
        {
            return "";
        }

        public override string Name
        {
            get { return "NShader"; }
        }


        /// <summary>
        /// Verify that system colorizer settings are initialized
        /// </summary>
        public override Colorizer GetColorizer(IVsTextLines buffer)
        {
            //"{E0187991-B458-4F7E-8CA9-42C9A573B56C}"

            return base.GetColorizer(buffer);
        }
    


        internal class TestAuthoringScope : AuthoringScope
        {
            public override string GetDataTipText(int line, int col, out TextSpan span)
            {
                span = new TextSpan();
                return null;
            }

            public override Declarations GetDeclarations(IVsTextView view,
                                                         int line,
                                                         int col,
                                                         TokenInfo info,
                                                         ParseReason reason)
            {
                return null;
            }

            public override Methods GetMethods(int line, int col, string name)
            {
                return null;
            }


            public override string Goto(VSConstants.VSStd97CmdID cmd, IVsTextView textView, int line, int col, out TextSpan span)
            {
                span = new TextSpan();
                return null;
            }
        }

    }
}