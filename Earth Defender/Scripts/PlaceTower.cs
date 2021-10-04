// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] Transform planetCore;
    [SerializeField] Transform asteroidBelt;

    Vector3 targetPos;

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 hitPoint = hit.point - new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y, hit.collider.transform.position.z);

            GameObject newTower = Instantiate(towerPrefab, hitPoint, Quaternion.FromToRotation(Vector3.up, hit.point));

        }
    }
}
