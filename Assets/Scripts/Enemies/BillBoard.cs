using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform cam;

    // Search for camera
    private void Awake()
    {
        if (cam == null)
            cam = GameObject.Find("Player2").transform.Find("Camera").gameObject.transform;
    }

    // Always look for camera
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
