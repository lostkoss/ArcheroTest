using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Unit : MonoBehaviour
{
    [SerializeField] protected ConfigScriptable configScriptable;
    public float hp;
    public float speed;
    public float damage;
    public float bulletSpeed;

    protected Brain brain;

    protected IEnumerator coroutine;
    private void Start()
    {
        configScriptable = GameObject.Find("Config").GetComponent<GameCreator>().configScriptable;
        BrainInitialisation();
    }
    private void Update()
    {
        brain.MakeStateByIndex();
    }
    private void ReChooseState()
    {
        brain.ChooseState();
        coroutine = Wait(brain.GetCooldown());
        StartCoroutine(coroutine);
    }
    protected IEnumerator Wait(float cooldown)
    {

        yield return new WaitForSeconds(cooldown);
        ReChooseState();
    }
    protected virtual void BrainInitialisation()
    {

    }
    public  virtual void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            GameObject.Find("Config").GetComponent<GameCreator>().TryDestroyObject(this.gameObject);
        }
    }

   



}



