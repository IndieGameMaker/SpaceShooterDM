using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");  //-1.0f ~ 0.0f ~ 1.0f
        float v = Input.GetAxis("Vertical");    //-1.0f ~ 0.0f ~ 1.0f

        Debug.Log("h=" + h); //Console View에 문자열을 출력
        Debug.Log($"v={v}"); //Debug.Log("v=" + v);
    }
}
