using UnityEngine;
using TMPro;
using System.Collections;

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
        StartCoroutine(InitializeValues());
    }

    IEnumerator InitializeValues()
    {
        yield return new WaitForSeconds(1f);
        
        float.TryParse(gravityInputField.text, out _gravity);
        float.TryParse(dragInputField.text, out _drag);
        float.TryParse(angularDragInputField.text, out _angularDrag);
    }

    void FixedUpdate()
    {
        if (PhysicsObjectManager.Instance != null)
        {
            PhysicsObjectManager.Instance.ApplyCustomGravity(_gravity, _drag, _angularDrag);
        }
    }
}

