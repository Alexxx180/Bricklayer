using UnityEngine;

public class GrabWeapon : MonoBehaviour
{
    public GameObject weapon = null;
    public string nameWeapon = "Ak48";
    public string weaponClass = "AK";

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;
        if (weapon == null)
            weapon = GameObject.Find("Player2").transform.Find("Camera").gameObject
            .transform.Find(weaponClass).gameObject.transform.Find(nameWeapon).gameObject;
        if (weapon.activeSelf)
            return;
        weapon.SetActive(true);
        Destroy(gameObject);
    }
}
