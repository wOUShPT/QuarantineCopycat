using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemSpot))]
public class ItemSpotEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        ItemSpot itemSpot = (ItemSpot)target;
        EditorGUILayout.PropertyField(serializedObject.FindProperty("interactionDistance"));
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("dropObjectType"));

        switch (itemSpot.DropObjectType)
        {
            case PickUpItemBehaviour.PickUpObjectType.Book:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("childrenItemSpot"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Cloth:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("holderPositionArray"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("maxNumberCloths"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Disk:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("diskParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Any:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("childrenItemSpot"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Bread:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("breadParams"));
                break;
            default:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("childrenItemSpot"));
                break;
        }
        serializedObject.ApplyModifiedProperties();

    }
}
