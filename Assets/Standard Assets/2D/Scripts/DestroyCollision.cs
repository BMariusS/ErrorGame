using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Boss")
        {
            BoxCollider2D[] myColliders = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D bc in myColliders) bc.enabled = false;
        }
    }
}
