using System.Collections;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    //public GameObject Light;
    public Light Light;
    public bool isTurnOn;
    public float MinTime;
    public float MaxTime;
    public AudioSource AudioSource;
    public AudioClip FlickerSound;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            //isTurnOn = !isTurnOn;
            //Light.SetActive(isTurnOn);
            Light.enabled = !Light.enabled;
            AudioSource.PlayOneShot(FlickerSound);
            float time = Random.Range(MinTime, MaxTime);

            yield return new WaitForSeconds(time);
        }
    }
}

