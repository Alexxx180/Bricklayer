using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleStatus : MonoBehaviour
{
    public Slider health;
    public Text hp;
    public Slider armor;
    public Text ap;
    private byte MAX_HP = 100;
    private byte MAX_AP = 100;

    private byte vulnerability = 100;
    private byte shield = 0;

    private void Start()
    {
        vulnerability = Convert.ToByte(health.value);
        shield = Convert.ToByte(armor.value);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Enemy"))
            return;
        Enemy enemy = collision.transform.GetComponent<Enemy>();
        Damage(enemy.damage);
        RefreshHealth();
        RefreshArmor();
    }

    public void Damage(byte value)
    {
        
        if (shield - value / 1.5 <= 0)
        {
            Hurt(Convert.ToByte(value / 1.5 - shield));
            shield = 0;
        }
        else
        {
            shield -= Convert.ToByte(value / 1.5);
            Hurt(Convert.ToByte(value / 3));
        }
            
    }

    public void Hurt(byte value)
    {
        if (vulnerability - value <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
            vulnerability -= value;
    }

    public void Heal(byte recover)
    {
        if (vulnerability + recover > MAX_HP)
            vulnerability = MAX_HP;
        else
            vulnerability += recover;
        RefreshHealth();
    }

    public void Restore(byte recover)
    {
        if (shield + recover > MAX_HP)
            shield = MAX_HP;
        else
            shield += recover;
        RefreshArmor();
    }

    private void RefreshHealth()
    {
        health.value = vulnerability;
        hp.text = vulnerability + " / " + MAX_HP;
    }

    private void RefreshArmor()
    {
        armor.value = shield;
        ap.text = shield + " / " + MAX_AP;
    }
}
