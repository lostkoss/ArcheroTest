using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartPanelController : MonoBehaviour
{
    [SerializeField]public  Text dieText;
    RectTransform _rectTransform;
    IEnumerator enumerator;
    float deltaTime;

    private void OnEnable()
    {
        _rectTransform.position = new Vector3(540, 2800, 250);
        deltaTime = Time.deltaTime;
        enumerator =  MoveToCenter();
        StartCoroutine(enumerator);
        Debug.Log("Enable");
    }
    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

 

    private IEnumerator MoveToCenter()
    {
        while(_rectTransform.position.y > 1000)
        {
        
            yield return _rectTransform.position -= new Vector3(0, 800 * deltaTime , 0);
        }
        
    }

}
