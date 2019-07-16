﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FannelShoot : MonoBehaviour
{
    //入れる
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private GameObject Homing = null;

    public float Timer = 0;
    private float defalt = 0;
    public float interbal = 2;

    //回転の中心を取るために使う
    private GameObject targetPos;

    // Start is called before the first frame update
    void Start()
    {
        GameObject FirePos = GameObject.Find("Fannel");
        targetPos = FirePos;
    }

    // Update is called once per frame
    void Update()
    {
        Shot();
    }

    /// <summary>
    /// 弾を撃つ
    /// </summary>
    void Shot()
    {
        //回転し続けるファンネルをの位置を取得
        Vector3 FirePos = new Vector3(this.transform.position.x,
            this.transform.position.y, this.transform.position.z);

        //ここコルーチン使おう！
        //時間加算
        Timer += Time.deltaTime;
        if (Timer > interbal)
        {
            //時間を0に戻す
            Timer = defalt;
            for(int i = 0; i < 5; i++)
            {
                var GObullet = Instantiate(Homing, FirePos, transform.rotation);
            }
        }

        //スペースで発射
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var GObullet = Instantiate(bullet, FirePos, transform.rotation);
        }
    }
}
