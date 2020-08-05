using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            ContactPoint[] cp = coll.contacts;
            Vector3 _normal = cp[0].normal;    //법선 벡터
            Vector3 _pos    = cp[0].point;     //충동 위치

            Quaternion rot = Quaternion.LookRotation(_normal);
            var effect = Instantiate(sparkEffect, _pos, rot);
            Destroy(effect, 0.3f);

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
