// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform laserSpawnPoint;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] float asteroidDistanceCheck = 10f;
    [SerializeField] LayerMask layerMask;

    private List<GameObject> allAsteroids = new List<GameObject>();
    private AsteroidSpawner asteroidSpawner;

    GameObject lazerFired;

    private void Awake()
    {
        asteroidSpawner = FindObjectOfType<AsteroidSpawner>(); 
    }

    private void Start()
    {
        UpdateAsteroidList();
    }

    private void Update()
    {
        DetectIfAsteroid();
    }

    public void UpdateAsteroidList()
    {
        allAsteroids = asteroidSpawner.GetAsteroidList();
    }

    public void DetectIfAsteroid()
    {
        for (int i = 0; i < allAsteroids.Count; i++)
        {
            if (allAsteroids[i] == null) { allAsteroids.Remove(allAsteroids[i]); return; }
            Debug.DrawRay(laserSpawnPoint.position, (allAsteroids[i].transform.position - laserSpawnPoint.position), Color.green, .01f);

           if (Physics.Raycast(laserSpawnPoint.position, (allAsteroids[i].transform.position - laserSpawnPoint.position), out RaycastHit hit, asteroidDistanceCheck))
           {
           
                if (hit.transform == allAsteroids[i].transform && lazerFired == null)
                {
                    lazerFired = Instantiate(laserPrefab, laserSpawnPoint.position, Quaternion.identity);
                    lazerFired.GetComponent<LaserScript>().GetAsteroid(allAsteroids[i]);
                }
           }
        }
    }
}
