using System;
using UnityEngine;

public class BonusAmmo : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;
        IGunBase ally = collision.GetComponentInChildren<Gun2>();//.Find(""); //GetComponent<Gun2>
        if (ally == null)
            ally = collision.GetComponentInChildren<GunAuto>();
        //Debug.Log(ally);
        if (ally.maxAmmo >= ally.INFINITE)
            return;
        if (ally.leftAmmo >= ally.maxAmmo)
            return;
        ushort bonus = Convert.ToUInt16(ally.maxAmmo / 5);
        ally.Restore(bonus);
        Destroy(gameObject);
    }
}
