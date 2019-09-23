using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaCement0bject : MonoBehaviour
{
    public bool IsSelected { get; set; }
    public Image _planetShowImage;
    public Sprite _spriteLoad;

    void Update()
    {
        if (IsSelected == true) _planetShowImage.sprite = _spriteLoad;
    }
}
