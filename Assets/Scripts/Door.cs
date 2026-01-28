using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{

    public bool isOpen;
    public bool isLocked;
    public float OpenAngle;
    public float CloseAngle;
    public float OpenSpeed;


    public void Interact()
    {
        if(isLocked) return;

        isOpen = !isOpen;
        Debug.Log($"문 열림 상태 : {isOpen}");
        //if (isOpen)
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, OpenAngle, transform.rotation.z));
        //}
        //else
        //{
        //    transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, CloseAngle, transform.rotation.z));
        //}
    }

    void Update()
    {
        float targetY;
        if(isOpen)
        {
            targetY = OpenAngle;
        }
        else
        {
            targetY = CloseAngle;
        }

        Quaternion currentRot = transform.rotation;
        Quaternion targetRot = Quaternion.Euler(0, targetY, 0);

        transform.rotation = Quaternion.Slerp(currentRot, targetRot, OpenSpeed * Time.deltaTime);
    }
}
