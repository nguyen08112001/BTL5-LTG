using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete {
    public class CheckEnemyEnabled : Node
{
    private Transform _transform;

    private float _attackTime = 1f;
    private float _attackCounter = 0f;

    public CheckEnemyEnabled(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        if (_transform.GetComponent<TankShooting>().enabled == false) {
            state = NodeState.RUNNING;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }

}
}


