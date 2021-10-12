using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGun : MonoBehaviour
{
    public List<GameObject> Guns;
    public List<GameObject> Ammo;
    private int CountGuns => Guns.Count;
    private int Selected = StartGun;
    private const int StartGun = 0;

    // Update is called once per frame
    void Update()
    {
        int next = Selected + Convert.ToInt32(Input.GetAxisRaw("Mouse ScrollWheel") * 10);
        if (Selected == next)
            return;
        if (next > CountGuns - 1)
            Change(StartGun);
        else if (next < StartGun)
            Change(CountGuns - 1);
        else
            Change(next);
    }

    private void Change(int select)
    {
        Ammo[Selected].SetActive(false);
        Guns[Selected].SetActive(false);
        Selected = select;
        Guns[Selected].SetActive(true);
        Ammo[Selected].SetActive(true);
    }
}
