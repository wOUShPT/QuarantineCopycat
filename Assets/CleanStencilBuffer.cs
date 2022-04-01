using UnityEngine;

public class CleanStencilBuffer : MonoBehaviour
{
    [ExecuteAlways]
    void Update()
    {
        Camera.main.clearStencilAfterLightingPass = true;
    }
}
