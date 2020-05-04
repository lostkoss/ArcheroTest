using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Unit
{
    private bool damageDealed;
    protected override void BrainInitialisation()
    {
        hp = configScriptable.bossHp;
        damage = configScriptable.bossDamage;
        speed = configScriptable.bossSpeed;
        bulletSpeed = configScriptable.bossBulletSpeed;

        damageDealed = false;

        brain = new Brain(true);

        Chase chase = new Chase(2f, transform, AI.GetPlayer(),speed*2);
        RandomMove randomMove = new RandomMove(1f, transform,speed);
        ShootAtPosition shoot = new ShootAtPosition(.2f, transform,AI.GetPlayer(),false, bulletSpeed, damage);
        MultiShot multiShoot = new MultiShot(.2f, transform, AI.GetPlayer(),damage,bulletSpeed);
        AIWait aIWait = new AIWait(1f);

        brain.AddAIMechanic(chase);
        brain.AddAIMechanic(aIWait);

        brain.AddAIMechanic(multiShoot);
        brain.AddAIMechanic(aIWait);

        brain.AddAIMechanic(shoot);
        brain.AddAIMechanic(shoot);
        brain.AddAIMechanic(shoot);
        brain.AddAIMechanic(aIWait);

        brain.AddAIMechanic(randomMove);

        brain.ChooseState();

        coroutine = Wait(brain.GetCooldown());
        StartCoroutine(coroutine);
    }
    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player" & !damageDealed)
        {
            
            GameObject.Find("Player(Clone)").GetComponent<Unit>().TakeDamage(damage);
            Debug.Log("DamageD");
            damageDealed = true;
            yield return new WaitForSeconds(1f);
            damageDealed = false;
        }
    }
}
