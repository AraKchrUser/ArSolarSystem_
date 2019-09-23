using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAlpha : MonoBehaviour
{
    Color _colorContainer;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void AlphaChange(float _newMaterial)
    {
        _colorContainer = gameObject.GetComponent<Renderer>().material.color;
        _colorContainer.a = _newMaterial;
        gameObject.GetComponent<Renderer>().material.color = _colorContainer;
    }
}
