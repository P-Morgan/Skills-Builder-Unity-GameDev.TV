using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBlock : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        playerMovement.StartBoosted();
    }
}
