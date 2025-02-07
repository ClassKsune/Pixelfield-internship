using UnityEngine;
using System.Collections;

public class CubePhysicSettings : MonoBehaviour
{
    public float _minHeight = 1f;  /// Min height for cube spawning
    public float _maxHeight = 5f;  // Max height for cube spawning
    public float _constrainTheCube = 2f; /// Time for cube constrains

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        /// Sets random height for cube with min, max restrains
        float randomHeight = Random.Range(_minHeight, _maxHeight);
        transform.position = new Vector3(transform.position.x, randomHeight, transform.position.z);

        /// Sets random cube rotation
        transform.rotation = Random.rotation;

        // Start the coroutine to apply the 2-second delay
        StartCoroutine(WaitAndRemoveConstraints());
    }

    /// Coroutine to wait for 2 seconds and then remove constraints
    IEnumerator WaitAndRemoveConstraints()
    {
        /// Set the object stuck by freezing its position and rotation
        rb.constraints = RigidbodyConstraints.FreezeAll; 

        // / Wait for 2 seconds
        yield return new WaitForSeconds(_constrainTheCube);

        /// Remove the constraints to allow the cube to move and rotate freely
        rb.constraints = RigidbodyConstraints.None; // This removes all constrains :)
    }
}

