using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace TMPro.EditorUtilities
{
    public class AdvancedDissolve_TMP_Default : ShaderGUI
    {
        public override void OnGUI(UnityEditor.MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            base.OnGUI(materialEditor, properties);


            //AmazingAssets
            AmazingAssets.AdvancedDissolveEditor.MaterialEditor.Init(properties);

            //AmazingAssets
            AmazingAssets.AdvancedDissolveEditor.MaterialEditor.DrawDissolveOptions(materialEditor, false, false, false, false, false);
        }
    }
}