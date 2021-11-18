using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PickUpItemBehaviour), true)]
[CanEditMultipleObjects]
public class PickUpItemBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        PickUpItemBehaviour pickUpItemBehaviour = (PickUpItemBehaviour)target;

        EditorGUILayout.PropertyField(serializedObject.FindProperty("interactionDistance"));
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("objectType"));

        switch (pickUpItemBehaviour.ObjectType)
        {
            case PickUpItemBehaviour.PickUpObjectType.Book:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("bookParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Cloth:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("clothParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Disk:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("diskParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Bread:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("breadParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Coffee:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("coffeeParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Toothbrush:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("brushParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.WateringCan:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("wateringCanParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Plate:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("plateParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Food:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("foodParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Any:
                break;
        }
        serializedObject.ApplyModifiedProperties();
    }
}
