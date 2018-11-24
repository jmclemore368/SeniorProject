using UnityEngine;

public class WeaponScope : MonoBehaviour {
    public float zoomFactor;
    private float zoomFOV;

    void Start() {
        zoomFOV = Constants.CameraDefaultZoom / zoomFactor;
    }

    void Zoom() {
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomFOV, 
                                             Constants.zoomSpeed * Time.deltaTime);
    }
}
