using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMusic : MonoBehaviour
{
    [SerializeField] GameObject mainMusic;
    [SerializeField] GameObject deathMusic;
    // Start is called before the first frame update
    void Start()
    {
        mainMusic.SetActive(true);
        deathMusic.SetActive(false);
    }

    public void switchMusic()
    {
        deathMusic.SetActive(true);
        mainMusic.SetActive(false);
    }

}
