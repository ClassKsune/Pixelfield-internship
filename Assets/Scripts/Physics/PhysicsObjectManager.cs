using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PhysicsObjectManager : MonoBehaviour
{
    public static PhysicsObjectManager Instance;
    private List<Rigidbody> physicsObjects = new List<Rigidbody>();

    void Awake()
    {
        // Only one instance of this manager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); /// Makes sure this manager persists across scenes
        }
        else
        {
            Destroy(gameObject); /// Destroy duplicates if any
        }

        /// Register objects every time a scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// Unsubscribe from the sceneLoaded event when the object is destroyed
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /// Called when a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RegisterPhysicsObjectsInScene();
    }

    /// Register all physics objects in the current scene
    public void RegisterPhysicsObjectsInScene()
    {
        /// Find all objects with Physics tag
        GameObject[] physicsObjectsInScene = GameObject.FindGameObjectsWithTag("Physics");

        foreach (GameObject obj in physicsObjectsInScene)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null && !physicsObjects.Contains(rb))
            {
                rb.useGravity = false; /// Disable default gravity
                physicsObjects.Add(rb); /// Register the Rigidbody
            }
        }
    }

    // Add a Rigidbody to the list
    public void RegisterRigidbody(Rigidbody rb)
    {
        if (rb != null && !physicsObjects.Contains(rb))
        {
            physicsObjects.Add(rb);
        }
    }

    /// Apply custom gravity
    public void ApplyCustomGravity(float gravity, float drag, float angularDrag)
    {
        foreach (Rigidbody rb in physicsObjects)
        {
            if (rb != null)
            {
                rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
                rb.drag = drag;
                rb.angularDrag = angularDrag;
            }
        }
    }
}

