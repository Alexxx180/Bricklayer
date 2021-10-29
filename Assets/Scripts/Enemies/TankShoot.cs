using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public GameObject target;
    public int degree = 20;

    // Update is called once per frame
    void Update()
    {
        // Spin the object around the target at some degrees/second.
        transform.RotateAround(target.transform.position, Vector3.up, degree * Time.deltaTime);
    }
}
