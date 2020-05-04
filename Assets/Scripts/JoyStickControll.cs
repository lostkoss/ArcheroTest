using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickControll : MonoBehaviour
{
    Vector2 firstPosition;
    Vector2 slidePosition;
    bool touched;
    bool firstTouch;

   [SerializeField] GameObject joyStickGO;
   [SerializeField] GameObject joyStickStickGO;

    Player player;
    GameCreator gameCreator;

    private void Start()
    {
        player = GameObject.Find("Player(Clone)").GetComponent<Player>();
        gameCreator = GameObject.Find("Config").GetComponent<GameCreator>();
    }

    void Update()
    {
        if(Input.touchCount == 1)
        {
           Touch touch = Input.GetTouch(0);
            if (!touched)
            {
                JoyStickTouch(touch);
                   firstPosition = touch.position;
            }
            else
            {
               slidePosition = touch.position;
            }

            touched = true;

            if(Vector2.Distance(firstPosition,slidePosition) > 0.1f)
            {
                float x = (firstPosition.x - slidePosition.x)/1020;
                float y = (firstPosition.y - slidePosition.y)/1980;
                
                Vector2 moveVector = new Vector2(Mathf.Clamp(x, -1, 1), Mathf.Clamp(y, -1, 1));

                joyStickStickGO.transform.position -= new Vector3(moveVector.x,moveVector.y,0) * 3;
                player.PlayerMove(-moveVector);
            }

        }
        if(Input.touchCount == 0 & touched)
        {

            touched = false;
            joyStickGO.SetActive(false);
            joyStickStickGO.SetActive(false);
        }
    }
    private void JoyStickTouch(Touch touch)
    {
        if (!player.isDead & !gameCreator.locationPassed)
        {

        joyStickGO.transform.position = touch.position;
        joyStickStickGO.transform.position = joyStickGO.transform.position;
        joyStickGO.SetActive(true);
        joyStickStickGO.SetActive(true);
        }
    }
}
