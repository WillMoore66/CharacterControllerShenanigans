using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{

    [SerializeField] private GameObject point1;
    [SerializeField] private GameObject point2;

    [SerializeField] private float maxDistance;
    [SerializeField] private float minDistance;

    [SerializeField] private float stiffness;

    public static Vector3 middlePoint;
    private float distance;

    public Vector3 forceOnPoint1;
    public Vector3 forceOnPoint2;

    void FixedUpdate()
    {
        distance = (point1.transform.position - point2.transform.position).magnitude;
        middlePoint = point1.transform.position + (point2.transform.position - point1.transform.position) / 2;

        if (distance < maxDistance && distance > minDistance)
        {
            return;
        }
        else
        {
            float extension = Mathf.Abs(distance) - maxDistance;
            float force = -stiffness * extension;
            forceOnPoint1 = (point1.transform.position - middlePoint) * force;
            forceOnPoint2 = (point2.transform.position - middlePoint) * force;
            point1.GetComponent<Rigidbody>().AddForce(forceOnPoint1);
            point2.GetComponent<Rigidbody>().AddForce(forceOnPoint2);
        }
    }

    private void OnDrawGizmos()
    {
        if (distance < maxDistance && distance > minDistance)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawLine(point1.transform.position, point2.transform.position);
    }
}
