using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : AIMechanics
{
    bool shooted;
    Transform _targetTransform;
    private float _bulletSpeed;
    private float _bulletDamage;
    public override void MakeState()
    {
        if (!shooted)
        {
            AI.LookAt(_transform, _targetTransform.position);
            AI.MultiShot(GameObject.Find("Config").GetComponent<Config>().enemyBullet, _transform,_bulletSpeed,_bulletDamage);
            shooted = true;
        }
    }

    public override void Reload()
    {
        shooted = false;
    }

    public MultiShot(float mechanicTime, Transform transform, Transform targetTransform,float bulletDamage,float bulletSpeed)
    {
        _bulletDamage = bulletDamage;
        _bulletSpeed = bulletSpeed;
        _mechanicTime = mechanicTime;
        _transform = transform;
        _targetTransform = targetTransform;
        shooted = false;
        needReload = true;
    }
}
