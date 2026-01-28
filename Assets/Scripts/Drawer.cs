using UnityEngine;

public class Drawer : MonoBehaviour
{
    public bool IsOpen;
    public float OpenPos;
    public float ClosePos;
    public float OpenSpeed;

    public void Interact()
    {
        IsOpen = !IsOpen;
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
