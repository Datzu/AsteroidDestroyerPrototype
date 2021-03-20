using UnityEngine;

public class ManageButtons : MonoBehaviour {

    void Start() {
        if (Application.platform == RuntimePlatform.WebGLPlayer) {
            gameObject.SetActive(false);
        }
    }

}
