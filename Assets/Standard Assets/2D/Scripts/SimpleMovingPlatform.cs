using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovingPlatform : MonoBehaviour {

    [SerializeField] private GameObject platform;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform[] points;
    [SerializeField] private int pointSelection;
    private Transform currentPoint;

	// Use this for initialization
	void Start () {
        currentPoint = points[pointSelection];
	}
	
	// Update is called once per frame
	void Update () {
       platform.transform.position = Vector3.MoveTowards(platform.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
        if(platform.transform.position == currentPoint.position)
        {
            pointSelection++;

            if(pointSelection == points.Length)
            {
                pointSelection = 0;
            }

            currentPoint = points[pointSelection];
        }

	}
    public int PointSelection
    {
        get
        {
            return pointSelection;
        }
    }

    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
    }
}
