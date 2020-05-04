using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public static class AI
{
    public static Vector3 GetPlayerPosition()
    {
        return GameObject.Find("Player(Clone)").transform.position;
    }

    public static void LookAt(Transform selfTransform,Vector3 lookObject)
    {
        Vector3 targetPostition = new Vector3(lookObject.x,
                                        selfTransform.position.y,
                                        lookObject.z);  
        
        selfTransform.LookAt(targetPostition);
    }
    public static void Move(Vector3 target,Transform _transform,float speed)
    {


        _transform.position = Vector3.MoveTowards(_transform.position, target, speed * Time.deltaTime);
        
    }
    public static Vector3 GetRandomPositionAtRange(Vector3 selfPosition,float distance)
    {
        Vector3 randomVector = new Vector3(Random.Range(0, distance) * Random.Range(0, 10) > 4 ? 1 : -1,
            0,
            Random.Range(0, distance) * Random.Range(0, 10) > 4 ? 1 : -1);
        return selfPosition + randomVector;
    }
    public static Transform GetPlayer()
    {
        return GameObject.Find("Player(Clone)").transform;
    }
    public static void LookAtVector3(Vector3 lookVector3,Transform _transform)
    {
        
    
        Vector3 diff = lookVector3 - _transform.position;
        diff.Normalize();

        float rot_y = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        _transform.rotation = Quaternion.Euler(0f, rot_y, 0);
    }
    public static void Shoot(GameObject bullet,Transform transform,float bulletSpeed,float bulletDamage)
    {

       GameObject bulletGO = GameObject.Instantiate(bullet,new Vector3(transform.position.x,1.5f,transform.position.z),transform.rotation);
        BulletTest bulletComponent = bulletGO.GetComponent<BulletTest>();
        bulletComponent.speed = bulletSpeed;
        bulletComponent.damage = bulletDamage;

    }
    public static void MultiShot(GameObject bullet, Transform transform, float bulletSpeed, float bulletDamage)
    {
        Quaternion temp = transform.rotation;

        
        GameObject bulletGO = GameObject.Instantiate(bullet, new Vector3(transform.position.x, 1.5f, transform.position.z), transform.rotation);
        BulletTest bulletComponent = bulletGO.GetComponent<BulletTest>();
        bulletComponent.speed = bulletSpeed;
        bulletComponent.damage = bulletDamage;

        temp.eulerAngles += new Vector3(0,   30, 0);
      
         bulletGO = GameObject.Instantiate(bullet, new Vector3(transform.position.x, 1.5f, transform.position.z), temp);
         bulletComponent = bulletGO.GetComponent<BulletTest>();
        bulletComponent.speed = bulletSpeed;
        bulletComponent.damage = bulletDamage;

      
        temp.eulerAngles += new Vector3(0, -60, 0);

        bulletGO = GameObject.Instantiate(bullet, new Vector3(transform.position.x, 1.5f, transform.position.z), temp);
        bulletComponent = bulletGO.GetComponent<BulletTest>();
        bulletComponent.speed = bulletSpeed;
        bulletComponent.damage = bulletDamage;
    }
    public static GameObject GetCloserEnemy(List<GameObject> enemyList,Transform selfTransform)
    {
        GameObject closerEnemy = null;
        if (enemyList.Count != 0)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (closerEnemy == null)
                {
                    closerEnemy = enemyList[i];
                }
                else
                {
                    if (Vector3.Distance(selfTransform.position, enemyList[i].transform.position) < Vector3.Distance(selfTransform.position, closerEnemy.transform.position))
                    {
                        closerEnemy = enemyList[i];
                    }
                }
            }
        }
        return closerEnemy;
    }
  

}
