// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnvironment : MonoBehaviour
{
    [SerializeField] private GameObject groundTilePrefab;
    [SerializeField] private Sprite[] groundSprites;
    [SerializeField] Transform groundParent;
    [SerializeField] private GameObject rockTilePrefab;
    [SerializeField] private Sprite[] rockSprites;
    [SerializeField] Transform rockParent;
    [SerializeField] int numberOfRocks = 100;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Sprite[] foodSprites;
    [SerializeField] Transform foodParent;
    [SerializeField] int numberOfFood = 30;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] Transform enemyParent;
    [SerializeField] int numberOfEnemies = 10;

    [SerializeField] private GameObject exitPrefab;
    [SerializeField] Transform envionmentParent;

    [SerializeField] GameObject player;
    [SerializeField] int playerSafeZoneRadius = 1;

    [SerializeField] int mapSizeX = 20;
    [SerializeField] int mapSizeY = 20;

    private List<Vector2> floorTilesList = new List<Vector2>();
    

    void Start()
    {
        GenerateFloor();
        FloorArray();
        GenerateForegroundTiles();
    }

    private void GenerateFloor()
    {
        for (int x = 0; x < mapSizeX; x++)
        {
            for (int y = 0; y < mapSizeY; y++)
            {
                InstantiateFloorTile(x, y);
            }
        }
    }
    private void InstantiateFloorTile(int x, int y)
    {
        GameObject newFloorTile = Instantiate(groundTilePrefab, new Vector2(x, y), Quaternion.identity);
        newFloorTile.GetComponent<SpriteRenderer>().sprite = groundSprites[Random.Range(0, groundSprites.Length)];
        newFloorTile.transform.parent = groundParent;
    }

    private void FloorArray()
    {
            for (int x = 0; x < mapSizeX; x++)
            {
                for (int y = 0; y < mapSizeY; y++)
                {
                    floorTilesList.Add(new Vector2(x, y));
                }
            }
    }

    void GenerateForegroundTiles()
    {
        playerPosition();
        SpawnExit();
        GenerateRocks();
        GenerateFood();
          playerSafeZone();
        SpawnEnemies();
    }

    void playerPosition()
    {
        int playerX = Mathf.RoundToInt(player.transform.position.x);
       int playerY = Mathf.RoundToInt(player.transform.position.y);
        player.transform.position = new Vector2(playerX, playerY);
        floorTilesList.Remove(new Vector2(playerX, playerY));
    }
    void playerSafeZone()
    {
        int playerX = Mathf.RoundToInt(player.transform.position.x);
        int playerY = Mathf.RoundToInt(player.transform.position.y);
        int minX = playerX - playerSafeZoneRadius;
        int maxX = playerX + playerSafeZoneRadius;
        int minY = playerY - playerSafeZoneRadius;
        int maxY = playerY + playerSafeZoneRadius;
        for (int x = minX; x < maxX; x++)
        {
            for (int y = minY; y < maxY; y++)
            {
                if (floorTilesList.Contains(new Vector2(x, y)))
                {
                    floorTilesList.Remove(new Vector2(x, y));
                }
            }
        }
    }

    private void SpawnEnemies()
    {
        for (int e = 0; e < numberOfEnemies; e++)
        {
            int listLength = floorTilesList.Count;
            int randomTileNumber = Random.Range(0, listLength);
            GameObject newEnemy = Instantiate(enemyPrefab, floorTilesList[randomTileNumber], Quaternion.identity);
            floorTilesList.Remove(floorTilesList[randomTileNumber]);
            newEnemy.transform.parent = enemyParent;
        }
    }

    private void GenerateRocks()
    {
        for (int r = 0; r < numberOfRocks; r++)
        {
            int listLength = floorTilesList.Count;
            int randomTileNumber = Random.Range(0, listLength);
            GameObject newRockTile = Instantiate(rockTilePrefab, floorTilesList[randomTileNumber], Quaternion.identity);
            newRockTile.GetComponent<SpriteRenderer>().sprite = rockSprites[Random.Range(0, rockSprites.Length)];
            floorTilesList.Remove(floorTilesList[randomTileNumber]);
            newRockTile.transform.parent = rockParent;
        }
    }
    private void GenerateFood()
    {
        for (int f = 0; f < numberOfFood; f++)
        {
            int listLength = floorTilesList.Count;
            int randomTileNumber = Random.Range(0, listLength);
            GameObject newFoodTile = Instantiate(foodPrefab, floorTilesList[randomTileNumber], Quaternion.identity);
            newFoodTile.GetComponent<SpriteRenderer>().sprite = foodSprites[Random.Range(0, foodSprites.Length)];
            floorTilesList.Remove(floorTilesList[randomTileNumber]);
            newFoodTile.transform.parent = foodParent;
        }
    }

    private void SpawnExit()
    {
        Vector2 cornerChoice = randomCorner();
        GameObject exitSign = Instantiate(exitPrefab, cornerChoice, Quaternion.identity);
        floorTilesList.Remove(cornerChoice);
        exitSign.transform.parent = envionmentParent;
    }

   private Vector2 randomCorner()
    {
        Vector2[] fourCorners = new Vector2[] { new Vector2(0, 0), new Vector2(mapSizeX -1, 0), new Vector2(0, mapSizeY -1), new Vector2(mapSizeX -1, mapSizeY -1), };
        int randomCorner = Random.Range(0, fourCorners.Length);
        return fourCorners[randomCorner];
    }
}
