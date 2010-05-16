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
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace NShader
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    ///
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the 
    /// IVsPackage interface and uses the registration attributes defined in the framework to 
    /// register itself and its components with the shell.
    /// </summary>
    // This attribute tells the registration utility (regpkg.exe) that this class needs
    // to be registered as package.
    [PackageRegistration(UseManagedResourcesOnly = true)]
    // A Visual Studio component can be registered under different regitry roots; for instance
    // when you debug your package you want to register it in the experimental hive. This
    // attribute specifies the registry root to use if no one is provided to regpkg.exe with
    // the /root switch.
#if VISUAL_STUDIO_2010
    [DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\10.0")]
#else
    [DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\9.0")]
#endif
    // This attribute is used to register the informations needed to show the this package
    // in the Help/About dialog of Visual Studio.
    // Loaded from Package IVsInstalledProduct methods
#if !VISUAL_STUDIO_2010
    [InstalledProductRegistration(true, "#110", "#112", NShaderVersion.VERSION, IconResourceID = 400)]
#endif
    //[InstalledProductRegistration(true, null, null, null)]
    // In order be loaded inside Visual Studio in a machine that has not the VS SDK installed, 
    // package needs to have a valid load key (it can be requested at 
    // http://msdn.microsoft.com/vstudio/extend/). This attributes tells the shell that this 
    // package has a load key embedded in its resources.
#if !VISUAL_STUDIO_2010
    [ProvideLoadKey("Standard", NShaderVersion.VERSION, "NShader", "Alexandre Mutel", 113)]
#endif
    [ProvideService(typeof(NShaderLanguageService), ServiceName = "Shader Language Service")]
    [ProvideLanguageServiceAttribute(typeof(NShaderLanguageService),
                             "Shader Language",
                             0,
                             EnableCommenting = true,
                             EnableFormatSelection =  true,
                             EnableLineNumbers =  true                             
        //RequestStockColors = false
                             )]
    [ProvideLanguageExtensionAttribute(typeof(NShaderLanguageService), NShaderSupportedExtensions.HLSL_FX)]
    [ProvideLanguageExtensionAttribute(typeof(NShaderLanguageService), NShaderSupportedExtensions.HLSL_HLSL)]
    [ProvideLanguageExtensionAttribute(typeof(NShaderLanguageService), NShaderSupportedExtensions.HLSL_VSH)]
    [ProvideLanguageExtensionAttribute(typeof(NShaderLanguageService), NShaderSupportedExtensions.HLSL_PSH)]
    [ProvideLanguageExtensionAttribute(typeof(NShaderLanguageService), NShaderSupportedExtensions.GLSL_FRAG)]
    [ProvideLanguageExtensionAttribute(typeof(NShaderLanguageService), NShaderSupportedExtensions.GLSL_VERT)]
    [ProvideLanguageExtensionAttribute(typeof(NShaderLanguageService), NShaderSupportedExtensions.GLSL_FP)]
    [ProvideLanguageExtensionAttribute(typeof(NShaderLanguageService), NShaderSupportedExtensions.GLSL_VP)]
    [ProvideLanguageExtensionAttribute(typeof(NShaderLanguageService), NShaderSupportedExtensions.GLSL_GEOM)]
    [ProvideLanguageExtensionAttribute(typeof(NShaderLanguageService), NShaderSupportedExtensions.GLSL_GLSL)]
    [ProvideLanguageExtensionAttribute(typeof(NShaderLanguageService), NShaderSupportedExtensions.CG_CG)]
    [ProvideLanguageExtensionAttribute(typeof(NShaderLanguageService), NShaderSupportedExtensions.CG_CGFX)]
    [Guid(GuidList.guidNShaderPkgString)]
    public sealed class NShader : Package, IVsInstalledProduct
    {
        /// <summary>
        /// Default constructor of the package.
        /// Inside this method you can place any initialization code that does not require 
        /// any Visual Studio service because at this point the package object is created but 
        /// not sited yet inside Visual Studio environment. The place to do all the other 
        /// initialization is the Initialize method.
        /// </summary>
        public NShader()
        {
            Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Entering constructor for: {0}", this.ToString()));
        }

        /////////////////////////////////////////////////////////////////////////////
        // Overriden Package Implementation
        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initilaization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            Trace.WriteLine (string.Format(CultureInfo.CurrentCulture, "Entering Initialize() of: {0}", this.ToString()));
            base.Initialize();

            // Proffer the service.
            IServiceContainer serviceContainer = this as IServiceContainer;
            NShaderLanguageService langService = new NShaderLanguageService();
            langService.SetSite(this);
            serviceContainer.AddService(typeof(NShaderLanguageService),
                                        langService,
                                        true);

        }
        #endregion

        #region Implementation of IVsInstalledProduct

        public int IdBmpSplash(out uint pIdBmp)
        {
            pIdBmp = 0;
            return VSConstants.S_OK;
        }

        public int OfficialName(out string pbstrName)
        {
            pbstrName = VSPackageResourceManager.GetString("110");
            return VSConstants.S_OK;
        }

        public int ProductID(out string pbstrPID)
        {
            pbstrPID = NShaderVersion.VERSION;
            return VSConstants.S_OK;
        }

        public int ProductDetails(out string pbstrProductDetails)
        {
            pbstrProductDetails =  VSPackageResourceManager.GetString("112");
            return VSConstants.S_OK;
        }

        public int IdIcoLogoForAboutbox(out uint pIdIco)
        {
            pIdIco = 400;
            return VSConstants.S_OK;
        }

        private static System.Resources.ResourceManager resourceMan;


        internal static System.Resources.ResourceManager VSPackageResourceManager
        {
            get
            {
                if (ReferenceEquals(resourceMan, null))
                {
                    resourceMan = new System.Resources.ResourceManager("NShader.VSPackage", typeof(NShader).Assembly);
                }
                return resourceMan;
            }
        }

        #endregion
    }
}