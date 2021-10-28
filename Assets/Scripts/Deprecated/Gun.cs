using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private float _speedBullet;

    [SerializeField] private GameObject _player;

    private int _time = 0;
    public readonly int shootTime = 20;

    public Camera _camera;

    // Update is called once per frame
    void Update()
    {
        if (_time >= shootTime)
        {
            Shoot();
        }
        _time++;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _spawnBullet.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(_camera.transform.forward * _speedBullet);
        Destroy(bullet, 2f);
    }
}
