using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCamera : MonoBehaviour
{
    public Transform cameraPivot;
    public float sensitivityX;
    public float sensitivityY;
    private Vector2 _rotation;
    void Start()
    {
        _rotation.x = cameraPivot.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        //InputManager.Instance.PlayerInput.Look
    }
}
