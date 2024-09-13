using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1 : MonoBehaviour
{
    // YOUR VARIABLES HERE
    public Transform[] waypoints = new Transform[5];
    public float speed;
    public float range;
    private Transform currentTarget;
    private int startIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        // YOUR CODE HERE
        currentTarget = waypoints[startIndex];
    }

    // Update is called once per frame
    void Update()
    {
        // YOUR CODE HERE
        Move(currentTarget, speed);
        if (IsDistanceLessThan(currentTarget, range))
        {
            if (startIndex < waypoints.Length - 1)
            {
                startIndex++;
            }
            else
            {
                startIndex = 0;
            }
            currentTarget = waypoints[startIndex];
        }
    }

    // YOUR MOVE FUNCTION(s) HERE (might be a good opportunity to demonstrate overloading)
    public void Move(Transform target, float speed)
    {
        if (target != null)
        {
            Move(target.position, speed);
        }
    }

    public void Move(Vector3 target, float speed)
    {
        Vector3 resultVec = target - transform.position;

        transform.position += resultVec.normalized * speed * Time.deltaTime;
    }

    // YOUR DISTANCE CHECK FUNCTION HERE
    public bool IsDistanceLessThan(Transform target, float range)
    {
        if (Vector3.Distance(target.position, transform.position) <= range)
        {
            return true;
        }
        return false;
    }
}
