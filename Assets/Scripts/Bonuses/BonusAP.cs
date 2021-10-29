using UnityEngine;

public class BonusAP : MonoBehaviour
{
    public AudioSource source;
    public byte ap = 50;

    // Happens when collect ap bonus
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;
        source.Play();
        BattleStatus ally = collision.transform.GetComponent<BattleStatus>();
        ally.Restore2(ap);
        Destroy(gameObject);
    }
    
}
