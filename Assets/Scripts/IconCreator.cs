using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class IconCreator : MonoBehaviour
{
    private Camera camera;

    public string fileName;

    public string pathFolder;

    [ContextMenu("CreateIcon")]
    public void TakeScreenshot()
    {
        Screenshot(pathFolder+ "/" + fileName +".png");
    }
    
    public void Screenshot(string fullpath)
    {
        if (camera == null)
        {
            camera = Camera.main;
        }

        RenderTexture rt = new RenderTexture(2048, 2048, 24);
        camera.targetTexture = rt;
        Texture2D screenshot = new Texture2D(2048, 2048, TextureFormat.RGBA32, false);
        camera.Render();
        RenderTexture.active = rt;
        screenshot.ReadPixels(new Rect(0, 0, 2048, 2048), 0, 0);
        camera.targetTexture = null;
        RenderTexture.active = null;

        if (Application.isEditor)
        {
            DestroyImmediate(rt);
        }
        else
        {
            Destroy(rt);
        }

        byte[] bytes = screenshot.EncodeToPNG();
        System.IO.File.WriteAllBytes(fullpath, bytes);
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}
