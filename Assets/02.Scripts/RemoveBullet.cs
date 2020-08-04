using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        // if (coll.gameObject.tag == "BULLET")
        // {
        //     Destroy(coll.gameObject);
        // }
        if (coll.collider.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);
        }
    }

    // private void OnCollisionStay(Collision other)
    // {
        
    // }
    // private void OnCollisionExit(Collision other)
    // {
        
    // }
}
