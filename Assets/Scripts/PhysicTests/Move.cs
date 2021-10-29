using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.position = new Vector3(pos.x, pos.y + 1, pos.z);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.position = new Vector3(pos.x, pos.y - 1, pos.z);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z - 1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + 1);
        }
    }
}
