﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;

    GameObject InGMObject;
    GameManager InGMScript;

    //範囲制限
    public float Clampz;
    public float Clampy;
    private Vector3 playerpos;

    //移動
    float MoveHor;
    float MoveVer;


    private void Start()
    {
        InGMObject = GameObject.Find("GameManager");
        InGMScript = InGMObject.GetComponent<GameManager>();
        //プレイヤーの位置を取得
        playerpos = this.transform.position;
    }
    void Update()
    {
        Move();
        Clamp();
    }

    /// <summary>
    /// 画面外に出ないようにする
    /// </summary>
    void Clamp()
    {
        playerpos.y = Mathf.Clamp(playerpos.y, -Clampy, Clampy);
        playerpos.z = Mathf.Clamp(playerpos.z, -Clampz, Clampz);

        transform.position = playerpos;
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    void Move()
    {
        int State = InGMScript.ICsta;
        switch (State)
        {
            case 0://縦画面の時の移動
                //横移動
                MoveHor = Input.GetAxisRaw("Horizontal");
                //縦移動
                MoveVer = Input.GetAxisRaw("Vertical");
                //代入
                playerpos += new Vector3(0, MoveVer, MoveHor) * speed;
                break;
            case 1://横画面の時の移動
                //横移動
                MoveHor = Input.GetAxisRaw("Horizontal");
                //縦移動
                MoveVer = Input.GetAxisRaw("Vertical");
                //代入
                playerpos += new Vector3(0, -MoveHor, MoveVer) * speed;
                break;
            default:
                break;
        }
    }
}