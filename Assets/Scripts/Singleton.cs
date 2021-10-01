using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
 {
     private static T instance;
     public static T Instance
     {
         get
         {
             if (instance == null)
                 instance = FindObjectOfType<T>();
             if (instance == null)
                 Debug.LogError("Singleton<" + typeof(T) + "> instance has been not found.");
             return instance;
         }
     }
 
     protected void Awake()
     {
         if (instance == null)
             instance = this as T;
         else if (instance != this)
             DestroySelf();
     }
 
     protected void OnValidate()
     {
         if (instance == null)
             instance = this as T;
         else if (instance != this)
         {
             Debug.LogError("Singleton<"+this.GetType() + "> already has an instance on scene. Component will be destroyed.");
             #if UNITY_EDITOR
             UnityEditor.EditorApplication.delayCall -= DestroySelf;
             UnityEditor.EditorApplication.delayCall += DestroySelf;    
             #endif
         }
     }
 
    
     private void DestroySelf()
     {
         if(Application.isPlaying)
             Destroy(this);
         else
             DestroyImmediate(this);
     }
 }
