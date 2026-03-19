using UnityEngine;

public class KeepObjects : MonoBehaviour
{
    private static KeepObjects keepThisObject;
    private void Awake()
    {
        keepThisObject = this;
        DontDestroyOnLoad(gameObject);
    }
}
