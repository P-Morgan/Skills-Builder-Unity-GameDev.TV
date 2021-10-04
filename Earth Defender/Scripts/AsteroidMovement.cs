// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0f;

    private GameObject planet;
    private AsteroidSpawner asteroidSpawner;
    private GameObject thisHitDetectionSphere;
    private float startingDistanceToPlanet;
    private float currentDistanceToPlanet;

    RaycastHit hit;

    Vector3 randomPointOnPlanet;

    void Start()
    {
        planet = GameObject.Find("Planet");
        asteroidSpawner = FindObjectOfType<AsteroidSpawner>();

        moveSpeed = UnityEngine.Random.Range(22, 33);

        randomPointOnPlanet = UnityEngine.Random.onUnitSphere * ((planet.transform.localScale.x / 2));
    }

    void Update()
    {
        MoveTowardsPlanet();
    }

    private void MoveTowardsPlanet()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, randomPointOnPlanet, step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            asteroidSpawner.removeAsteroidFromList(gameObject);
            Destroy(thisHitDetectionSphere);
            Destroy(gameObject);
        }
    }
}
