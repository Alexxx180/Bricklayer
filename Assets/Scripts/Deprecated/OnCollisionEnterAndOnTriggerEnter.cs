using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionEnterAndOnTriggerEnter : MonoBehaviour
{
    private AudioSource source;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject + " OnCollisionEnter " + collision.gameObject.name);
        source.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject + " OnTriggerEnter " + other.gameObject.name);
        source.Play();
    }



    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
