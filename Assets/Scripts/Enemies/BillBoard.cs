using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform cam;

    private void Awake()
    {
        if (cam == null)
            cam = GameObject.Find("Player2").transform.Find("Camera").gameObject.transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
