using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoints : MonoBehaviour
{
    [SerializeField] int points = 100;

    ScoreBoard scoreBoard;
    AudioSource audioSource;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        audioSource = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreBoard.addpoints(points);
        audioSource.Play();
    }

}
