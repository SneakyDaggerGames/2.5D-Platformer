using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed = 3f;

    private void Start()
    {
        target = pointB;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        float distance = Vector3.Distance(transform.position, target.position);
        if (target == pointB && distance < 1f)
        {
            target = pointA;
        }
        else if (target == pointA && distance < 1f)
        {
            target = pointB;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }
}
