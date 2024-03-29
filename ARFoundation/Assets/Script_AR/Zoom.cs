﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    private Camera _cameraAr;
    private float orthoZommSpeed = .5f;
    private float perspectiveZoomSpeed = .5f;
    GameObject Sun;
    
    void Start()
    {
        Sun = GameObject.FindGameObjectWithTag("Sun");
        _cameraAr = GetComponent<Camera>();
    }

    
    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch TouchOne = Input.GetTouch(0);
            Touch TouchTwo = Input.GetTouch(1);

            Vector2 _touchOnePosition = TouchOne.position - TouchOne.deltaPosition;
            Vector2 _touchTwoPosition = TouchTwo.position - TouchTwo.deltaPosition;


            float _magnitudePreviouseTouch = (_touchOnePosition - _touchTwoPosition).magnitude;
            float _magnitudeTouch = (_touchOnePosition - _touchTwoPosition).magnitude;

            float _magnitudeDiff = _magnitudePreviouseTouch - _magnitudeTouch;

            if (_cameraAr.orthographic)
            {
                _cameraAr.orthographicSize += _magnitudeDiff * orthoZommSpeed;

                _cameraAr.orthographicSize = Mathf.Max(_cameraAr.orthographicSize, 0.1f);
            }
            else
            {
                _cameraAr.fieldOfView += _magnitudeDiff * perspectiveZoomSpeed;
                _cameraAr.fieldOfView = Mathf.Clamp(_cameraAr.fieldOfView, 0.1f, 179.9f);
            }
        }
    }


    public void CameraViewChange(Slider newCameraView)
    {
        
        float View = newCameraView.value;
        Sun.transform.position = new Vector3(Sun.transform.position.x, Sun.transform.position.y, View);
      //  _cameraAr.fieldOfView = View * perspectiveZoomSpeed;
    }
}
