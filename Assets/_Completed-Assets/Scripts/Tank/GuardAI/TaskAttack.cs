using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete {
    public class TaskAttack : Node
{
    private Transform _transform;


    private float _attackTime = 1f;
    private float _attackCounter = 0f;

    public TaskAttack(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("attack");

        _transform.GetComponent<TankShooting>().EnemyFire();

        state = NodeState.RUNNING;
        return state;
    }

}
}


