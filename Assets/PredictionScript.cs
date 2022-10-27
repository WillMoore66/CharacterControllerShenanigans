using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictionScript : MonoBehaviour
{
    float timeToPredict = 5.0f;
    private Rigidbody rb;
    private LineRenderer lineRenderer;
    [SerializeField] private GameObject gravController;
    private Vector3 force;
    [SerializeField] private GameObject predictee;

    private void Start()
    {
        //lineRenderer.useWorldSpace = true;
        lineRenderer.positionCount = 0;
        //force = gravController.GetComponent<SpringScript>().forceOnPoint1;
    }

    private void Update()
    {
        predictPos(predictee);
    }

    public void predictPos(GameObject target)
    {
        force = gravController.GetComponent<SpringScript>().forceOnPoint1;
        rb = target.GetComponent<Rigidbody>();
        lineRenderer = target.GetComponent<LineRenderer>();

        Vector3 predictedPosition = transform.position;
        Vector3 gravity =  force * Time.deltaTime;
        Vector3 velocity = rb.velocity;

        List<Vector3> positions = new List<Vector3>();

        for (float t = Time.deltaTime; t <= timeToPredict; t += Time.deltaTime)
        {
            velocity += gravity;
            predictedPosition += velocity * Time.deltaTime;
            positions.Add(predictedPosition);
        }

        Vector3[] positionsArray = positions.ToArray();
        lineRenderer.positionCount = positionsArray.Length;
        lineRenderer.SetPositions(positionsArray);
    }
}
