using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform target;

    float startFOV, targetFOV;

    public float zoomSpeed = 1;

    public Camera theCam;

    private void Awake()
    {
         instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
       

        startFOV = theCam.fieldOfView;
        targetFOV = startFOV;
        
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;

        theCam.fieldOfView = Mathf.Lerp(theCam.fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
    }

    public void ZoomIn(float newZoom)
    {
        targetFOV = newZoom;
    }

    public void ZoomOut()
    {
        targetFOV = startFOV;
    }
}
