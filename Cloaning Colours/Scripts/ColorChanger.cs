// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    private SpriteRenderer mySpriteRenderer;


   [SerializeField] Color[] spriteColor = new Color[] { Color.red, Color.yellow, Color.blue, Color.green, Color.black };
    [SerializeField] int colorIndex = 0;

    Animator anim;
    [SerializeField] float flashLength = 2f;

    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    private void Start()
    {
        SetSpriteColor(colorIndex);
    }

    public void SetSpriteColor(int index)
    {
        colorIndex = index;
        mySpriteRenderer.color = 
            spriteColor[colorIndex];
    }

    public int WhatsMyColorIndex()
    {
        return colorIndex;
    }

    public int SpriteColorLength()
    {
        return spriteColor.Length;
    }
    IEnumerator flashingAlpha()
    {
        anim.SetBool("IsFlashing", true);
        yield return new WaitForSeconds(flashLength);
        anim.SetBool("IsFlashing", false);
    }

}
