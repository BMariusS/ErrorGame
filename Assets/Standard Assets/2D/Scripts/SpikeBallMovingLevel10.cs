using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallMovingLevel10 : MonoBehaviour {

    [SerializeField]
    private GameObject spikeBall;
    [SerializeField]
    private GameObject place;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private int pointSelection;
    private Transform currentPoint;
    private GameObject findPlayer;


    // Use this for initialization
    void Start()
    {
        currentPoint = points[pointSelection];
        findPlayer = GameObject.Find("CharacterRobotBoy");
    }

    // Update is called once per frame
    void Update()
    {
        UnityStandardAssets._2D.PlatformerCharacter2D player = findPlayer.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
        spikeBall.transform.position = Vector3.MoveTowards(spikeBall.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
        if (!player.M_IsAlive)
        {
            spikeBall.transform.position = new Vector2(place.transform.position.x, place.transform.position.y);
            currentPoint = points[1];
        }
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
