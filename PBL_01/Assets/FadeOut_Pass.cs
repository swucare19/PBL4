using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut_Pass : MonoBehaviour
{

    public RawImage Background;
    public Image Player;
    public Image Panel;
    float time = 0f;
    float F_time = 1.5f;
    // Start is called before the first frame update

    public void F_Out()
    {
        StartCoroutine(FadeOutFlow());
    }

    IEnumerator FadeOutFlow()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
        NextScene();
    }
    void NextScene()
    {
        SceneManager.LoadScene("Day2End");
    }

    void Show()
    {
        Player.gameObject.SetActive(true);
    }
    
    void Start()
    {
        Player.gameObject.SetActive(false);
        Invoke("Show", 1.5f);
        Invoke("F_Out", 3f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}