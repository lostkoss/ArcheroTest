using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : AIMechanics
{
    float _speed;
    Transform _targetTransform;
    public override void MakeState()
    {
        AI.LookAt(_transform,_targetTransform.position);
        AI.Move(AI.GetPlayerPosition(),_transform,_speed);
        
    }

    public override void Reload()
    {
        throw new System.NotImplementedException();
    }

    public Chase(float mechanicTime, Transform transform, Transform targetTransform,float speed)
    {
        _speed = speed;
        _mechanicTime = mechanicTime;
        _transform = transform;
        _targetTransform = targetTransform;
    }
}
