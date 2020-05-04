using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerEnemy : Unit
{
  

    protected override void BrainInitialisation()
    {
        hp = configScriptable.flyerHp;
        damage = configScriptable.flyerDamage;
        speed = configScriptable.flyerSpeed;
        bulletSpeed = configScriptable.flyerBulletSpeed;

        brain = new Brain(true);

        RandomMove randomMove = new RandomMove(1f, transform,speed);
        ShootAtPosition shoot = new ShootAtPosition(1f, transform, AI.GetPlayer(),false,bulletSpeed,damage);


        brain.AddAIMechanic(randomMove);
        brain.AddAIMechanic(shoot);




        brain.ChooseState();

        coroutine = Wait(brain.GetCooldown());
        StartCoroutine(coroutine);
    }
}
