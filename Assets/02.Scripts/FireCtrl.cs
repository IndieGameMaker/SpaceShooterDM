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

    private RaycastHit hit;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash.enabled = false;
    }

    void Update()
    {
        Debug.DrawRay(firePos.position, firePos.forward * 10.0f, Color.green);

        if (Input.GetMouseButtonDown(0) == true)
        {
            Fire();

            if (Physics.Raycast(firePos.position, firePos.forward, out hit, 10.0f))
            {
                Debug.Log("Hit=" + hit.collider.gameObject.name);
            }
        }   

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }     
    }

    void Fire()
    {
        //Instantiate(생성할객체, 위치, 각도)
        //Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        audio.PlayOneShot(fireSfx, 0.8f);

        StartCoroutine(ShowMuzzleFlash());
    }

    IEnumerator ShowMuzzleFlash()
    {
        //불규칙한 텍스처 Offset
        Vector2 offset = new Vector2(Random.Range(0,2), Random.Range(0,2)) * 0.5f; //0, 0.5
        muzzleFlash.material.mainTextureOffset = offset;
        //muzzleFlash.material.SetTextureOffset("_MainTex", offset);

        //불규칙한 크기 조정
        muzzleFlash.transform.localScale = Vector3.one * Random.Range(1.5f, 3.5f);

        //불규칙한 회전
        muzzleFlash.transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0,360));


        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(0.25f);
        muzzleFlash.enabled = false;
    }
}
