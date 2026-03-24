using UnityEngine;
using System.Collections;

public class DestroyDontDestroy : MonoBehaviour
{
    private void Awake()
    {
        foreach (var obj in Object.FindObjectsOfType<GameObject>())
            if (obj.scene.name == "DontDestroyOnLoad")
                Destroy(obj);
    }
}
