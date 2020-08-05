using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    private Transform monsterTr;    //몬스터의 Transform
    private Transform playerTr;     //주인공의 Transform
    private NavMeshAgent agent;     //네브메시에이젼트 컴포넌트
    private Animator anim;          //메카님 에니메이터 컴포넌트

    void Start()
    {
        //monsterTr = this.gameObject.GetComponent<Transform>();
        monsterTr = transform;
        agent     = GetComponent<NavMeshAgent>();
        anim      = GetComponent<Animator>();
        playerTr  = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
        
        // GameObject playerObj = GameObject.FindGameObjectWithTag("PLAYER");
        // if (playerObj != null)
        // {
        //     playerTr = playerObj.GetComponent<Transform>();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerTr.position);
    }

    int hp = 100;
    public void OnDamage()
    {
        hp -= 10;
        if (hp <= 0)
        {
            MonsterDie();
        }
    }

    public void MonsterDie()
    {
        anim.SetTrigger("die");
    }
}
