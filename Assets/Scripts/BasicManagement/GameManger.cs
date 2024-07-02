using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private bool isPaused = false;

    public GameObject postProcessing;

    public GameObject graphicSettings;

    public bool canSpawnEnemyAgain = true;

    private void Awake()
    {
        postProcessing.SetActive(false);
        graphicSettings.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            graphicSettings.SetActive(isPaused);
        }
    }

    public void setGraphicsLow()
    {
        postProcessing.SetActive(false);
        isPaused = false;
        graphicSettings.SetActive(isPaused);
    }
    
    public void setGraphicsHigh()
    {
        postProcessing.SetActive(true);
        isPaused = false;
        graphicSettings.SetActive(isPaused);
    }

    public void setCanSpawnEnemies()
    {
        canSpawnEnemyAgain = !canSpawnEnemyAgain;
        isPaused = false;
        graphicSettings.SetActive(isPaused);
    }

}
