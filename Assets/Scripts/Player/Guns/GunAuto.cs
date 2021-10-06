using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAuto : MonoBehaviour
{
    public Camera fpsCam;
    // Start is called before the first frame update

    public ushort damage = 10;
    public float range = 100f;
    public float fireRate = 15f;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public float nextFire = 0.5f;
    public string control = "Fire1";

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetButton(control) && Time.time >= nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
                target.TakeDamage(damage);
        }

        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 2f);
    }
}
