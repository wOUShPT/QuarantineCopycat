using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    private GameManager _gameManager;
    private InputManager _inputManager;
    void Awake()
    {
        _inputManager = new InputManager();
        _gameManager = new GameManager();
        _inputManager.transform.SetParent(GameObject.Find("Managers").transform);
        _gameManager.transform.SetParent(GameObject.Find("Managers").transform);
    }
    
}
