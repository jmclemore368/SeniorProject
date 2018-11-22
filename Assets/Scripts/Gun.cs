using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float zoomFactor;
    private float zoomFOV;

    // Use this for initialization
    void Start() 
    {
        zoomFOV = Constants.CameraDefaultZoom / zoomFactor;
    }

    void Zoom()
    {
        Debug.Log("TIME IS: " + Time.deltaTime);
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomFOV, 
                                             Constants.zoomSpeed * Time.deltaTime);
    }
}
