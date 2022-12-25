using System.Collections.Generic;
using UnityEngine;

namespace Complete {
public class GuardBT : Tree
{
    public static float speed = 5f;
    public static float fovRange = 6f;
    public static float attackRange = 1f;

    private Transform[] player;
    public LayerMask m_TankMask;  
    public static int target = -1;

    public static Collider[] colliders;

    protected override Node SetupTree()
    {
        Debug.Log("setup");

        // player = GameObject.FindGameObjectWithTag("Player").transform;

        colliders = Physics.OverlapSphere (transform.position, 100f, m_TankMask);
        Transform[] player = new Transform[colliders.Length];

            // For each of these transforms...
            for (int i = 0; i < player.Length; i++)
            {
                // ... set it to the appropriate tank transform.
                player[i] = colliders[i].transform;
            }

        Node root = new Selector(new List<Node>
        {
            new CheckEnemyEnabled(transform),
            new Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(transform, player),
                new TaskGoToTarget(transform, player),
                new TaskAttack(transform),
            }),
            new TaskPatrol(transform),
        });

        return root;
    }
}
}
