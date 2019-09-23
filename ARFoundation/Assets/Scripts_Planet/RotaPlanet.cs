using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaPlanet : MonoBehaviour
{

    //public float angle;
    public float RotSun;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //angle += Time.deltaTime;
        transform.Rotate(0f,  RotSun, 0f);
    }
    public void RotChange(float newRot)
    {
        RotSun = newRot;
    }
}
