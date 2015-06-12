## NShader

This is a clone of Issam Khalil's Visual Studio 2013 fork of Alexandre Mutel's NShader syntax highlighting Visual Studio extension for shader languages.

I've cloned it into my own github repository as I prefer to use github rather than CodePlex.

The original nshader project is available here:

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

    HLSL syntax highlighter - .fx, .fxh, .hlsl, .vsh, .psh, .fsh
    GLSL syntax highlighter - .glsl, .frag, .vert, .fp, .vp, .geom
    CG syntax highlighter - .cg, .cgfx
    Unity syntax highlighter - .shader, .cginc, .compute

The other major change is that the keyword mapping files are now installed alongside the extension and always used.

I've also made some small changes to the mappings so that certain keywords are now 'types' instead of 'keywords'.

Finally, there is now an additional colour setting for the 'type' keywords (available in the Fonts and Colors dialog).
