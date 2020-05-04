using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderEnemy : Unit
{
    private bool damageDealed;

    protected override void BrainInitialisation()
    {
        hp = configScriptable.sliderHp;
        damage = configScriptable.sliderDamage;
        speed = configScriptable.sliderSpeed;
        damageDealed = false;

        brain = new Brain(false);

        Chase chase = new Chase(1f, transform, AI.GetPlayer(),speed);
        

        brain.AddAIMechanic(chase);
        
        

        brain.ChooseState();

        coroutine = Wait(brain.GetCooldown());
        StartCoroutine(coroutine);
    }
    private IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" & !damageDealed)
        {
           
            GameObject.Find("Player(Clone)").GetComponent<Unit>().TakeDamage(damage);
            Debug.Log("DamageD");
            damageDealed = true;
            yield return new WaitForSeconds(1f);
            damageDealed = false;
        }
    }
}
