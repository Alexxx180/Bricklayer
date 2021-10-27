using UnityEngine;

public class BonusHP : MonoBehaviour
{
    public AudioSource source;
    public byte hp = 50;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;
        source.Play();
        BattleStatus ally = collision.transform.GetComponent<BattleStatus>();
        ally.Heal2(hp);
        Destroy(gameObject);
    }
}
