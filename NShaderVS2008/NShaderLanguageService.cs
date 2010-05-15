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
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace NShader
{
    public class NShaderLanguageService : LanguageService
    {
        private ColorableItem[] m_colorableItems;

        private LanguagePreferences m_preferences;

        public NShaderLanguageService()
        {
            m_colorableItems = new ColorableItem[]
                                   {
                                        new NShaderColorableItem("Keyword", "Shader Language - Keyword", COLORINDEX.CI_BLUE, COLORINDEX.CI_USERTEXT_BK),
                                        new NShaderColorableItem("Comment", "Shader Language - Comment", COLORINDEX.CI_DARKGREEN, COLORINDEX.CI_USERTEXT_BK),
                                        new NShaderColorableItem("Identifier", "Shader Language - Identifier", COLORINDEX.CI_SYSPLAINTEXT_FG, COLORINDEX.CI_USERTEXT_BK),
                                        new NShaderColorableItem("String", "Shader Language - String", COLORINDEX.CI_RED, COLORINDEX.CI_USERTEXT_BK),
                                        new NShaderColorableItem("Number", "Shader Language - Number", COLORINDEX.CI_DARKBLUE, COLORINDEX.CI_USERTEXT_BK),
                                        new NShaderColorableItem("Intrinsic", "Shader Language - Intrinsic", COLORINDEX.CI_MAROON, COLORINDEX.CI_USERTEXT_BK, FONTFLAGS.FF_BOLD),
                                        new NShaderColorableItem("Special", "Shader Language - Special", COLORINDEX.CI_AQUAMARINE, COLORINDEX.CI_USERTEXT_BK),
                                        new NShaderColorableItem("Preprocessor", "Shader Language - Preprocessor", COLORINDEX.CI_DARKGRAY, COLORINDEX.CI_USERTEXT_BK),
                                   };
        }


        public override int GetItemCount(out int count)
        {
            count = m_colorableItems.Length;
            return VSConstants.S_OK;
        }

        public override int GetColorableItem(int index, out IVsColorableItem item)
        {
            if (index < 1)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            item = m_colorableItems[index-1];
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
            return NShaderScannerFactory.GetScannerFromFilename(filePath);
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
            get { return "Shader Language"; }
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