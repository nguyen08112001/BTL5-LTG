using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Complete {
public class TaskPatrol : Node
{
    private Transform _transform;

    private float standCounter;
    private Vector3 lastPosition;

    public TaskPatrol(Transform transform)
    {
        _transform = transform;

        standCounter = 0f;
        lastPosition = transform.position;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("tank patrol");
        var rb = _transform.GetComponent<Rigidbody>();

        float maxRotation = -1f;
        if (Vector3.Distance(_transform.position, lastPosition) <= 0.1f) {
            standCounter += Time.deltaTime;
        } else {
            standCounter = 0;
        }
        if (standCounter > 1f) {
            maxRotation = 1f;
        }
        lastPosition = _transform.position;

        System.Random rnd = new System.Random();

        float rotatee = Math.Max(maxRotation, rnd.Next(-100, 100) / 100f);

        float turn = 180f * Time.deltaTime * rotatee;
        Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

        rb.MoveRotation (rb.rotation * turnRotation);

        Vector3 movement = _transform.forward * 1f * 6f * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        state = NodeState.RUNNING;
        return state;
    }
}
}
