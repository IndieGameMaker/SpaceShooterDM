using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FireCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;

    [SerializeField]
    private new AudioSource audio; 
    public AudioClip fireSfx;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            //Instantiate(생성할객체, 위치, 각도)
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            audio.PlayOneShot(fireSfx, 0.8f);
        }        
    }
}
