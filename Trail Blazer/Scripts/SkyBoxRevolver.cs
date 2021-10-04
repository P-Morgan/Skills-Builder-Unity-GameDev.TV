using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRevolver : MonoBehaviour
{
    [SerializeField] float revolveSpeed = 2f;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * revolveSpeed);
    }
}
