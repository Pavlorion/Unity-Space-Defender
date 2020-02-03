using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject wayPathPrefab;
    [SerializeField] float timeBetweenSpawns = 2f;
    [SerializeField] float randomFactor = 0.3f;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] int numberOfEnemies = 5;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWayPoints()
    {
        var wayPoints = new List<Transform>();
        foreach(Transform child in wayPathPrefab.transform)
        {
            wayPoints.Add(child);
        }

        return wayPoints;
    }

    public float GetTime()
    {
        return timeBetweenSpawns;
    }

    public float GetRandom()
    {
        return randomFactor;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

}
