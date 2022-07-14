using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float distance = 30;
    public GameObject player = null;

    private NavMeshAgent _agent;
    public ushort health = 35;
    public byte damage = 12;
    public byte damageFight = 20;

    // Damage enemy
    public void TakeDamage(ushort damage)
    {
        if (health - damage <= 0)
            Die();
        else
            health -= damage;
    }

    // Enemy death
    void Die()
    {
        Destroy(gameObject);
    }

    // Search for target: player
    private void Awake()
    {
        if (player == null)
            player = GameObject.Find("Player2");
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
   private void Update()
   {
        //if (player == null)
        //    return;

        _agent.SetDestination(player.transform.position);
        _agent.isStopped = Vector3.Distance(transform.position, player.transform.position) >= distance;
   }

    public void setPlayer(GameObject target)
    {
        player = target;
    }

    // Damage to enemy from fight zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Fight"))
        {
            TakeDamage(damageFight);
        }
    }
}
