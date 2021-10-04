// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HideAI : MonoBehaviour
{
    [SerializeField] float WaitBeforeMoveMin = 0.5f;
    [SerializeField] float WaitBeforeMoveMax = 3f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        foreach (Vector3 point in RandomPoints(1, 100))
        {

            if (CanBeSeenByPlayer(point)) { Debug.Log("play can see me, search again " + point); yield return null; }
            else
            {
                agent.SetDestination(point);

                while (NavMeshAgentIsMoving())
                {
                    yield return new WaitForSeconds(0.5f);
                }

                yield return new WaitForSeconds(Random.Range(WaitBeforeMoveMin, WaitBeforeMoveMax));

                while (!CanBeSeenByPlayer(transform.position))
                {
                    yield return new WaitForSeconds(0.5f);
                }
            }
        }
    }
    IEnumerable<Vector3> RandomPoints(float interval, float maxDistance)
    {
        Vector3 location = transform.position;
        bool searchAgain = false;
        while (searchAgain == false)
        {
            for (float distance = interval; distance < maxDistance; distance += interval)
            {
                Vector2 randomCircle = Random.insideUnitCircle * distance;
                Vector3 randomOffset = new Vector3(randomCircle.x, 0, randomCircle.y);
                Debug.Log("can i Go here " + (location + randomOffset));
                if (NavMesh.SamplePosition(location + randomOffset, out NavMeshHit hit, 2f, NavMesh.GetAreaFromName("Not Walkable")))
                {
                    Debug.Log("navmesh not Walkable, use this instead " + hit.position);
                    yield return hit.position;
                    searchAgain = true;
                }
                else
                {
                    Debug.Log(hit.position + " navmesh false Go try again " + (location + randomOffset));
                }
            }
        // check locations, see what its reporting back each time, might need to ditch the false, and make it rerun search
        }
    }



    bool NavMeshAgentIsMoving()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        return agent.pathPending || agent.remainingDistance > 0;
    }

    bool CanBeSeenByPlayer(Vector3 point)
    {
        Vector3 direction = point - Camera.main.transform.position;
        float distance = direction.magnitude;
        if (Physics.Raycast(Camera.main.transform.position, direction, distance))
        {
            return false;
        }
        return true;
    }
}
