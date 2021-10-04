// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private GameHandler gameHandler;
    ColorChanger colorChanger;
    int myColorIndex;

    void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
        colorChanger = GetComponent<ColorChanger>();
        myColorIndex = colorChanger.WhatsMyColorIndex();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            ColorChanger blocksColorChanger = collision.gameObject.GetComponent<ColorChanger>();
            int blocksColorIndex = blocksColorChanger.WhatsMyColorIndex();
            if (myColorIndex != blocksColorIndex)
            {
                if (collision.gameObject.GetComponent<BlockMovement>().isActiveBool)
                {
                    Destroy(collision.gameObject);
                    gameHandler.AllPlayerBlocksArrayUpdate();
                    gameHandler.DestroyedBlockUpdate();
                }
                else
                {
                    Destroy(collision.gameObject);
                }
            }

        }
    }
}
