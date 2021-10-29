using System.Threading.Tasks;
using UnityEngine;

public class HitStat : MonoBehaviour
{
    public byte damage = 50;
    public ParticleSystem flash;

    // Explosion delay with prefab lifetime
    public async void FlareDelay(int milliseconds, float lifetime)
    {
        await Task.Delay(milliseconds);
        flash.gameObject.transform.position = gameObject.transform.position;
        flash.Play();
        await Task.Delay(600);
        Destroy(gameObject, lifetime);
    }

    // Explosion delay without prefab lifetime
    public async void FlareDelay(int milliseconds)
    {
        await Task.Delay(milliseconds);
        flash.gameObject.transform.position = gameObject.transform.position;
        flash.Play();
        await Task.Delay(1000);
        Destroy(gameObject);
    }
}
