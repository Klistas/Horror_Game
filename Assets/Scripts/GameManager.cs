using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Door FinalDoor;
    public TextMeshProUGUI ShowingText;
    public float TextTime;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    // 텍스트를 변경하는 코드

    public void ShowMessage(string message)
    {
        //매개변수로 받은 텍스트를 출력.
        ShowingText.text = message;
        //3초간 대기
        //빈텍스트를 넣어서 클리어.
        StopAllCoroutines(); // 클리어 메시지가 이미 호출중일 수 있기때문에 지워줌.
        StartCoroutine(ClearMessage());
    }

    IEnumerator ClearMessage()
    {
        yield return new WaitForSeconds(TextTime);
        ShowingText.text = "";
    }

    public void Unlock()
    {
        FinalDoor.isLocked = false;
    }
}
