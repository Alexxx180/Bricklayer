using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private Transform _player;

    private float _xRotation = 0f;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        Rotations();
    }

    // For info: there we use Mathf.Clamp function to represent calcs
    // limited between lowest and highest degree value
    // This is similar to SIN-COS degree graph.

    // For info: there we use Quaternion.Euler function to 
    // rotate our objects at necessary degree.

    // Rotate camera and player by mouse sensitivity and deltaTime
    void Rotations()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _player.Rotate(Vector3.up * mouseX);
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
    }
}
