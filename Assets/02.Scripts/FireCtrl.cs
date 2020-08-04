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

    //MuzzleFlash
    public MeshRenderer muzzleFlash;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Fire();
        }        
    }

    void Fire()
    {
        //Instantiate(생성할객체, 위치, 각도)
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        audio.PlayOneShot(fireSfx, 0.8f);

        StartCoroutine(ShowMuzzleFlash());
    }

    IEnumerator ShowMuzzleFlash()
    {
        //불규칙한 텍스처 Offset
        Vector2 offset = new Vector2(Random.Range(0,2), Random.Range(0,2)) * 0.5f; //0, 0.5
        muzzleFlash.material.mainTextureOffset = offset;
        //muzzleFlash.material.SetTextureOffset("_MainTex", offset);

        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(0.25f);
        muzzleFlash.enabled = false;
    }
}
