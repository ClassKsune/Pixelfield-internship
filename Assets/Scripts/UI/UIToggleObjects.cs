using UnityEngine;

public class UIToggleObjects : MonoBehaviour
{
    [Header("Objects to Toggle")]
    public GameObject[] objectsToDisable;  /// List of objects to disable
    public GameObject[] objectsToEnable;   /// List of objects to enable
    
    public void ToggleObjects(int index)
    {
        // The index is within bounds for both arrays
        if (index >= 0 && index < objectsToDisable.Length && index < objectsToEnable.Length)
        {
            /// Disable the object at the specified index
            if (objectsToDisable[index] != null)
            {
                objectsToDisable[index].SetActive(false);
            }

            /// Enable the object at the specified index
            if (objectsToEnable[index] != null)
            {
                objectsToEnable[index].SetActive(true);
            }
        }
        else
        {
            Debug.LogError("Index out of bounds for objectsToDisable or objectsToEnable arrays.");
        }
    }
}

