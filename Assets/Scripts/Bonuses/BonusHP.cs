using UnityEngine;

public class BonusHP : MonoBehaviour
{
    public byte hp = 50;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;
        BattleStatus ally = collision.transform.GetComponent<BattleStatus>();
        ally.Heal2(hp);
        Destroy(gameObject);
    }
}
