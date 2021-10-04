using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleStatus : MonoBehaviour
{
    public Slider health;
    public Text hp;
    private byte MAX_HP = 100;

    private byte vulnerability = 100;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Enemy"))
            return;
        vulnerability--;
        RefreshHealth();
        if (vulnerability <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Heal(byte recover)
    {
        if (vulnerability + recover > MAX_HP)
            vulnerability = MAX_HP;
        else
            vulnerability += recover;
        RefreshHealth();
    }

    private void RefreshHealth()
    {
        health.value = vulnerability;
        hp.text = vulnerability + " / 100";
    }
}
