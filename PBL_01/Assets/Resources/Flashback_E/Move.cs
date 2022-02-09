using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    float speed = 0.6f;
    float xMove, yMove;
    public Image move;

    public Image Panel;

    float time = 0f;
    float F_time = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Moving();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Moving()
    {
        StartCoroutine(MoveFlow());
        Invoke("F_Out", 2);
    }

    IEnumerator MoveFlow()
    {
        while (move.gameObject.transform.position.x < 1150.0f)
        {
            xMove = 0;
            yMove = 0;
            xMove = speed*0.5f;
            yMove = xMove * 0.6f;
            move.transform.Translate(new Vector3(xMove, yMove, 0));
            yield return null;
        }
        yield return null;
    }

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
    }
}
