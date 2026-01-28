using UnityEngine;

public class Key : MonoBehaviour,IInteractable
{
    public void Interact()
    {
        // 잠긴문을 열어주는 동작을 하면 됨.

        // LockedDoor.isLocked = false;
        GameManager.instance.Unlock();
        gameObject.SetActive(false);
    }
}
