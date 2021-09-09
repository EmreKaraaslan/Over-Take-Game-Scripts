using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelFinish : MonoBehaviour
{
    public int score;

    [SerializeField] TMPro.TextMeshProUGUI crashText;
    [SerializeField] TMPro.TextMeshProUGUI fuelFinishText;
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    [SerializeField] TMPro.TextMeshProUGUI successfulLevelText;

    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject nextLevelButton;
    [SerializeField] GameObject startAgainButton;

    MainCarBehaviours mainCarBehaviours;
    CameraController cameraController;

    Scene scene;

    int activeSceneIndex;
    int nextSceneIndex;
    int totalNumberofScenes;
    

    void Start()
    {
        crashText.text = "";
        fuelFinishText.text = "";
        successfulLevelText.text = "";


        mainCarBehaviours = GetComponent<MainCarBehaviours>();
        cameraController = FindObjectOfType<CameraController>();

        nextLevelButton.transform.DOScale(Vector3.zero, 0f);
        restartButton.transform.DOScale(Vector3.zero, 0f);
        startAgainButton.transform.DOScale(Vector3.zero, 0f);

        SceneInfo();
    }

    
    void Update()
    {
        SetScoreText();
    }

    private void SceneInfo()
    {
        scene = SceneManager.GetActiveScene();
        activeSceneIndex = scene.buildIndex;
        nextSceneIndex = scene.buildIndex + 1;
        totalNumberofScenes = SceneManager.sceneCountInBuildSettings;
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void CrashSituation()
    {
        mainCarBehaviours.cruiseSpeed = 0f;
        mainCarBehaviours.sideSpeed = 0f;
        crashText.text = "Crash!";
        restartButton.transform.DOScale(Vector3.one, 1f);
        cameraController.MakePositionZoomOut();
    }

    public void FuelFinishSituation()
    {
        mainCarBehaviours.cruiseSpeed = 0f;
        mainCarBehaviours.sideSpeed = 0f;
        fuelFinishText.text = "Fuel is over!";
        restartButton.transform.DOScale(Vector3.one, 1f);
        cameraController.MakePositionZoomOut();
    }

    public void SuccessfulLevel()
    {
        successfulLevelText.text = "Level Finished! \n Your Score is: " + score;
        mainCarBehaviours.cruiseSpeed = 0f;
        mainCarBehaviours.sideSpeed = 0f;
        cameraController.MakePositionZoomOut();

        if (activeSceneIndex + 1 < totalNumberofScenes)
        {
            nextLevelButton.transform.DOScale(Vector3.one, 1f);
        }
        else
        {
            startAgainButton.transform.DOScale(Vector3.one, 1).SetDelay(1f);
        }

    }

    public void LoadNextLevel()
    {
       
       SceneManager.LoadScene(nextSceneIndex);
       
    }

    public void LoadSameLevel()
    {
       SceneManager.LoadScene(activeSceneIndex);
    }

    public void StartFromZero()
    {
        SceneManager.LoadScene(0);
    }
 
}
