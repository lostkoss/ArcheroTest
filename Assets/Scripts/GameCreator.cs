using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameCreator : MonoBehaviour
{
    [Inject]
    public ConfigScriptable configScriptable;
    [Inject]
     public Arena arena;
    [SerializeField] public  GameObject UIMenu;
    

    public List<GameObject> enemyList;

    public bool locationPassed;
    public int arenaIndex =0;


    public Vector3 startPosition;

    GameObject playerGO;
    GameObject arenaGO;

    private IEnumerator coroutine;

    Player player;


    void Awake()
    {
        configScriptable.JsonDowload();
        enemyList = new List<GameObject>();
        locationPassed = false;
        playerGO =  Instantiate(configScriptable.player);
        player = playerGO.GetComponent<Player>();



    }
    private void Start()
    {
        LoadNextArena();
     
    }

    private void CreateEnemy(GameObject gameObject)
    {
        enemyList.Add( Instantiate(gameObject));
    }
    public void TryDamageEnemy(float damage,GameObject enemy)
    {
        if (enemyList.Contains(enemy))
        {
            enemy.GetComponent<Unit>().TakeDamage(damage);
        }
    }
    public void TryDestroyObject(GameObject gameObject)
    {
        if (enemyList.Contains(gameObject))
        {
            enemyList.Remove(gameObject);
            Destroy(gameObject);
            if(enemyList.Count == 0 & !player.isDead)
            {
                Debug.Log("Start");
                locationPassed = true;
                
                coroutine = Wait(arenaIndex == 0 ? 3:2);
                StartCoroutine(coroutine);



            }
        }
    }
    private void LoadNextArena()
    {
        if(arenaIndex < arena.arenaList.Count)
        {
            locationPassed = false;
            TryClearArena();
        ArenaInfo arenaInfo = arena.arenaList[arenaIndex];
        arenaGO = Instantiate(arenaInfo.arenaPrefab);
            playerGO.transform.position = startPosition;
        for (int i = 0; i < arenaInfo.enemiesList.Count; i++)
        {
            CreateEnemy(arenaInfo.enemiesList[i]);
        }
        arenaIndex++;
        }
        else
        {
            UIMenu.GetComponent<RestartPanelController>().dieText.text = "Win";
            UIMenu.SetActive(true);
        }
    }
    private void TryClearArena()
    {
        if(arenaGO != null)
        {
            Destroy(arenaGO);
        }
       
            for (int i = 0; i < enemyList.Count; i++)
            {

                TryDestroyObject(enemyList[i]);
            }
        
    }
    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("End");
        LoadNextArena();

        
       

    }
    public void Restart()
    {

        player.hp = playerGO.GetComponent<Player>().maxHP;
        player.UpdateHPBar();
        TryClearArena();
        arenaIndex = 0;
        LoadNextArena();
        Time.timeScale = 1f;
        playerGO.GetComponent<Player>().isDead = false;
        UIMenu.SetActive(false);
    }
}
