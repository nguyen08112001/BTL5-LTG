using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete {

public class TaskGoToTarget : Node
{
    private Transform _transform;
    private Transform[] _player;

    public TaskGoToTarget(Transform transform, Transform[] player)
    {
        _transform = transform;
        _player = player;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("go to target");
        Transform _target = _player[GuardBT.target];
        
        _transform.LookAt(_target.position);
        _transform.position = Vector3.MoveTowards(
            _transform.position, _target.position, GuardBT.speed * Time.deltaTime);
        

        state = NodeState.RUNNING;
        return state;
    }

}
}
