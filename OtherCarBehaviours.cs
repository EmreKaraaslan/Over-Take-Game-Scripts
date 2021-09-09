using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCarBehaviours : MonoBehaviour
{

    [SerializeField] GameObject parentofSameDirectionCars;
    [SerializeField] GameObject parentofOppositeDirectionCars;

    List<GameObject> sameDirectionCars;
    List<GameObject> oppositeDirectionCars;

    MainCarBehaviours mainCarBehaviours;

    void Start()
    {
        sameDirectionCars = new List<GameObject>();
        oppositeDirectionCars = new List<GameObject>();

        mainCarBehaviours = GetComponent<MainCarBehaviours>();
        AddCarstoLists();
       
    }

    void Update()
    {
        MoveOtherCars();

    }

    void AddCarstoLists()
    {
        for (int i = 0; i < parentofSameDirectionCars.transform.childCount; i++)
        {
            sameDirectionCars.Add(parentofSameDirectionCars.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < parentofOppositeDirectionCars.transform.childCount; i++)
        {
            oppositeDirectionCars.Add(parentofOppositeDirectionCars.transform.GetChild(i).gameObject);
        }
    }

    void MoveOtherCars()
    {
        foreach(GameObject sameDirectionCar in sameDirectionCars)
        {
            sameDirectionCar.transform.Translate(mainCarBehaviours.cruiseSpeed * Time.deltaTime,0,0);
        }

        foreach (GameObject oppositeDirectionCar in oppositeDirectionCars)
        {
            oppositeDirectionCar.transform.Translate(mainCarBehaviours.cruiseSpeed * Time.deltaTime, 0, 0);
        }
    }

}
