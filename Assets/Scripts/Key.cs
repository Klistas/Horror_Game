using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour,IInteractable
{
    public Image KeyImage;
    public Color KeyColor;

    public void Interact()
    {
        // 잠긴문을 열어주는 동작을 하면 됨.

        // LockedDoor.isLocked = false;
        KeyImage.color = KeyColor;
        GameManager.instance.ShowMessage("키를 주웠습니다.");
        GameManager.instance.Unlock();
        gameObject.SetActive(false);
    }
}
