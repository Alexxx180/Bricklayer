using System;
using UnityEngine;

public class BonusAmmo : MonoBehaviour
{
    public AudioSource source;

    // This happens when we collect ammo bonus
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;
        IGunBase ally = collision.GetComponentInChildren<Gun2>();
        if (ally == null)
            ally = collision.GetComponentInChildren<GunAuto>();

        // If our gun ammo is not infinite and ammo not maxed
        if (ally.maxAmmo >= ally.INFINITE)
            return;
        if (ally.leftAmmo >= ally.maxAmmo)
            return;
        source.Play();
        ushort bonus = Convert.ToUInt16(ally.maxAmmo / 5);
        ally.Restore(bonus);
        Destroy(gameObject);
    }
}
