using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float _enemySpeed = 1.5f;

    private Transform target;

    private int wavepointIndex = 0;

    private Wave _waveManager;

    void Start ()
    {
        target = Waypoints.points[0];
        _waveManager = FindObjectOfType<Wave>();
    }

    void Update ()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * _enemySpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoinnt();
        }
    }

    void GetNextWaypoinnt()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            _waveManager.EnemyDeath();
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
