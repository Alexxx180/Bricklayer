using System;
using UnityEngine;

public class BonusAmmo2 : MonoBehaviour
{
    public GameObject weapon = null;
    public string weaponClass = "AK";

    // Grab weapon anyway - restore ammo if it is low
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
            
            weapon = weapons.transform.Find(weaponClass).gameObject;
        }
            
        // If weapon not selected - don't restore ammo
        if (!weapon.activeSelf)
            return;

        IGunBase ally = other.GetComponentInChildren<Gun2>();
        if (ally == null)
            ally = other.GetComponentInChildren<GunAuto>();

        if (ally.maxAmmo >= ally.INFINITE ||
            ally.leftAmmo >= ally.maxAmmo)
            return;

        ushort bonus = Convert.ToUInt16(ally.maxAmmo / 5);
        ally.Restore(bonus);
        weapon.SetActive(true);
        Destroy(gameObject);
    }
}
