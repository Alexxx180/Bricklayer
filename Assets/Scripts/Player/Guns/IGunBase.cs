using UnityEngine;

interface IGunBase
{
    ushort MinAmmo(int min, int left);
    ushort MaxAmmo(int min, int left);
    void RefreshAmmo();
    void Restore(ushort bonus);
    ushort INFINITE { get; }
    ushort leftAmmo { get; set; }
    ushort maxAmmo { get; set; }
}
