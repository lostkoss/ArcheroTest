using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Player : Unit
{
    bool mooving;
    public bool isDead;
    public float maxHP;
    [Inject]
    GameCreator gameCreator;
    [SerializeField] Image hpBar;
    Rigidbody _rigidbody;
    private void Start()
    {
        gameCreator = GameObject.Find("Config").GetComponent<GameCreator>();
        configScriptable = gameCreator.configScriptable;
        _rigidbody = GetComponent<Rigidbody>();
        hpBar = GameObject.Find("HPBar").GetComponent<Image>();
        isDead = false;
        
        BrainInitialisation();
    }
    private void Update()
    {
        if (!mooving & !gameCreator.locationPassed & brain != null & !isDead)
        {
        brain.MakeStateByIndex();

        }
        if (!isDead)
        {
        PlayerMove();

        }
    }
    protected override void BrainInitialisation()
    {
        hp = configScriptable.playerHp;
        maxHP = configScriptable.playerHp;
        damage = configScriptable.playerDamage;
        speed = configScriptable.playerSpeed;
        bulletSpeed = configScriptable.playerBulletSpeed;

        brain = new Brain(true);

        ShootAtPosition shoot = new ShootAtPosition(1f,transform, AI.GetCloserEnemy(gameCreator.enemyList,transform).transform,true, bulletSpeed, damage);

        brain.AddAIMechanic(shoot);

        brain.ChooseState();

        coroutine = Wait(brain.GetCooldown());
        StartCoroutine(coroutine);
    }
    private void PlayerMove()
    {

        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.S))
        {
            mooving = true;

            if (Input.GetKey(KeyCode.W))
            {
                _rigidbody.MovePosition(transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                _rigidbody.MovePosition(transform.position += new Vector3(1,0,0) * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody.MovePosition(transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                _rigidbody.MovePosition(transform.position += new Vector3(0, 0, -1) * Time.deltaTime * speed);
            }
        }
        else if(mooving)
        {
            mooving = false;
        }
    }
    public void PlayerMove(Vector2 moveVector)
    {
        if (!isDead)
        {

        mooving = true;
        _rigidbody.MovePosition(transform.position += new Vector3(moveVector.x, 0, moveVector.y) * Time.deltaTime * speed);
        }
    }
    public override void TakeDamage(float damage)
    {
        hp -= damage;
        UpdateHPBar();
        if (hp <= 0)
        {
            isDead = true;
            gameCreator.UIMenu.GetComponent<RestartPanelController>().dieText.text = "Die";
            gameCreator.UIMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void UpdateHPBar()
    {
        hpBar.fillAmount = hp / maxHP;
    }
}


