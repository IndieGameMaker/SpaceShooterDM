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

        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);
        transform.Rotate(Vector3.up * r * Time.deltaTime * turnSpeed);

        if (v >= 0.1f) //전진
        {
            anim.CrossFade(playerAnim.runForward.name, 0.3f);
        }
        else if (v <= -0.1f) //후진
        {
            anim.CrossFade(playerAnim.runBackward.name, 0.3f);
        }
        else if (h >= 0.1f)  //오른쪽
        {
            anim.CrossFade(playerAnim.runRight.name, 0.3f);
        }
        else if (h <= -0.1f) //왼쪽
        {
            anim.CrossFade(playerAnim.runLeft.name, 0.3f);
        }
        else
        {
            anim.CrossFade(playerAnim.idle.name, 0.3f);
        }
    }
}
