using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : AIMechanics
{
    float _speed;
    private Vector3 movePosition;
    public override void MakeState()
    {
        AI.Move(movePosition, _transform,_speed);
        AI.LookAtVector3(movePosition, _transform);
    }

    public override void Reload()
    {
        movePosition = AI.GetRandomPositionAtRange(_transform.position, 1f);
    }

    public RandomMove(float mechanicTime,Transform transform,float speed)
    {
        _speed = speed;
        _mechanicTime = mechanicTime;
        _transform = transform;
        needReload = true;

        movePosition = AI.GetRandomPositionAtRange(_transform.position, 1f);
    }
}
