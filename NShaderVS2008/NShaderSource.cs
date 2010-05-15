using System.Collections.Generic;
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace NShader
{
    public class NShaderSource : Source
    {
        public NShaderSource(LanguageService service, IVsTextLines textLines, Colorizer colorizer) : base(service, textLines, colorizer)
        {
        }

        private void DoFormatting(EditArray mgr, TextSpan span)
        {
            // Make sure there is one space after every comma unless followed
            // by a tab or comma is at end of line.
            IVsTextLines pBuffer = GetTextLines();
            if (pBuffer != null)
            {
//                List<EditSpan> changeList = new List<EditSpan>();

                // BETA DISABLED
                List<EditSpan> changeList = NShaderFormatHelper.ReformatCode(pBuffer, span, LanguageService.GetLanguagePreferences().TabSize);
                foreach (EditSpan editSpan in changeList)
                {
                    // Add edit operation
                    mgr.Add(editSpan);
                }
                // Apply all edits
                mgr.ApplyEdits();
            }
        }

        public override void ReformatSpan(EditArray mgr, TextSpan span)
        {
            string description = "Reformat code";
            CompoundAction ca = new CompoundAction(this, description);
            using (ca)
            {
                ca.FlushEditActions();      // Flush any pending edits
                DoFormatting(mgr, span);    // Format the span
            }
        }
    }
}