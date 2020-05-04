using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[CreateAssetMenu(fileName ="Config",menuName ="Config")]
public class ConfigScriptable : ScriptableObject
{

    public bool jsonConfigDowload;
    public  GameObject playerBullet;
    public  GameObject enemyBullet;

    public GameObject flyerEnemy;
    public GameObject sliderEnemy;
    public GameObject bossEnemy;
    public GameObject player;

   
   public  float sliderDamage;
   public  float flyerDamage;
   public  float bossDamage;
   public  float playerDamage;

   public  float sliderSpeed;
   public  float flyerSpeed;
   public  float bossSpeed;
   public  float playerSpeed;

   public  float sliderBulletSpeed;
   public  float playerBulletSpeed;
   public  float bossBulletSpeed;
   public  float flyerBulletSpeed;
   
   public  float sliderHp;
   public  float flyerHp;
   public  float bossHp;
   public  float playerHp;

  
    public void JsonDowload()
    {
        if (jsonConfigDowload)
        {
        Debug.Log("Json");
        string jsonString;
        jsonString = File.ReadAllText(Application.dataPath + "/config.txt");
        JsonInitialisation(JsonUtility.FromJson<JsonConfigInfo>(jsonString));

        }


    }

    private void JsonInitialisation(JsonConfigInfo jsonConfigInfo)
    {
        sliderDamage         = jsonConfigInfo._sliderDamage;
        flyerDamage          = jsonConfigInfo._flyerDamage;
        bossDamage           = jsonConfigInfo._bossDamage;
        playerDamage         = jsonConfigInfo._playerDamage;
        sliderSpeed          = jsonConfigInfo._sliderSpeed;
        flyerSpeed           = jsonConfigInfo._flyerSpeed;
        bossSpeed            = jsonConfigInfo._bossSpeed;
        playerSpeed          = jsonConfigInfo._playerSpeed;

        sliderBulletSpeed    = jsonConfigInfo._sliderBulletSpeed;
        playerBulletSpeed    = jsonConfigInfo._playerBulletSpeed;
        bossBulletSpeed      = jsonConfigInfo._bossBulletSpeed;
        flyerBulletSpeed     = jsonConfigInfo._flyerBulletSpeed;
                             
        sliderHp             = jsonConfigInfo._sliderHp;
        flyerHp              = jsonConfigInfo._flyerHp;
        bossHp               = jsonConfigInfo._bossHp;
        playerHp             = jsonConfigInfo._playerHp;
    }
}
[System.Serializable]
public class JsonConfigInfo {
    public float _sliderDamage;
    public float _flyerDamage;
    public float _bossDamage;
    public float _playerDamage;
                 
    public float _sliderSpeed;
    public float _flyerSpeed;
    public float _bossSpeed;
    public float _playerSpeed;
                 
    public float _sliderBulletSpeed;
    public float _playerBulletSpeed;
    public float _bossBulletSpeed;
    public float _flyerBulletSpeed;
                 
    public float _sliderHp;
    public float _flyerHp;
    public float _bossHp;
    public float _playerHp;
}

