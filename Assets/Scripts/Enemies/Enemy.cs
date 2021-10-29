using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player = null;
    [SerializeField] private float distance = 30;

    private NavMeshAgent _agent;
    public ushort health = 35;
    public byte damage = 12;


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
        if (_player == null)
            _player = GameObject.Find("Player2");
        Debug.Log(_player);
        _agent = GetComponent<NavMeshAgent>();
    }
   

    // Update is called once per frame
   private void Update()
    {
        //if (_player == null)
        //    return;
        _agent.SetDestination(_player.transform.position);
        _agent.isStopped = Vector3.Distance(transform.position, _player.transform.position) >= distance;
    }
}
