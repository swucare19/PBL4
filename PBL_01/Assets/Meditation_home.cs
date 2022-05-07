using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Meditation_home : MonoBehaviour
{
    public Button home;
    // Start is called before the first frame update
    void Start()
    {
        home.interactable = false;
    }

    public void Interactive()
    {
        home.interactable = true;
    }

    public void Onclick()
    {
        SceneManager.LoadScene("House");
    }
}
