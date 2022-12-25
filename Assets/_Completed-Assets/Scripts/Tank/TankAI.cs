using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Complete {
public class TankAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    public Rigidbody m_Shell;    

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // if (gameObject.GetComponent<TankMovement>().enabled) {
        //     agent.SetDestination(player.position);
        //     transform.LookAt(player);
        // }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        // var rb = gameObject.GetComponent<Rigidbody>();
        // rb.AddExplosionForce (500f, rb.transform.position + rb.transform.forward, 5f);
    }
}
}
