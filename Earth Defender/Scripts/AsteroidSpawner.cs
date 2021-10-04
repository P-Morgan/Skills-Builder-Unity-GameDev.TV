// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab = null;
    [SerializeField] private GameObject asteroidSphere = null;


    private List<GameObject> allAsteroids = new List<GameObject>();
    private int totalNumOfAsteroids = 0;

    private void SpawnAsteroid()
    {
        Vector3 randomPointAsteroidPointOnSphere = Random.onUnitSphere * ((asteroidSphere.transform.localScale.x / 2));
        GameObject newAsteroid = Instantiate(asteroidPrefab, randomPointAsteroidPointOnSphere, transform.rotation);
        newAsteroid.name = $"Asteroid {totalNumOfAsteroids}";
        totalNumOfAsteroids++;
        allAsteroids.Add(newAsteroid);
    }

    public void SpawnAsteroidButton()
    {
        SpawnAsteroid();
    }

    public void removeAsteroidFromList(GameObject asteroid)
    {
        allAsteroids.Remove(asteroid);
    }

    public List<GameObject> GetAsteroidList()
    {
        return allAsteroids;
    }

}
