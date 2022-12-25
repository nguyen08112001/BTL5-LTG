using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Complete {
public class CheckEnemyInFOVRange : Node
{
    private static int _enemyLayerMask = 1 << 6;

    private Transform _transform;
    private Transform[] _player;

    public CheckEnemyInFOVRange(Transform transform, Transform[] player)
    {
        _transform = transform;
        _player = player;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("check enemy in range");

        // Collider[] colliders = Physics.OverlapSphere(_transform.position, 20f, GuardBT.m_TankMask);
        // if ( colliders.Length > 0) {
        //     Debug.Log(12345);
        // }
        GuardBT.target = -1;
        for (int i = 0; i < _player.Length; i++) {
            if (GuardBT.colliders[i].tag == "Enemy") continue;
            if (GuardBT.colliders[i].gameObject.activeSelf == false) continue;
            if (Vector3.Distance(_transform.position, _player[i].position) < 20f) {
                state = NodeState.SUCCESS;
                GuardBT.target = i;
                return state;
            }
        }
        

        state = NodeState.FAILURE;
        return state;
    }

}
}
