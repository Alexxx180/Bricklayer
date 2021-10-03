using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float distance;

    private NavMeshAgent _agent;
    public ushort health = 35;

    public void TakeDamage(ushort damage)
    {
        if (health - damage <= 0)
            Die();
        else
            health -= damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
   

    // Update is called once per frame
   private void Update()
    {
        _agent.SetDestination(_player.transform.position);
        _agent.isStopped = (Vector3.Distance(transform.position, _player.transform.position) >= distance);
    }
}
