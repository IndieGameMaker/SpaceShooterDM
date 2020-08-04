using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExp : MonoBehaviour
{
    private int hitCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            hitCount = hitCount + 1; //++hitCount
            if (hitCount == 3)
            {
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 2000.0f);
    }
}
