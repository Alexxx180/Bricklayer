using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusAmmo2 : MonoBehaviour
{
    public GameObject weapon = null;
    public string weaponClass = "AK";

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;
        if (weapon == null)
            weapon = GameObject.Find("Player2").transform.Find("Camera").gameObject.transform.Find(weaponClass).gameObject;
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
