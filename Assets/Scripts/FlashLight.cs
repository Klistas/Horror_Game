using UnityEngine;

public class FlashLight : MonoBehaviour
{

    public Light MyFlashLight;
    public AudioSource AudioSource;
    public AudioClip FlashSound;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(MyFlashLight != null && Input.GetKeyDown(KeyCode.F))
        {
            MyFlashLight.enabled = !MyFlashLight.enabled;
            AudioSource.PlayOneShot(FlashSound);
        }
    }
}
