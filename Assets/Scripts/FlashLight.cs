using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{

    public Light MyFlashLight;
    public AudioSource AudioSource;
    public AudioClip FlashSound;
    public float FlashBattery;
    public float UseBatterySpeed;
    public Slider BatterySlider;
    public float MaxBattery;

    // 플래시가 켜져있으면, 초당 배터리가 줄어드는 로직.
    // 배터리가 없으면 플래시를 킬 수 없는 로직.
    // 배터리를 실시간으로 슬라이더에 업데이트하는 로직.


    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        FlashBattery = MaxBattery;
    }

    void Update()
    {
        if(MyFlashLight != null && Input.GetKeyDown(KeyCode.F))
        {
            MyFlashLight.enabled = !MyFlashLight.enabled;
            AudioSource.PlayOneShot(FlashSound);
        }
        if(MyFlashLight.enabled)
        {
            if(FlashBattery > 0)
            {
                FlashBattery -= UseBatterySpeed * Time.deltaTime;
                BatterySlider.value = FlashBattery / MaxBattery;
            }
            else
            {
                MyFlashLight.enabled = false;
                GameManager.instance.ShowMessage("배터리 방전");
            }
        }
        else
        {
            // 배터리 충전
            FlashBattery += UseBatterySpeed * Time.deltaTime;
            FlashBattery = Mathf.Clamp(FlashBattery, 0, MaxBattery);
            BatterySlider.value = FlashBattery / MaxBattery;
        }
    }
}
