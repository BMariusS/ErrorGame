using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallMoving : MonoBehaviour {

    [SerializeField] private GameObject spikeBall;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform[] points;
    [SerializeField] private int pointSelection;
    private Transform currentPoint;


    // Use this for initialization
    void Start()
    {
       currentPoint = points[pointSelection];
    }

    // Update is called once per frame
    void Update()
    {
        spikeBall.transform.position = Vector3.MoveTowards(spikeBall.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
                if (spikeBall.transform.position == currentPoint.position)
                {
                    pointSelection++;

                    if (pointSelection == points.Length)
                    {
                        pointSelection = 0;
                    }

                    currentPoint = points[pointSelection];
                }
    }
}
