using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogManager_Home : MonoBehaviour, IPointerDownHandler
{
    public Image tomee_eyes2;
    public GameObject image;
    public GameObject button;
    public Text dialogText;
    public GameObject next;
    public CanvasGroup dialogGroup;
    public Queue<string> sentences;

    int i = 0;

    public string[] Set_sentences;

    private string currentSentence;

    public float typingSpeed = 0.08f;
    public bool istyping;

    public static DialogManager_Home instance;

    public FadeScript F_instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        sentences = new Queue<string>();
        instance.Ondialogue(Set_sentences);
        tomee_eyes2.gameObject.SetActive(false);
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

            if (i == 5)
            {
                image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\10", typeof(Sprite)) as Sprite;
            }
            if (i == 6)
            {
                tomee_eyes2.gameObject.SetActive(true);
                image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\11_BG", typeof(Sprite)) as Sprite;
            }
        }
        else
        {
            dialogGroup.alpha = 0;
            dialogGroup.blocksRaycasts = false;
            button.gameObject.SetActive(true);
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
            StartCoroutine(UntilPlayback(next));
    }

    IEnumerator UntilPlayback(GameObject obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        NextSentence();
    }
}

