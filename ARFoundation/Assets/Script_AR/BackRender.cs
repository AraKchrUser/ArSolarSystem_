using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARFoundationBackgroundRenderer))]


public class BackRender : MonoBehaviour
{

    private ARFoundationBackgroundRenderer ThisBackGroundRender;
    public Material RenderMat;
    public Camera _cameraRenderBackGround;



    void Start()
    {

        ThisBackGroundRender = GetComponent<ARFoundationBackgroundRenderer>();
        ThisBackGroundRender.backgroundMaterial = RenderMat;
        ThisBackGroundRender.camera = _cameraRenderBackGround;
    }
}
