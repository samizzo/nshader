using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Package;
 
namespace NShader
{
    [Guid(GuidList.guidNShaderEditorFactory)]
    public class NShaderEditorFactory : EditorFactory
    {
        public NShaderEditorFactory(Package package) :
        base(package)
        {
        }

        public override Guid GetLanguageServiceGuid()
        {
            return new Guid(GuidList.guidNShaderLanguageService);
        }
    }
}
