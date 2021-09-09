using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] GameObject mainCar;

    MainCarBehaviours mainCarBehaviours;
    Vector3 ZoomInPosition, ZoomOutPosition, offset;
   
   
    void Start()
    {
        offset = transform.position - mainCar.transform.position;
        mainCarBehaviours = mainCar.GetComponent<MainCarBehaviours>();
 
    }


    void LateUpdate()
    {
        CameraPositions();
        MakePositionZoomOut();

    }

    public void MakePositionZoomOut()
    {
        if (mainCarBehaviours.inOverTaking)
        {
            transform.position = Vector3.Lerp(ZoomInPosition, ZoomOutPosition, 0.5f);
        }
    }

    private void CameraPositions()
    {
        ZoomInPosition = mainCar.transform.position + offset;
        ZoomOutPosition = ZoomInPosition + new Vector3(-8, 5.2f, 0);
        transform.position = ZoomInPosition;
    }
}

