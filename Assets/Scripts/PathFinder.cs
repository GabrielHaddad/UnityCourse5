using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    [SerializeField] WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Following path " + waveConfig);
        FollowPath();
    }

    void FollowPath()
    {
        Debug.Log("WaypointIndex " + waypointIndex + " Name: " + waveConfig);
        Debug.Log("waypoints.Count " + waypoints.Count + " Name: " + waveConfig);
        
        foreach(Transform way in waypoints)
        {
            Debug.Log("waypoints " + way.position + " Name: " + waveConfig);

        }

        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
