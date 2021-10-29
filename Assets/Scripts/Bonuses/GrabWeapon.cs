using UnityEngine;

public class GrabWeapon : MonoBehaviour
{
    public GameObject weapon = null;
    public string nameWeapon = "Ak48";
    public string weaponClass = "AK";

    // Happens when grab new or old weapon
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;
        if (weapon == null)
            weapon = GameObject.Find("Player2").transform.Find("Camera").gameObject
            .transform.Find(weaponClass).gameObject.transform.Find(nameWeapon).gameObject;

        // If weapon is old when leave on the ground
        if (weapon.activeSelf)
            return;
        weapon.SetActive(true);
        Destroy(gameObject);
    }
}
