using System;
using System.Resources;
using Microsoft.VisualStudio.Shell;

namespace NShader
{
    public class ProvideFileExtensionMappingAttribute : RegistrationAttribute
    {
        #region Private state

        private string m_id;
        private string m_name;
        private string m_nameId;
        private string m_editorGuid;
        private string m_packageGuid;
        private int m_sortPriority;

        #endregion

        public ProvideFileExtensionMappingAttribute(string id, int nameId, Type editor, Type package, int sortPriority)
        {
            var rm = new ResourceManager("NShader.VSPackage2010", System.Reflection.Assembly.GetExecutingAssembly());
            m_id = id;
            m_name = rm.GetString(nameId.ToString());
            m_nameId = "#" + nameId.ToString();
            m_editorGuid = editor.GUID.ToString("B");
            m_packageGuid = package.GUID.ToString("B");
            m_sortPriority = sortPriority;
        }

        public override void Register(RegistrationContext context)
        {
            using (var key = context.CreateKey(@"FileExtensionMapping\" + m_id))
            {
                key.SetValue("", m_name);
                key.SetValue("DisplayName", m_nameId);
                key.SetValue("EditorGuid", m_editorGuid);
                key.SetValue("Package", m_packageGuid);
                key.SetValue("SortPriority", m_sortPriority);
            }
        }

        public override void Unregister(RegistrationContext context)
        {
        }
    }
}
