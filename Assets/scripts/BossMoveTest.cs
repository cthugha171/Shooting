using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveTest : MonoBehaviour
{
    //プレイヤー位置取得用
    Vector3 playerpos;
    //移動時に向かう位置
    Vector3 MoveVerticle;
    //移動速度
    float speed = 3;
    //ボスアクション遷移用
    float Timer = 5;
    //タイマー初期化用変数
    float ResetTimer;
    //BossShotをまとめたプレファブ
    public GameObject BossShoot;
    //プレファブを操作するため
    GameObject FireShot;

    public ParticleSystem BeamParticle;
    private GameObject BeamCollider;

    #region 突撃に使った変数たち

    //突撃前の位置
    Vector3 defaultPos;
    //突撃間隔
    public float timer = 3;
    //突撃タイマー初期化用変数
    float InitTimer;
    //switch遷移用
    int state;
    //ランダム使用するための変数
    float NextMove;
    //突撃速度
    float totuSpeed = 6;
    //突撃し終わったかどうかの判定
    bool totu = false;
    #endregion

    private enum BossState
    {
        Move,//移動
        Shot,//攻撃
        Totugeki,//突進
        Beam,//ボスビーム
        DecideMove,//ボスの行動決定
    }
    BossState bossState;

    // Start is called before the first frame update
    void Awake()
    {
        //タイマーを代入して初期化できるようにする
        ResetTimer = Timer;

        BeamParticle = GetComponent<ParticleSystem>();
        //BeamParticle.Stop();
        BeamCollider = transform.GetChild(1).gameObject;
        BeamCollider.SetActive(false);

        //初期化
        InitTimer = timer;
        StartCoroutine("BeamShot");
    }

    // Update is called once per frame
    void Update()
    {
        //BossStateChanger();
        //Debug.Log(bossState);
    }

    //ボスの基本の移動
    void Move()
    {
        float step = speed * Time.deltaTime;
        playerpos = GameObject.Find("Player").transform.position;
        MoveVerticle = new Vector3(0, playerpos.y, this.transform.position.z);
        this.transform.position = Vector3.MoveTowards(transform.position, MoveVerticle, step);
    }

    void BossStateChanger()
    {
        switch (bossState)
        {
            //動くモード
            case BossState.Move:
                //動きます
                Move();
                //タイマーを減らす
                Timer -= Time.deltaTime;
                //タイマーが0より小さくなったら
                if (Timer < 0)
                {
                    //タイマーを初期化
                    Timer = ResetTimer;
                    //移動モード終了
                    bossState = BossState.DecideMove;
                }
                break;
            //弾発射モード
            case BossState.Shot:
                //タイマーが初期化されたとき弾を発射状態にする
                if (Timer == ResetTimer) OnBossShot();
                //弾を撃った状態で動く
                Move();
                //時間を減らす
                Timer -= Time.deltaTime;
                //タイマーが0よりちいさくなったら
                if (Timer < 0)
                {
                    //タイマーを初期化
                    Timer = ResetTimer;
                    //弾を撃つモード終了
                    bossState = BossState.DecideMove;
                }
                break;
            //突撃モード
            case BossState.Totugeki:
                //突撃する（エラーの原因はここ
                //突撃の途中でも強制終了しているため、変な場所で次のモーションに入っている）
                //（突撃させたい回数をfor文で回せれば解決しそう）
                BossTotugeki();
                if (totu)
                {
                    //突撃終了
                    bossState = BossState.DecideMove;
                }
                break;
            case BossState.Beam:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //ビーム終了
                    bossState = BossState.DecideMove;
                    //ここ下にコルーチンを書くといいらしい？
                    StartCoroutine("BeamShot");
                }
                break;
            case BossState.DecideMove:
                //一応タイマーを初期化
                Timer = ResetTimer;
                //突撃状態初期化
                totu = false;
                //弾発射状態終了
                if (Timer == ResetTimer) OffBossShot();
                StopCoroutine("BeamShot");
                //次の行動を決定
                NextMove = Random.Range(0, 4);
                if (NextMove == 0) bossState = BossState.Move;//0なら移動
                if (NextMove == 1) bossState = BossState.Shot;//1ならショット
                if (NextMove == 2) bossState = BossState.Totugeki;//2なら突撃
                break;
            default:
                break;
        }
    }

    //ボスの弾発射開始
    void OnBossShot()
    {
        FireShot = Instantiate(BossShoot, this.transform.position, this.transform.rotation);
        FireShot.transform.parent = transform;//自分の子どもとして登録
    }
    //ボスの弾発射終了
    void OffBossShot()
    {
        //子供を削除
        Destroy(FireShot);
    }
    //ボスの突撃
    void BossTotugeki()
    {
        //移動する時間の計算用
        float step = totuSpeed * Time.deltaTime;
        switch (state)
        {
            case 0:
                timer -= Time.deltaTime;
                if (timer / 2 < 0)
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
                if (timer / 2 < 0)
                {
                    //元居た位置に向かう(自分の位置、ターゲットの位置、移動速度)
                    this.transform.position = Vector3.MoveTowards(transform.position, defaultPos, step);
                    //元の位置に戻ったら
                    if (this.transform.position == defaultPos)
                    {
                        timer = InitTimer;
                        state = 0;
                        totu = true;
                    }
                }
                break;
            default:
                break;
        }
    }

    IEnumerator BeamShot()
    {
        //五秒動いて
        Move();
        yield return new WaitForSeconds(2.0f);

        //点滅したり、エネルギー溜めたりする
        Debug.Log("チャージ中...");
        yield return new WaitForSeconds(3.0f);

        //弾道予測線を出したら
        Debug.Log("弾道予測線表示..");
        yield return new WaitForSeconds(1.0f);

        //ビームを発射!!!
        //BeamParticle.Stop();
        //BeamParticle.Play();
        BeamCollider.SetActive(true);
        Debug.Log("発射！！");
        yield return new WaitForSeconds(5.0f);

        //ビーム停止
        //BeamParticle.Stop();
        BeamCollider.SetActive(false);
        Debug.Log("終了");
        bossState = BossState.DecideMove;

        //ビームのことについて先生に聞きに行こう！
        //子オブジェクトのパーティクルを制御する方法
        //処理が終了したら次のstateに移動する方法
        //
    }
}
