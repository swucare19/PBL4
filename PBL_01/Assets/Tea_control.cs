using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tea_control : MonoBehaviour
{
    public Image Teabag;
    
    // Start is called before the first frame update
    void Start()
    {
        if(choosetea.tea == "chamomile")
        {
            Teabag.GetComponent<Image>().sprite = Resources.Load("TeaTime\\chamomile", typeof(Sprite)) as Sprite;
        }
        else if (choosetea.tea == "lavender")
        {
            Teabag.GetComponent<Image>().sprite = Resources.Load("TeaTime\\lavender", typeof(Sprite)) as Sprite;
        }
        else if (choosetea.tea == "jasmine")
        {
            Teabag.GetComponent<Image>().sprite = Resources.Load("TeaTime\\jasmine", typeof(Sprite)) as Sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
