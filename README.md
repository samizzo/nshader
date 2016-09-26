## NShader

[![Build status](https://ci.appveyor.com/api/projects/status/bpes19itxgnynpas/branch/master?svg=true)](https://ci.appveyor.com/project/izzo/nshader/branch/master)

This is a fork of Issam Khalil's Visual Studio 2013 fork of Alexandre Mutel's NShader syntax highlighting Visual Studio extension for shader languages.
I've cloned it into my own github repository as I prefer to use github rather than CodePlex. The original nshader project is available here:

https://nshader.codeplex.com/

I have made some changes to Issam's version. You may now override the file type detection by specifying, on the first line of a shader file, a comment
like so:

    // shadertype=<type>

where `<type>` is one of:

    hlsl
    glsl
    cg
    unity

This will force the file to use the specified syntax highlighter. This is case sensitive and must appear exactly as above. Otherwise if the `shadertype`
tag is not present, the file extension will be used to decide what type of highlighting to use. The extension mapping is as follows:

    HLSL syntax highlighter - .fx, .fxh, .hlsl, .vsh, .psh, .fsh, .usf, .slfx
    GLSL syntax highlighter - .glsl, .frag, .vert, .fp, .vp, .geom, .xsh, .comp, .sfx
    CG syntax highlighter - .cg, .cgfx
    Unity syntax highlighter - .shader, .cginc, .compute

You can also add extra extensions in Tools->Options->Text Editor->File Extension. Type in the file extension, select "NShader Editor" in the dropdown, and
click "Add". Then when you open a file with any of those extensions they will use the NShader syntax highlighter. It seems that there is a bug in at least
Visual Studio 2013 and possibly earlier versions where the setting can be forgotten and when you open a file in the list the syntax highlighting is not
applied. However, the extension still appears in the list. To work around this you must remove and re-add the extension to the list. Also in Visual Studio
2015 if you load a file from the "recently used" list it doesn't seem to use the syntax highlighter, but if you load it from elsewhere (e.g. file->open or
the Solution Explorer) it will work. This seems like a bug in Visual Studio, because it worked in VS 2013.

Note that if you add a file extension or use the `shadertype` tag you will need to close and re-open any currently open files to reflect the changes.

The existing file extensions that NShader previously recognised are still recognised, so if you are using any of those file types you don't have to do
anything extra.

The user keyword mapping files now override the built-in mappings (in Issam's version duplicates were ignored). NShader will look inside %APPDATA%\NShader
for custom map files with the following names:

    GLSLKeywords.map
    HLSLKeywords.map
    UNITYKeywords.map

Any keywords in these files will replace the built-in mapping. For example, if `float` is mapped as a `type` in the built-in mapping, it can be changed
to a `keyword` by adding it to the override file. Note that the CG highlighter is the same as the HLSL highlighter, so it doesn't have its own mapping.
I've also made some small changes to the built-in mappings so that certain keywords are now 'types' instead of 'keywords'.

Finally, there is now an additional colour setting for the 'type' keywords (available in the Fonts and Colors dialog).

The latest build is available from Github in the releases section:

https://github.com/samizzo/nshader

The above build can be used to install NShader in both VS 2013 and 2015.

This README and the built-in mappings are available in the zip file for reference.
