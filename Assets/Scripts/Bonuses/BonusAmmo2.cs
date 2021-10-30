using System;
using UnityEngine;

public class BonusAmmo2 : MonoBehaviour
{
    public GameObject weapon = null;
    public string weaponClass = "AK";

    // Grab weapon anyway - restore ammo if it is low
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;
        if (weapon == null)
            weapon = GameObject.Find("Player2").transform.Find("FirstFace").
                gameObject.transform.Find("Weapons").
                gameObject.transform.Find(weaponClass).gameObject;

        // If weapon not selected - don't restore ammo
        if (!weapon.activeSelf)
            return;
        IGunBase ally = collision.GetComponentInChildren<Gun2>();
        if (ally == null)
            ally = collision.GetComponentInChildren<GunAuto>();
        if (ally.maxAmmo >= ally.INFINITE)
            return;
        if (ally.leftAmmo >= ally.maxAmmo)
            return;
        ushort bonus = Convert.ToUInt16(ally.maxAmmo / 5);
        ally.Restore(bonus);
        weapon.SetActive(true);
        Destroy(gameObject);
    }
}
