using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathPlane : MonoBehaviour
{
    [SerializeField] GameObject endCanvas;
    [SerializeField] GameObject score;
    TMP_Text scoring;

    UItexts startCanvas;
    int currentScore;
    PlayerMovement playerMovement;
    HandleMusic handleMusic;


    private void Awake()
    {
        endCanvas.SetActive(false);
        startCanvas = FindObjectOfType<UItexts>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        handleMusic = FindObjectOfType<HandleMusic>();
    }
    private void OnTriggerEnter() 
    {
        handleMusic.switchMusic();
        Time.timeScale = 0;
        playerMovement.stopBoosting();
        endCanvas.SetActive(true);
        scoring = score.GetComponent<TMP_Text>();
        currentScore = startCanvas.sendScore();
        scoring.text = currentScore.ToString();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    
}
