using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    [SerializeField] private GameObject cannonBall;
    [SerializeField] private Transform cannonEnd;
    private float instantiateTimer;


    void Start()
    {
        instantiateTimer = 1.5f;
    }
    // Update is called once per frame
    void Update() {
        instantiateTimer -= Time.deltaTime;
        if (instantiateTimer <= 0)
        {
            instantiateTimer = 1.5f;
            Instantiate(cannonBall, cannonEnd.transform.position, cannonEnd.transform.rotation);
        }
    }
}
