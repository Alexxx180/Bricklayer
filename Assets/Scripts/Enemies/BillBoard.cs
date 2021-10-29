using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform cam;
    public Transform cam2;

    // Search for camera
    private void Awake()
    {
        if (cam == null)
            cam = GameObject.Find("Player2").transform.Find("FirstFace").gameObject.transform;
        if (cam2 == null)
            cam2 = GameObject.Find("Player2").transform.Find("ThirdFace").gameObject.transform;
    }

    // Always look for camera
    void LateUpdate()
    {
        if (cam.gameObject.activeSelf)
            transform.LookAt(transform.position + cam.forward);
        else if (cam2.gameObject.activeSelf)
            transform.LookAt(transform.position + cam2.forward);
    }
}
