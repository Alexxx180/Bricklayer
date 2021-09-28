using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float distance;

    private NavMeshAgent _agent;

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
