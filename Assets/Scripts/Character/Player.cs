using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private enum State
    {
        Move,
        Battle
    }

    private State currentState = State.Move;    //角色状态
    private CharacterController m_controller;   //角色控制器
    private Animator m_animator;                //动画控制
    private float moveSpeed = 3;                //移动速度

    private void Awake()
    {
        m_animator = this.GetComponent<Animator>();
        m_controller = this.GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        //角色状态机
        switch (currentState)
        {
            //移动状态
            case State.Move:
                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");
                //向量整合要规范化（向量长度转化为1），以防斜走时速度大于正常速度
                Vector3 nextDir = new Vector3(x, 0, z).normalized;
                //移动
                m_controller.Move(nextDir * moveSpeed * Time.deltaTime);
                //移动动画
                m_animator.SetFloat("move", Mathf.Abs(x) + Mathf.Abs(z));
                //转向
                transform.forward = Vector3.Lerp(transform.forward, nextDir, .3f);
                break;
                //战斗状态
            case State.Battle:
                break;
        }
    }
}
