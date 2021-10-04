// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform planet;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float defaultSpeed = 15f;
    float sensitivity = 17f;

    float minFov = 10;
    float maxFov = 100;

    private void Start()
    {
        Camera.main.fieldOfView = 70;
    }

    private void Update()
    {
        transform.RotateAround(planet.position, transform.right, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.RotateAround(planet.position, transform.up, -Input.GetAxis("Horizontal") * speed * Time.deltaTime);

        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}