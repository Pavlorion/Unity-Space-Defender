using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;
    
    float moveSpeed;
    int waypointsIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = waveConfig.GetMoveSpeed();
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfigPar)
    {
        waveConfig = waveConfigPar;
    }

    private void Move()
    {
        if (waypointsIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointsIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards
                (transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointsIndex++;
            }
        }
        else

        {
            Destroy(gameObject);
        }
    }
}
