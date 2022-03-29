using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class shooting : MonoBehaviour
{
    public Image mark;
    public Image aim;
    public Button btn;

    bool triggered = false;

    Vector2 shoot;

    // Start is called before the first frame update
    void Start() { 

    }
    private void Update()
    {
        triggered = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("�浹");
        triggered = true;

    }
    public void Button_click()
    {
        if (triggered && mark.gameObject.activeSelf==false )
        {
            shoot = aim.gameObject.transform.position;
            mark.transform.position = shoot;
            mark.gameObject.SetActive(true);
        }
    }
}
