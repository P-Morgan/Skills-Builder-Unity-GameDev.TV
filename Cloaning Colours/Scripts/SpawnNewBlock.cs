// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewBlock : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] Transform spawnPosition;
    ColorChanger colorChanger;
    int myColorIndex;


    public void SpawnBlock()
    {
       GameObject newBlock = Instantiate(blockPrefab, spawnPosition.position, Quaternion.identity);
        colorChanger = newBlock.GetComponent<ColorChanger>();
        myColorIndex = Random.Range(0, colorChanger.SpriteColorLength());
        colorChanger.SetSpriteColor(myColorIndex);
    }
}
