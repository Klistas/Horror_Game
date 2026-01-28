using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Door FinalDoor;

    public void Awake()
    {
        instance = this;
    }

    public void Unlock()
    {
        FinalDoor.isLocked = false;
    }
}
