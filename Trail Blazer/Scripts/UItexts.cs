using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UItexts : MonoBehaviour
{
    // Start Text mover
    [SerializeField] GameObject StartTexts;
    [SerializeField] Vector3 endPositon;
    [SerializeField] float textMoveSpeed = 100f;
    Vector3 currentPosition;
    float startTime;
    float journeyLength;
    [SerializeField] GameObject player;
    [SerializeField] float textMovePosition = 9f;
    bool moveText = false;
    bool moveTextPrep = false;

    //Score text
    [SerializeField] GameObject score;
    TMP_Text scoring;
    int distanceTraveled;

    private void Awake()
    {
        StartTexts.SetActive(true);
        moveTextPrep = true;
        scoring = score.GetComponent<TMP_Text>();
        scoring.text = distanceTraveled.ToString();
    }
    public int sendScore()
    {
        return distanceTraveled;
    }
    private void Update()
    {
        distanceTraveled = (int)player.transform.position.x;
        scoring.text = distanceTraveled.ToString();

        if (player.transform.position.x >= textMovePosition && moveTextPrep == true) { MoveingPrep(); }
        if (moveText) { MoveStartText(); }
    }

    private void MoveingPrep()
    {
        //Text Moving Prep
        currentPosition = StartTexts.transform.position;
        startTime = Time.time;
        // Calculate the journey length.
        journeyLength = Vector3.Distance(currentPosition, endPositon);
        moveText = true;
        moveTextPrep = false;
        Debug.Log("prep done");
    }
    public void MoveStartText()
    {
            Debug.Log("start moving text");
            // Distance moved equals elapsed time times speed.
            float distCovered = (Time.time - startTime) * textMoveSpeed;
            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            StartTexts.transform.position = Vector3.Lerp(currentPosition, endPositon, fractionOfJourney);
            if (StartTexts.transform.position == endPositon) { moveText = false; }

        if (StartTexts.transform.position == endPositon)
        {
            Debug.Log("disable");
            StartTexts.SetActive(false);
            moveText = false;
        }
    }

}
