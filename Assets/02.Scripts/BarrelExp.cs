using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExp : MonoBehaviour
{
    private int hitCount = 0;
    [System.NonSerialized]
    [HideInInspector]
    public GameObject expEffect;

    public AudioClip expSfx;
    private AudioSource _audio;

    public Texture[] textures;
    public MeshRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _audio = this.gameObject.AddComponent<AudioSource>();
        expEffect = Resources.Load<GameObject>("BigExplosionEffect");

        _renderer = this.gameObject.GetComponentInChildren<MeshRenderer>();

        int idx = Random.Range(0, textures.Length);
        _renderer.material.mainTexture = textures[idx];
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
        _audio.PlayOneShot(expSfx);
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 2000.0f);

        Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject, 2.0f);

        // Rigidbody rb = null;
        // hitCount = 0;
        // if (GetComponent<Rigidbody>() == null)
        // {
        //     rb = this.gameObject.AddComponent<Rigidbody>();
        //     rb.AddForce(Vector3.up * 2000.0f);
        // }
        // else
        // {   
        //     rb = GetComponent<Rigidbody>();
        //     rb.AddForce(Vector3.up * 2000.0f);
        // }
    }
}
