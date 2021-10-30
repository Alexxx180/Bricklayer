using UnityEngine;

public class DisableCursor : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = false;
    }
}
