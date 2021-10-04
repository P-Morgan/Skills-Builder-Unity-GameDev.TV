using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    float rotationSpeed;
    float rotationRange = 2f;
    float rotationExclutionRange = 0.4f;

    private void Awake()
    {
        rotationSpeed = Random.Range(-rotationRange, rotationRange);
    }
    void Update()
    {
        if (rotationSpeed > -rotationExclutionRange && rotationSpeed < rotationExclutionRange)
        {
            rotationSpeed = Random.Range(-rotationRange, rotationRange);
        }

        transform.Rotate(0f, 0f, rotationSpeed);
    }
}
