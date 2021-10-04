using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncherPower : MonoBehaviour
{
    [SerializeField] GameObject parentGroup;

    [SerializeField] Vector2 startingPlace; // (-6.5,0)
    [SerializeField] Vector2 finishingPlace; // (6.5,0)
    [SerializeField] float movingSpeed = 1f;
    [SerializeField] Vector2 velocity = Vector2.zero;
    [SerializeField] AreaEffector2D ballLauncher;
    Vector2 target;
    private void Awake()
    {
        parentGroup.SetActive(true);
    }

    void Start()
    {
        transform.position = new Vector2(startingPlace.x + 1f, startingPlace.y);
        target = finishingPlace;
    }
    void Update()
    {
        transform.position = Vector2.SmoothDamp(transform.position, target, ref velocity, movingSpeed * Time.deltaTime);

        Direction();

        if (Input.GetKeyDown(KeyCode.Space) && parentGroup.activeSelf == true) { CalculateForce(); }
        if (Input.GetKeyUp(KeyCode.Space)) { ballLauncher.enabled = false; }
    }
    private void Direction()
    {
        Vector2 currentPosition = transform.position;
        // SmoothDamp goes to slow near the end for where i'd like, so set the start/finish positions 1f further away,
        // and activated the direction switch sooner (by 1f)
        if (currentPosition.x >= finishingPlace.x - 1f) { target = startingPlace; }
        else if (currentPosition.x <= startingPlace.x + 1f) { target = finishingPlace; }
        else return;
    }

    private void CalculateForce()
    {
        float midPosition = finishingPlace.x + startingPlace.x;
        // finishplace.x = 6.5,  startplace.x = -6.5, so to get 0, need to plus them,

        float targetPosition = transform.position.x;
        if (targetPosition <= midPosition)
        {
            float force = (targetPosition - startingPlace.x - 0.99f) * 181f;
            // max force aimed for is 1000f, requires * 181f to get that if the target is in the centre (0)
            // 0 - -6.5 -0.99f = 5.51,  *181 = 997.31,.. close enough :)
            // 0.99 ensures i dont multiply by 0.
            // if its at futhest end,. -5.5 - -6.5 - 0.99f = 0.01 * 181f = 1.81 force.
            ballLauncher.forceMagnitude = force;
           
        }
        else if (targetPosition >= midPosition)
        {
            float force = (finishingPlace.x - targetPosition - 0.99f) * 181f;
            ballLauncher.forceMagnitude = force;
        }
        ballLauncher.enabled = true;
    }
}
