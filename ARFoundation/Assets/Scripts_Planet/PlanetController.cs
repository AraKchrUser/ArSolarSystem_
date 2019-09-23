using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlanetController : MonoBehaviour
{

    GameObject Sun;
    GameObject PositionCenter;
    private TrailRenderer trailChildren;
    [SerializeField] 
    private _Planet[] Planets;
    void Start()
    {
        foreach (_Planet planet in Planets)
        {
            planet.firstSpeed = planet.speed;
        }
        Sun = GameObject.FindGameObjectWithTag("Sun");
        PositionCenter = Sun;
    }

    
    void Update()
    {
        foreach(_Planet planet in Planets)
            {
            planet.object_planet.transform.Rotate(0f, planet.RotSun, 0f);

            if (planet.speed != 0)
            {
                planet.angle += Time.deltaTime; // меняется плавно значение угла
                var x = Mathf.Sin(planet.angle * planet.speed) * planet.a_;
                var z = Mathf.Cos(planet.angle * planet.speed) * planet.b_;
                Vector3 position = PositionCenter.transform.position;
                planet.object_planet.transform.position = new Vector3(x, 0, z) + position;//- new Vector3(0f, 0f, 0.5f * b_);
            }
        }
    }

    public void RotChange(Slider SlRot)
    {
        float newRot = SlRot.value;
        foreach (_Planet planet in Planets)
        {
            planet.RotSun = newRot;
        }
    }

    public void SunRotation(Slider SL)
    {
       // Sun.transform.rotation
    }

    public void SpeedChange(Slider SlnewSpeed)
    {
        float newSpeed = SlnewSpeed.value;
        foreach (_Planet planet in Planets)
        {
            foreach (var trail in planet.object_planet.GetComponentsInChildren<TrailRenderer>())
            {
                trailChildren = trail;
                trailChildren.Clear();
            }
            if (newSpeed <= 0) { planet.speed = 0; Debug.Log(planet.speed.ToString()); }
            else { planet.speed = planet.firstSpeed + newSpeed; }

            foreach (var trail in planet.object_planet.GetComponentsInChildren<TrailRenderer>())
            {
                trailChildren = trail;
                trailChildren.Clear();
            }
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
[System.Serializable]
class _Planet
{
    public string name;
    public GameObject object_planet;
    public float RotSun;
    public float angle;
    public float speed;

    public float firstSpeed;
    public float a_;
    public float b_;
    private TrailRenderer trailChildren;

    void Start()
    {
        
    }

    void Update()
    {

    }
}