using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totugekitest : MonoBehaviour
{
    //プレイヤー位置取得用
    Vector3 playerpos;
    //突撃前の位置
    Vector3 defaultPos;
    //突撃速度
    public float speed = 2;
    //突撃間隔
    public float timer = 3;
    //タイマー初期化用変数
    float InitTimer;
    //switch遷移用
    int state;

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        InitTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        //移動する時間の計算用
        float step = speed * Time.deltaTime;
        switch (state)
        {
            case 0:
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    timer = InitTimer;
                    //現在の位置を保存
                    defaultPos = this.transform.position;
                    state = 1;
                }
                break;
            case 1:
                //一度だけ位置を取得
                playerpos = GameObject.Find("Player").transform.position;
                state = 2;
                break;
            case 2:
                //その位置に向かう(自分の位置、ターゲットの位置、移動速度)
                this.transform.position = Vector3.MoveTowards(transform.position, playerpos, step);
                //プレイヤーがいた位置に来たら
                if (this.transform.position == playerpos)
                {
                    state = 3;
                }
                break;
            case 3:
                timer -= Time.deltaTime;
                if (timer < timer/2)
                {
                    //元居た位置に向かう(自分の位置、ターゲットの位置、移動速度)
                    this.transform.position = Vector3.MoveTowards(transform.position, defaultPos, step);
                    //元の位置に戻ったら
                    if (this.transform.position == defaultPos)
                    {
                        timer = InitTimer;
                        state = 0;
                    }
                }
                break;
            default:
                break;
        }
    }
}
