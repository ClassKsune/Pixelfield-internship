using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using System.Collections;
using System;

public class DatabaseManager : MonoBehaviour
{
    public TMP_InputField gravity, drag, angularDrag;
  
    private string userID;
    private DatabaseReference dbRef;

    void Start()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        userID = SystemInfo.deviceUniqueIdentifier;
    }

    public void CreateUser()
    {
        User newUser = new User(userID, float.Parse(gravity.text), float.Parse(drag.text), float.Parse(angularDrag.text));
        dbRef.Child("users").Child(userID).SetRawJsonValueAsync(JsonUtility.ToJson(newUser));
    }

    public IEnumerator GetGravityData(Action<float> onCallback)
    {
      var userData = dbRef.Child("users").Child(userID).Child("gravityStrenght").GetValueAsync();

      yield return new WaitUntil(predicate: () => userData.IsCompleted);

      if (userData != null)
      {
        DataSnapshot snapshot = userData.Result;

        // Check if snapshot.Value is a valid float and try to parse it
        if (float.TryParse(snapshot.Value.ToString(), out float gravityValue))
        {
            onCallback.Invoke(gravityValue);
        }
        else
        {
            Debug.LogError("Failed to parse gravity value.");
        }
      }
    }

    public IEnumerator GetDragData(Action<float> onCallback)
    {
      var userData = dbRef.Child("users").Child(userID).Child("drag").GetValueAsync();

      yield return new WaitUntil(predicate: () => userData.IsCompleted);

      if (userData != null)
      {
        DataSnapshot snapshot = userData.Result;

        // Check if snapshot.Value is a valid float and try to parse it
        if (float.TryParse(snapshot.Value.ToString(), out float dragData))
        {
            onCallback.Invoke(dragData);
        }
        else
        {
            Debug.LogError("Failed to parse gravity value.");
        }
      }
    }

        public IEnumerator GetAngularData(Action<float> onCallback)
    {
      var userData = dbRef.Child("users").Child(userID).Child("angularDrag").GetValueAsync();

      yield return new WaitUntil(predicate: () => userData.IsCompleted);

      if (userData != null)
      {
        DataSnapshot snapshot = userData.Result;

        // Check if snapshot.Value is a valid float and try to parse it
        if (float.TryParse(snapshot.Value.ToString(), out float angularData))
        {
            onCallback.Invoke(angularData);
        }
        else
        {
            Debug.LogError("Failed to parse gravity value.");
        }
      }
    }
    

    public void GetData() 
    {
      StartCoroutine(GetGravityData((float gravityData) => {
          gravity.text = gravityData.ToString();
      })); 

      StartCoroutine(GetDragData((float dragData) => {
          drag.text = dragData.ToString();
      }));

      StartCoroutine(GetAngularData((float angularData) => {
          angularDrag.text = angularData.ToString();
      }));
    }

}

