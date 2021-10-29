using UnityEngine;
using UnityEngine.UI;

public class StaticEnemy : MonoBehaviour
{
    public ushort health = 100;
    public byte damage = 35;
    public float lifetime = 2f;
    public GameObject show;

    public ParticleSystem flash;

    public Text hp;
    public Slider healthSl;
    private const ushort MAX_HP = 10000;
    private bool _isDied;

    public void TakeDamage(ushort damage)
    {
        if (_isDied)
            return;
        _isDied = health - damage <= 0;
        if (_isDied)
            Die();
        else
            health -= damage;
        RefreshHealth();
    }

    private void RefreshHealth()
    {
        healthSl.value = health;
        hp.text = health + " / " + MAX_HP;
    }

    async void Die()
    {
        health = 0;
        //flash.gameObject.transform.position = gameObject.transform.position;
        show.SetActive(true);
        await System.Threading.Tasks.Task.Delay(3600);
        Destroy(gameObject);
        flash.Play();
        await System.Threading.Tasks.Task.Delay(1200);
        flash.Play();
        await System.Threading.Tasks.Task.Delay(1200);
        flash.Play();
    }
}
