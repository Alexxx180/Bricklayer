using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceExample : MonoBehaviour
{
    [SerializeField] private float forceJump = 400;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Нажат Space");
            _rigidbody.AddForce(new Vector3(0, forceJump, 0), ForceMode.Acceleration);
        }
    }
}
