using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    public void LockCursorAndSetVisible(bool visible)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = visible;
    }
}
