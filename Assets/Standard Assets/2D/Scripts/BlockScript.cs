using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    [SerializeField] private GameObject instantiateObject;
    [SerializeField] private GameObject whereToInstantiate;
    [SerializeField]
    private GameObject destroyObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Instantiate(instantiateObject, whereToInstantiate.transform.position, whereToInstantiate.transform.rotation);
            Destroy(destroyObject);
        }
    }
}
