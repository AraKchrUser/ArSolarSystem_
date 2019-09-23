using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;

public class PlanetPosition : MonoBehaviour
{

    //private ARSessionOrigin arorign; //Настройка AR, он содержит камеру и любые объекты, созданные из обнаруженных объектов, такие как плоскости.
    //private Pose pose; //используется для описания текущего положения и вращения устройства в пространстве
    [SerializeField] private PlaCement0bject[] placedObject;
    [SerializeField] private Camera arCamera;
    [SerializeField] private GameObject InfoPlanet;
    private Vector2 touchPosition = default;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();


    private void Awake()
    {
        ChangeSelectedObject(placedObject[0]);
        InfoPlanet.SetActive(false);
    }
    void Start()
    {
 
    }

    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    //Находит объект, к которому прикреплен компонент, затем находит Компонент, прикрепленный с этим объектом
                    PlaCement0bject placementObject = hitObject.transform.GetComponent<PlaCement0bject>();
                    if (placementObject != null) ChangeSelectedObject(placementObject);
                }
            }
        }
    }


    void ChangeSelectedObject(PlaCement0bject selected)
    {
        foreach (PlaCement0bject current in placedObject)
        {
            MeshRenderer meshRenderer = current.GetComponent<MeshRenderer>();
            if (selected != current)
            {
                current.IsSelected = false;
            }
            else { current.IsSelected = true; InfoPlanet.SetActive(true); }
        }
    }


   public  void FalseSetActive()
    {
        InfoPlanet.SetActive(false);
    }
    //private void UpdatePose()
    //{
    //    var screenPointCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
    //    var hits = new List<ARRaycastHit>();
    //    //arorign.Raycast(screenPointCenter, hits, TrackableType.Planes);
    //}

}
