using UnityEngine;

public class ToggleGameObjectWithButton : MonoBehaviour
{
    // Drag your GameObject into this field in the inspector
    public GameObject targetObject;

    // This method will be called when the button is clicked
    public void ToggleObject()
    {
        if (targetObject != null)
        {
            // Toggle the active state of the targetObject
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}
