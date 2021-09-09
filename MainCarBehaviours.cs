using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MainCarBehaviours : MonoBehaviour
{
    public bool inCruseCondition;
    public bool inOverTaking;
    public bool inGameEndSituation;

    public float cruiseSpeed = 10f;
    public float sideSpeed = 10f;

    [SerializeField] Vector3 cruisePosition;
    [SerializeField] Vector3 overTakingPosition;
    [SerializeField] TMPro.TextMeshProUGUI overTakeGiftText;

    LevelFinish levelFinish;
    Fuel fuel;

    float cruiseZPosition=-2.25f;
    float overTakingZPosition=1.61f;
    
    void Start()
    {
        inCruseCondition = true;
        inOverTaking = false;
        inGameEndSituation = false;
        
        levelFinish = GetComponent<LevelFinish>();
        fuel = GetComponent<Fuel>();

        overTakeGiftText.enabled = false;

    }

    void Update()
    {
        MoveinCruiseCondition();
        MoveinOverTaking();
        DecidetheSituation();
        MoveLeftandRight();
    }

  

    void MoveinCruiseCondition()
    {
        if(inCruseCondition)
        {
           transform.Translate(cruiseSpeed * Time.deltaTime, 0, 0);
        }
      
    }

    void MoveinOverTaking()
    {
        if(inOverTaking)
        {
            transform.Translate(2*cruiseSpeed * Time.deltaTime, 0, 0);
        }
    }

    void DecidetheSituation()
    {
       if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) && !inGameEndSituation)
       {
            inCruseCondition = false;
            inOverTaking = true;
    
        }
       else if(!inGameEndSituation)
       {
            inCruseCondition = true;
            inOverTaking = false;
       }
    }


    void MoveLeftandRight()
    {
        if (transform.position.z <= overTakingZPosition && inOverTaking)
        {
            transform.Translate(0, 0, sideSpeed * Time.deltaTime);
        }

        if (transform.position.z >= cruiseZPosition && inCruseCondition)
        {
            transform.Translate(0, 0, -sideSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Other Cars Same Side" || other.gameObject.tag == "Other Cars Opposite Side")
        {
            inGameEndSituation = true;
            levelFinish.CrashSituation();
        }

        if (other.gameObject.tag == "Side Collider")
        {
            fuel.IncreaseFuel();
            SetOverTakeTextOpposite();
            Invoke("SetOverTakeTextOpposite", 1f);
            levelFinish.score += 10;
         
        }

        if(other.gameObject.tag=="Finish Line")
        {
            levelFinish.SuccessfulLevel();
        }
    }

    void SetOverTakeTextOpposite()
    {
        overTakeGiftText.enabled = !overTakeGiftText.enabled;
    }
}
