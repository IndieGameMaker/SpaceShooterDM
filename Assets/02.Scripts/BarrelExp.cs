using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExp : MonoBehaviour
{
    private int hitCount = 0;
    public GameObject expEffect;

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
        Rigidbody rb = null;
        hitCount = 0;
        if (GetComponent<Rigidbody>() == null)
        {
            rb = this.gameObject.AddComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 2000.0f);
        }
        else
        {   
            rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 2000.0f);
        }
    }
}
