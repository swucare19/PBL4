using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note0_Btn : MonoBehaviour
{
    public GameObject Note0, Note1;
    public Button btn;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetInt("day"))
        {
            case 1:

                text.text = "안녕, 다시 한 번 지구에 온걸 환영해." + "\n"+
                            "나는 아침 일찍 출근하고 저녁 늦게 퇴근해서 아마 너와 마추질 일은 얼마 없을거야." + "\n" +
                            "대신 매일 아침마다 너한테 쪽지를 남길게." + "\n" +
                            "ps. 밥은 냉장고에 있으니 꺼내서 챙겨먹어." + "\n" +
                            "뉴스에 너 얘기가 나왔더라. 식탁 위에 신문 확인해봐.";
                break;
            case 2:
                text.text = "아침 일찍 나가고 밤 늦게 들어오니까 얼굴 볼 일이 적네." + "\n" +
                            "오늘 하루도 조심히 잘 지내! 여기서 지내는 동안 마음놓고 편하게 있으렴." + "\n" +
                            "오늘도 밥 먹고 약 잊지마. 오늘 마을에 축제 열리니까 구경해봐.";
                            
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextNote()
    {
        Note0.SetActive(false);
        Note1.SetActive(true);
    }
}
