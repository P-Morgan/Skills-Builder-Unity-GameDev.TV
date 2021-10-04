using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemColorChanger : MonoBehaviour
{
    ColorChanger colorChanger;
    int myColorIndex;

    // Start is called before the first frame update
    void Start()
    {
        colorChanger = GetComponent<ColorChanger>();
        myColorIndex = colorChanger.WhatsMyColorIndex();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ColorChanger othersColorChanger = other.gameObject.GetComponent<ColorChanger>();
        othersColorChanger.SetSpriteColor(myColorIndex);
    }

}
