// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [SerializeField] GameObject[] teleports;

    private void Start()
    {
        GetComponent<AreaEffector2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<TrailRenderer>().emitting = false;
        int index = Random.Range(0, teleports.Length);
        teleports[index].GetComponent<Collider2D>().isTrigger = false;
        collision.transform.position = teleports[index].transform.position;

        StartCoroutine(turnOnTrigger(index, collision.gameObject));
       // collision.gameObject.GetComponent<TrailRenderer>().emitting = true;
    }
    IEnumerator turnOnTrigger(int index, GameObject ball)
    {

        yield return new WaitForSeconds(0.01f);
        ball.GetComponent<TrailRenderer>().emitting = true;
        teleports[index].GetComponent<AreaEffector2D>().enabled = true;

        yield return new WaitForSeconds(0.15f);
        teleports[index].GetComponent<Collider2D>().isTrigger = true;
        teleports[index].GetComponent<AreaEffector2D>().enabled = false;

    }


}