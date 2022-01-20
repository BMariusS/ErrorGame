using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallMoving : MonoBehaviour {

    [SerializeField]
    private GameObject cannonBall;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private GameObject cannonBallEnd;

    // Update is called once per frame
    void Update()
    {
        cannonBall.transform.position = Vector2.MoveTowards(cannonBall.transform.position, cannonBallEnd.transform.position, Time.deltaTime * moveSpeed);

        if(cannonBall.transform.position == cannonBallEnd.transform.position)
        {
            Destroy(gameObject);
        }
    }
}
