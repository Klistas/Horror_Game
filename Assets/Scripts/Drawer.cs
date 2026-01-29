using UnityEngine;

public class Drawer : MonoBehaviour,IInteractable
{
    public bool IsOpen;
    public float OpenPos;
    public float ClosePos;
    public float OpenSpeed;

    public void Interact()
    {
        IsOpen = !IsOpen;
        if(IsOpen)
        {
            GameManager.instance.ShowMessage("서랍장을 열었습니다.");
        }
        else
        {
            GameManager.instance.ShowMessage("서랍장을 닫았습니다.");
        }
    }

    void Update()
    {
        float targetX;

        if(IsOpen)
        {
            targetX = OpenPos;
        }
        else
        {
            targetX = ClosePos;
        }

        Vector3 currentPos = transform.position;
        Vector3 targetPos = new Vector3(targetX, currentPos.y, currentPos.z);
        transform.position = Vector3.Lerp(currentPos, targetPos, OpenSpeed * Time.deltaTime);
    }
}
