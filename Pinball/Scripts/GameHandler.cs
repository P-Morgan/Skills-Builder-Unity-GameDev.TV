using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] GameObject launcherGroup;
    [SerializeField] GameObject[] ballLives;
    [SerializeField] GameObject mightyBall;
    [SerializeField] Vector2 ballHomePosition;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] ParticleSystem respawnParticles;

    int livesIndex;

    AudioSource audioSource;

    private void Start()
    {
        
        livesIndex = ballLives.Length;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            deathParticles.Play();
            audioSource.Play();
            if (livesIndex > 0)
            {
                livesIndex--;
                Destroy(ballLives[livesIndex]);
                respawnParticles.Play();
                mightyBall.transform.position = ballHomePosition;
                launcherGroup.SetActive(true);
            }
            else if (livesIndex <= 0) { SceneManager.LoadScene(0); }
        }
    }

}
