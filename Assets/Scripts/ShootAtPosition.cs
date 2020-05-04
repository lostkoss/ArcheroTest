using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtPosition : AIMechanics
{
    private bool shooted;
    private bool _isPlayer;
    private float _bulletSpeed;
    private float _bulletDamage;

     Transform _targetTransform;

    public override void MakeState()
    {
        if (!shooted & _targetTransform != null)
        {
        AI.LookAt(_transform, _targetTransform.position);
        AI.Shoot(_isPlayer ? GameObject.Find("Config").GetComponent<Config>().playerBullet : GameObject.Find("Config").GetComponent<Config>().enemyBullet,_transform, _bulletSpeed,_bulletDamage);
        shooted = true;
        }

    }

    public override void Reload()
    {
        shooted = false;
        if((_targetTransform == null | _isPlayer) & GameObject.Find("Config").GetComponent<GameCreator>().enemyList.Count != 0)
        {
            _targetTransform =  AI.GetCloserEnemy(GameObject.Find("Config").GetComponent<GameCreator>().enemyList, _transform).transform;
        }
    }
    public ShootAtPosition(float mechanicTime, Transform transform, Transform targetTransform,bool isPlayer,float bulletSpeed,float bulletDamage)
    {
        _mechanicTime = mechanicTime;
        _transform = transform;
        _targetTransform = targetTransform;
        shooted = false;
        needReload = true;
        _isPlayer = isPlayer;
        _bulletDamage = bulletDamage;
        _bulletSpeed = bulletSpeed;
    }


}
