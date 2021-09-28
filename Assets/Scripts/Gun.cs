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

    public Camera _camera;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(_bulletPrefab, _spawnBullet.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(_camera.transform.forward * _speedBullet);
            Destroy(bullet, 15f);
        }
    }
}
