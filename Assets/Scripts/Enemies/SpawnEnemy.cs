using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Enemy asset;
    public AudioSource source;
    public List<Transform> points;

    private void Spawn(Transform trans)
    {
        Instantiate(asset, trans.position, Quaternion.identity, trans);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            source.Play();
            asset.enabled = true;
            asset.setPlayer(other.gameObject);

            for (byte i = 0; i < points.Count; i++)
                Spawn(points[i]);

            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        asset.setPlayer(gameObject);
        asset.enabled = false;
    }
}
