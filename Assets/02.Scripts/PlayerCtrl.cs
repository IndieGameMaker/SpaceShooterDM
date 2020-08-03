using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnim
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runLeft;
    public AnimationClip runRight;
    public AnimationClip[] dies;
}

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float turnSpeed = 50.0f;
    public PlayerAnim playerAnim;
    private Transform tr;
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>(); // tr = GetComponent("Transform") as Transform;
        anim = this.gameObject.GetComponent<Animation>();

        //Switching Idle Animation Clip
        anim.Play(playerAnim.idle.name);
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");  //-1.0f ~ 0.0f ~ 1.0f
        float v = Input.GetAxis("Vertical");    //-1.0f ~ 0.0f ~ 1.0f
        float r = Input.GetAxis("Mouse X");

        // Debug.Log("h=" + h); //Console View에 문자열을 출력
        // Debug.Log($"v={v}"); //Debug.Log("v=" + v);

        //transform.position += new Vector3(0, 0, 0.1f);
        //transform.position += Vector3.forward * 0.1f;
        /* Normalized Vector (정규화 벡터)
            Vector3.forward = Vector3(0, 0, 1)
            Vector3.up      = Vector3(0, 1, 0)
            Vector3.right   = Vector3(1, 0, 0)

            Vector3.zero    = Vector3(0, 0, 0)
            Vector3.one     = Vector3(1, 1, 1)
        */

        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);
        transform.Rotate(Vector3.up * r * Time.deltaTime * turnSpeed);

        // transform.Translate(Vector3.forward * 0.1f * v);
        // transform.Translate(Vector3.right * 0.1f * h);

    }
}
