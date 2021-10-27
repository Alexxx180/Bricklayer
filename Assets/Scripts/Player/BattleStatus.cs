using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleStatus : MonoBehaviour
{
    public AudioSource source;
    public Slider health;
    public Text hp;
    public Slider armor;
    public Text ap;
    public Text hpPacks;
    public Text apPacks;
    private byte MAX_HP = 100;
    private byte MAX_AP = 100;

    private byte vulnerability = 100;
    private byte shield = 0;

    private const byte _MAX_HP_PACKS = 99;
    private const byte _MAX_AP_PACKS = 99;

    private byte _hpPacks = 0;
    private byte _apPacks = 0;

    private void Start()
    {
        vulnerability = Convert.ToByte(health.value);
        shield = Convert.ToByte(armor.value);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Enemy"))
            return;
        source.Play();
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
            UseHpPack2(value);
        else
            vulnerability -= value;
    }

    public void UseHpPack2(byte value)
    {
        short mem = value;
        while (_hpPacks > 0 && vulnerability - mem + 50 >= 0)
        {
            mem -= 50;
            _hpPacks--;
        }
        vulnerability = Convert.ToByte(Math.Max(vulnerability - mem, 0));
        RefreshText(hpPacks, _hpPacks);
        RefreshHealth();
        if (vulnerability <= 0)
        {
            SceneManager.LoadScene("Rain");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void UseHpPack()
    {
        if (_hpPacks <= 0)
            return;
        vulnerability = Convert.ToByte(Math.Min(vulnerability + 50, MAX_HP));
        _hpPacks--;
        RefreshText(hpPacks, _hpPacks);
        RefreshHealth();
    }

    public void UseApPack()
    {
        if (_apPacks <= 0)
            return;
        shield = Convert.ToByte(Math.Min(shield + 50, MAX_AP));
        _apPacks--;
        RefreshText(apPacks, _apPacks);
        RefreshArmor();
    }

    public void Heal2(byte recover)
    {
        if (vulnerability >= MAX_HP)
        {
            if (_hpPacks >= _MAX_HP_PACKS)
                return;
            _hpPacks += Convert.ToByte(recover / 50);
            RefreshText(hpPacks, _hpPacks);
        }
        else
            Heal(recover);
    }

    public void Heal(byte recover)
    {
        if (vulnerability + recover > MAX_HP)
            vulnerability = MAX_HP;
        else
            vulnerability += recover;
        RefreshHealth();
    }

    public void Restore2(byte recover)
    {
        if (shield >= MAX_AP)
        {
            if (_apPacks >= _MAX_AP_PACKS)
                return;
            _apPacks += Convert.ToByte(recover / 50);
            RefreshText(apPacks, _apPacks);
        }
        else
            Restore(recover);
    }

    public void Restore(byte recover)
    {
        if (shield + recover > MAX_HP)
            shield = MAX_HP;
        else
            shield += recover;
        RefreshArmor();
    }

    private void RefreshText(Text text, string value)
    {
        text.text = value;
    }

    private void RefreshText(Text text, byte value)
    {
        RefreshText(text, value.ToString());
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
