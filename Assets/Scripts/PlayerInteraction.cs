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
                Door door = hit.collider.GetComponent<Door>();
                door.Interact();

                Drawer drawer = hit.collider.GetComponent<Drawer>();
                door.Interact();
            }
        }
        else
        {
            EKeyImage.gameObject.SetActive(false);
            CrossHair.color = UnInteractColor;
        }
    }
}
