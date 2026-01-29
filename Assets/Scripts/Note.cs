using UnityEngine;
using TMPro;

public enum NoteType
{
     None, First, Second, Third
}

public class Note : MonoBehaviour, IInteractable
{
    // UI로 패널에 텍스트를 함께 띄워준다.
    // 여러 텍스트에 따라 텍스트를 변경하도록 한다.
    // 창이 켜져있을때, 다른 조작이라던지, 시간의 흐름을 멈춘다.
    // E를 눌렀을때 꺼준다.
    public GameObject NotePanel;
    public TextMeshProUGUI NoteText;
    public bool IsReading;
    public NoteType noteType;

    public void Interact()
    {
        NotePanel.SetActive(true);
        // 텍스트를 변경해준다.
        IsReading = true;
        Time.timeScale = 0f;
        switch(noteType)
        {
            case NoteType.First:
                NoteText.text = "도망가지마~~~~";
                break;
            case NoteType.Second:
                NoteText.text = "도망가~~~~";
                break;
            case NoteType.Third:
                NoteText.text = "살려줘~~~~";
                break;
            default:break;
        }
    }
    void Update()
    {
        if(IsReading && Input.GetKeyDown(KeyCode.Tab))
        {
            NotePanel.SetActive(false);
            IsReading = false;
            Time.timeScale = 1f;
        }
    }
}
