using UnityEngine;

public class Poltergeist : MonoBehaviour
{
    public Rigidbody body;
    public float XPower;
    public float YPower;
    public float ZPower;
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.AddForce(new Vector3(XPower, YPower, ZPower));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
