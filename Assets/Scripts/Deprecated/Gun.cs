using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletPrefab2;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private float _speedBullet;

    //[SerializeField] private GameObject _player;

    private int _time = 0;
    private int _phaseTime = 0;
    public readonly int shootTime1 = 25;
    public readonly int shootTime2 = 50;
    public readonly float lifetime = 4f;
    public readonly float lifetime2 = 1f;

    public readonly int phase1 = 750;
    public readonly int phase2 = 500;

    //public Camera _camera;

    // Update is called once per frame
    void Update()
    {
        if (_phaseTime >= phase1 + phase2)
        {
            _phaseTime = 0;
        } else if (_phaseTime >= phase1)
        {
            Phases(_bulletPrefab2, shootTime2);
        } else
        {
            Phases(_bulletPrefab, shootTime1);
        }
        _phaseTime++;
    }

    private void Phases(GameObject ball, int shoot)
    {
        if (_time >= shoot)
        {
            Shoot(ball);
            _time = 0;
        }
        _time++;
    }

    private void Shoot(GameObject ball)
    {
        GameObject bullet = Instantiate(ball, _spawnBullet.position, Quaternion.identity);
        Rigidbody body = bullet.GetComponent<Rigidbody>();
        HitStat hitStat = bullet.GetComponent<HitStat>();
        body.AddForce(-_spawnBullet.transform.forward * _speedBullet);
        int optimize = Convert.ToInt32(lifetime);
        hitStat.FlareDelay(optimize * 1000);
        //FlareDelay
        //Destroy(bullet, lifetime);
    }
}
