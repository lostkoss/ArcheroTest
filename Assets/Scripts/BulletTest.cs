using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    [SerializeField] ConfigScriptable configScriptable;
   
    public float speed;
    public float damage;
 

    void Update()
    {
        
        transform.position += transform.forward * Time.deltaTime * speed;
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" & gameObject.tag == "PlayerBullet")
        {
            GameObject.Find("Config").GetComponent<GameCreator>().TryDamageEnemy(damage, other.gameObject);
            Destroy(this.gameObject);

        }
        if(other.tag == "Player" & gameObject.tag == "EnemyBullet")
        {
          
            GameObject.Find("Player(Clone)").GetComponent<Unit>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
