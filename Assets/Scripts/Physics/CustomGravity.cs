using UnityEngine;
using TMPro;

public class CustomGravity : MonoBehaviour
{
    public float _gravity = -9.81f; /// Custom gravity default -9.81 m/s
    public float _drag = 0.5f; /// Adds custom drag
    public float _angularDrag = 0.05f; /// Simulates rotational resistence

    public TMP_InputField gravityInputField;
    public TMP_InputField dragInputField;
    public TMP_InputField angularDragInputField;


    void Start()
    {
        // Find all objects with the tag physics
        GameObject[] physicsObjects = GameObject.FindGameObjectsWithTag("Physics");

        foreach (GameObject obj in physicsObjects)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false;  /// Disable Unit gravity
                PhysicsObjectManager.Instance.RegisterRigidbody(rb);
            }
        }

        // Sets default values for inputs
        gravityInputField.text = "-9.81";
        dragInputField.text = "0.5";
        angularDragInputField.text = "0.05";
    }

    void FixedUpdate()
    {
        /// Gets Gravity, drag and angular drag float from menu
        float.TryParse(gravityInputField.text, out _gravity);
        float.TryParse(dragInputField.text, out _drag);
        float.TryParse(angularDragInputField.text, out _angularDrag);

        /// Apply custom gravity
        PhysicsObjectManager.Instance.ApplyCustomGravity(_gravity, _drag, _angularDrag);
    }


}

