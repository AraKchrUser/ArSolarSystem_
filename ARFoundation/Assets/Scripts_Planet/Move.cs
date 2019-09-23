using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    public float angle;
    public float speed;

    private float firstSpeed; 
    public float a_;
    public float b_;
    public GameObject PositionCenter;
    private TrailRenderer trailChildren;

    void Start()
    {
        firstSpeed = speed; 
    }

    
    void Update()
    {

        if (speed != 0)
        {
            angle += Time.deltaTime; // меняется плавно значение угла
            var x = Mathf.Sin(angle * speed) * a_;
            var z = Mathf.Cos(angle * speed) * b_;
            Vector3 position = PositionCenter.transform.position;
            transform.position = new Vector3(x, 0, z) + position;//- new Vector3(0f, 0f, 0.5f * b_);
        }

    }

    public void SpeedChange(float newSpeed)
    {
        foreach (var trail in gameObject.GetComponentsInChildren<TrailRenderer>())
        {
            trailChildren = trail;
            trailChildren.Clear();
        }
        if (newSpeed <= 0) { speed = 0; Debug.Log(speed.ToString()); }
        else { speed = firstSpeed + newSpeed; }

        foreach (var trail in gameObject.GetComponentsInChildren<TrailRenderer>())
        {
            trailChildren = trail;
            trailChildren.Clear();
        }
        //StartCoroutine("TrailClear");




    }

    //IEnumerator TrailClear()
    //{
    //    for (var i = 0; i < 3; ++i)
    //    {
    //        foreach (var trail in gameObject.GetComponentsInChildren<TrailRenderer>())
    //        {
    //            trailChildren = trail;
    //            trailChildren.Clear();
    //        }
    //    }
    //    yield return null;
    //}
    }
