using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public Transform CameraTransform;
    public float InteractionDistance;
    public LayerMask InteractionLayer;
    public Image EKeyImage;
    public Image CrossHair;
    public Color InteractColor;
    public Color UnInteractColor;
    public Image JumpScareImg;
    public AudioClip JumpScareSound;
    public AudioSource audioSource;
    public float FadeOutSpeed;
    public float FadeOutTime;
    public bool IsJumpScared;


    void Update()
    {
        Ray ray = new Ray(CameraTransform.position, CameraTransform.forward);

        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * InteractionDistance, Color.red);

        if(Physics.Raycast(ray,out hit, InteractionDistance,InteractionLayer))
        {
            EKeyImage.gameObject.SetActive(true);
            CrossHair.color = InteractColor;
            if(Input.GetKeyDown(KeyCode.E))
            {
                //문을 열수 있는 메서드를 호출해주어야합니다.
                IInteractable interaction = hit.collider.GetComponent<IInteractable>();

                if (interaction != null)
                {
                    interaction.Interact();
                }
            }
        }
        else
        {
            EKeyImage.gameObject.SetActive(false);
            CrossHair.color = UnInteractColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Trigger") && !IsJumpScared)
        {
            audioSource.PlayOneShot(JumpScareSound);
            StartCoroutine(JumpScare());
        }
    }

    IEnumerator JumpScare()
    {
        JumpScareImg.gameObject.SetActive(true);
        while(true)
        {
            JumpScareImg.color -= new Color(0, 0, 0, FadeOutSpeed);
            yield return new WaitForSeconds(FadeOutTime);
            if(JumpScareImg.color.a <= 0)
            {
                break;
            }
        }
        IsJumpScared = true;
        JumpScareImg.gameObject.SetActive(false);
    }
}
