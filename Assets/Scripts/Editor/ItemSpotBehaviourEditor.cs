
using UnityEditor;
[CustomEditor(typeof(ItemSpotBehaviour), true)] //True cause can be for his child as well
public class ItemSpotBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        ItemSpotBehaviour itemSpot = (ItemSpotBehaviour)target;
        EditorGUILayout.PropertyField(serializedObject.FindProperty("interactionDistance"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("dropObjectType"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("childrenItemSpot"));
        switch (itemSpot.DropObjectType)
        {
            case PickUpItemBehaviour.PickUpObjectType.Book:
                break;
            case PickUpItemBehaviour.PickUpObjectType.Cloth:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("holderPositionArray"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("maxNumberCloths"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Disk:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("diskParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Any:
                break;
            case PickUpItemBehaviour.PickUpObjectType.Bread:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("breadParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Coffee:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("coffeeMachineParams"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Plate:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("maxNumberPlates"));
                break;
            case PickUpItemBehaviour.PickUpObjectType.Food:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("fridgeParams"));
                break;
            default:
                break;
        }
        EditorGUILayout.PropertyField(serializedObject.FindProperty("otherGameobjectOutlineArray"));
        serializedObject.ApplyModifiedProperties();
    }
}
