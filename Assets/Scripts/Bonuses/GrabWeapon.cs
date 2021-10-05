using UnityEngine;

public class GrabWeapon : MonoBehaviour
{
    public GameObject weapon;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;
        weapon.SetActive(true);
        Destroy(gameObject);
    }
}
