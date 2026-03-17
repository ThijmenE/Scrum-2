using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCam;
    public Camera roamCam;

    void Start() {
        mainCam.enabled = true;
        roamCam.enabled = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            mainCam.enabled = !mainCam.enabled;
            roamCam.enabled = !roamCam.enabled;
        }
    }
}
