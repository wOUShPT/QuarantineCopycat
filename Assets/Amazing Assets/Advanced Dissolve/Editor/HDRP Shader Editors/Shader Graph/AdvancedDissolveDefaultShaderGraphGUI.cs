using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace AmazingAssets.AdvancedDissolveEditor.ShaderGraph
{
    public class DefaultShaderGraphGUI : ShaderGUI
    {
        public override void OnGUI(UnityEditor.MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            if (AmazingAssets.AdvancedDissolveEditor.MaterialEditor.DrawDefaultOptionsHeader("Default Shader Options", null, null))
                base.OnGUI(materialEditor, properties);


            //AmazingAssets
            AmazingAssets.AdvancedDissolveEditor.MaterialEditor.Init(properties);

            //AmazingAssets
            AmazingAssets.AdvancedDissolveEditor.MaterialEditor.DrawDissolveOptions(materialEditor, true, true, false, true, true);
        }
    }
}