using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
