using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] GameObject player;
    [SerializeField] float playerDistanceLimit = 15f;
     float playerPositionTrigger;
    [SerializeField] Transform platformGroup;
    [SerializeField] float platformDestroyDistance = 40f;
    float moveSpawnerInX;

    int lastPlatform = 0;
    int randomPlatform = 0;

    [SerializeField] int minWorldPlatformHeight = -5;
    [SerializeField] int maxWorldPlatformHeight = 5;
    [SerializeField] int platSpawnerRange = 4;
    int spawnerYPosition;
    int randomPlatformHeight;

    // Start is called before the first frame update
    void Start()
    {
        playerPositionTrigger = transform.position.x - playerDistanceLimit;
        spawnerYPosition = Mathf.RoundToInt(transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= playerPositionTrigger)
        {
            InstantiateNewPlatform();
            MoveSpawner();
            DestroyPlatforms();
        }

    }
    private void InstantiateNewPlatform()
    {
        while (lastPlatform == randomPlatform)
        {
            randomPlatform = Random.Range(0, platformPrefab.Length);
        }
        lastPlatform = randomPlatform;

        GameObject newPlatform = Instantiate(platformPrefab[randomPlatform], transform.position, Quaternion.identity);
        Transform endpoint = newPlatform.transform.Find("EndPoint");

        moveSpawnerInX = endpoint.localPosition.x + Random.Range(0f, 3f);

        newPlatform.transform.parent = platformGroup;
       
    }

    private void MoveSpawner()
    {
       while (spawnerYPosition == randomPlatformHeight)
       {
            randomPlatformHeight = spawnerYPosition + Random.Range(-platSpawnerRange, platSpawnerRange);

            if (randomPlatformHeight <= minWorldPlatformHeight)
            {
                spawnerYPosition = Random.Range(minWorldPlatformHeight, platSpawnerRange);
            }
            if (randomPlatformHeight >= maxWorldPlatformHeight)
            {
                spawnerYPosition = Random.Range(-platSpawnerRange, maxWorldPlatformHeight);
            }
       }

        transform.Translate(moveSpawnerInX, 0, 0);
        transform.position = new Vector3(transform.position.x, randomPlatformHeight, 0f);

        playerPositionTrigger = transform.position.x - playerDistanceLimit;
        spawnerYPosition = Mathf.RoundToInt(transform.position.y);
    }

    private void DestroyPlatforms()
    {
        
        foreach (Transform child in platformGroup)
        {
            if (child.position.x <= transform.position.x - platformDestroyDistance)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
