using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class crawlingenemies : MonoBehaviour
{
    public float movespeed;
    public GameObject[] waypoints;

    int nextwaypoint = 1;
    float disttopoint;

    private void Update()
    {
        move();
    }

    void move()
    {
        disttopoint = Vector2.Distance(transform.position, waypoints[nextwaypoint].transform.position);
        transform.position = Vector2.MoveTowards(transform.position, waypoints[nextwaypoint].transform.position, movespeed * Time.deltaTime);

        if (disttopoint < 0.2f)
        {
            TakeTurn();
        }
    }

    void TakeTurn()
    {
        Vector3 currRot = transform.rotation.eulerAngles;
        currRot.z += waypoints[nextwaypoint].transform.rotation.eulerAngles.z;
        transform.rotation = Quaternion.Euler(currRot);
        ChooseNextWaypoint();
    }

    void ChooseNextWaypoint()
    {
        nextwaypoint++;

        if (nextwaypoint >= waypoints.Length)
        {
            nextwaypoint = 0;
        }
    }
}