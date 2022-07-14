using UnityEngine;

public class GrabWeapon : MonoBehaviour
{
    public GameObject weapon = null;
    public string weaponClass = "AK";
    public string nameWeapon = "Ak48";

    // Happens when grab new or old weapon
    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (weapon == null)
        {
            GameObject weapons = other.gameObject.transform.Find("View").
                gameObject.transform.Find("PlayerView").
                gameObject.transform.Find("FirstFace").
                gameObject.transform.Find("Weapons").gameObject;
            
            weapon = weapons.transform.Find(weaponClass).
                gameObject.transform.Find(nameWeapon).gameObject;
        }

        // If weapon is old when leave on the ground
        if (weapon.activeSelf)
            return;
        weapon.SetActive(true);
        Destroy(gameObject);
    }
}
