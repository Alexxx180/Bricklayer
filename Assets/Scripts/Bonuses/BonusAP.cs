using UnityEngine;

public class BonusAP : MonoBehaviour
{
    public byte ap = 50;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;
        BattleStatus ally = collision.transform.GetComponent<BattleStatus>();
        ally.Restore(ap);
        Destroy(gameObject);
    }
    
}
