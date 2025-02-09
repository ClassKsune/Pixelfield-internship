using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;

public class LoadData : MonoBehaviour
{

    private string userID;
    private DatabaseReference dbRef;
    public DatabaseManager manager;

    public string filePath;

    public TMP_InputField gravity, drag, angularDrag;


    void Start()
    {
      dbRef = FirebaseDatabase.DefaultInstance.RootReference;
      userID = SystemInfo.deviceUniqueIdentifier;  
    
      filePath = Application.persistentDataPath + "/saveData.json";
      Invoke(nameof(SaveLocalData), 1f);
    }

  public void LoadUserDatabase() {
    dbRef.Child("users").Child(userID).GetValueAsync().ContinueWithOnMainThread(task => 
    {
      if (task.IsFaulted || task.IsCanceled)
      { 
        LoadUserData();
      } 
      else
      {
          Debug.Log("Loaded Database Data");
          manager.GetData();
      }
    });
  }

public void SaveLocalData() 
{
    float parsedGravity, parsedDrag, parsedAngularDrag;

    if (!float.TryParse(gravity.text, out parsedGravity))
        parsedGravity = -9.81f;

    if (!float.TryParse(drag.text, out parsedDrag))
        parsedDrag = 0.5f;

    if (!float.TryParse(angularDrag.text, out parsedAngularDrag))
        parsedAngularDrag = 0.05f;

    GameData data = new GameData(parsedGravity, parsedDrag, parsedAngularDrag);
    string json = JsonUtility.ToJson(data, true);
    File.WriteAllText(filePath, json);

    PlayerPrefs.SetFloat("gravity", parsedGravity);
    PlayerPrefs.SetFloat("drag", parsedDrag);
    PlayerPrefs.SetFloat("angularDrag", parsedAngularDrag);
    PlayerPrefs.Save();

    Debug.Log("Saved Locally");
}


  public void LoadUserData()
  {
      if (File.Exists(filePath))
      {
          string json = File.ReadAllText(filePath);
          GameData data = JsonUtility.FromJson<GameData>(json);

          gravity.text = data.gravity.ToString();
          drag.text = data.drag.ToString();
          angularDrag.text = data.angularDrag.ToString();

          Debug.Log("Loaded Local Data");
      }
      else {
        gravity.text = "-9.81";
        drag.text = "0.5f";
        angularDrag.text = "0.05f";
      }
  }
}
