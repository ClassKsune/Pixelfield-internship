using UnityEngine;
using TMPro;

public class SaveManager : MonoBehaviour
{
    public TMP_InputField gravityInput;
    public TMP_InputField dragInput;
    public TMP_InputField angularDragInput;

    private const string GravityKey = "Gravity";
    private const string DragKey = "Drag";
    private const string AngularDragKey = "AngularDrag";

    public void ChooseSaveOption() {
      
    }



    /// Saves the float values from the input fields using PlayerPrefs.
    public void SaveData()
    {
        // Parse the input fields to floats and save them using PlayerPrefs
        float gravity = float.Parse(gravityInput.text);
        float drag = float.Parse(dragInput.text);
        float angularDrag = float.Parse(angularDragInput.text);

        PlayerPrefs.SetFloat(GravityKey, gravity);
        PlayerPrefs.SetFloat(DragKey, drag);
        PlayerPrefs.SetFloat(AngularDragKey, angularDrag);

        PlayerPrefs.Save();  // Make sure to save the data to disk
        Debug.Log("Data saved!");
    }

    /// Loads the saved float values from PlayerPrefs and updates the input fields.
    public void LoadData()
    {
        // Check if data exists and load it
        if (PlayerPrefs.HasKey(GravityKey) && PlayerPrefs.HasKey(DragKey) && PlayerPrefs.HasKey(AngularDragKey))
        {
            float gravity = PlayerPrefs.GetFloat(GravityKey);
            float drag = PlayerPrefs.GetFloat(DragKey);
            float angularDrag = PlayerPrefs.GetFloat(AngularDragKey);

            // Set the input fields to the loaded values
            gravityInput.text = gravity.ToString();
            dragInput.text = drag.ToString();
            angularDragInput.text = angularDrag.ToString();

            Debug.Log("Data loaded!");
        }
        else
        {
            Debug.LogWarning("No saved data found.");
        }
    }
}

