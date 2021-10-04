// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    [SerializeField] float gameSpeed = 1f;

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

}
