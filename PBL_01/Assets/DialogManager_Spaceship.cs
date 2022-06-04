using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DialogManager_Spaceship : MonoBehaviour, IPointerDownHandler
{
    public GameObject image;
    public GameObject button;
    public Text dialogText;
    public GameObject next;
    public CanvasGroup dialogGroup;
    public Queue<string> sentences;

    int i = 0;

    public string[] Set_sentences;

    private string currentSentence;

    public float typingSpeed = 0.1f;
    public bool istyping;

    public static DialogManager_Spaceship instance;

    public FadeScript F_instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        sentences = new Queue<string>();
        instance.Ondialogue(Set_sentences);
    }

    public void Ondialogue(string[] lines)
    {
        sentences.Clear();
        foreach (string line in lines)
        {
            sentences.Enqueue(line);
        }
        dialogGroup.alpha = 1;
        dialogGroup.blocksRaycasts = true;

        NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count != 0)
        {
            currentSentence = sentences.Dequeue();

            i++;
            istyping = true;
            next.SetActive(false);
            StartCoroutine(Typing(currentSentence));

            if (i == 2)
            {
                image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\17", typeof(Sprite)) as Sprite;
            }
       
        }
        else
        {
            //dialogGroup.alpha = 0;
            //dialogGroup.blocksRaycasts = false;
            //button.gameObject.SetActive(true);
            //버튼 클릭 없이 바로 다음 씬 넘어가기
            SceneManager.LoadScene("Prologue_Spaceship2");
        }
    }

    IEnumerator Typing(string line)
    {
        dialogText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        if (dialogText.text.Equals(currentSentence))
        {
            next.SetActive(true);
            istyping = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!istyping)
            NextSentence();
    }
}
