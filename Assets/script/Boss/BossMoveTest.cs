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
    //ボスビームの当たり判定用のコライダーの状態
    private GameObject BeamCollider;
    //弾道予測線
    private GameObject RedLine;
    //点滅用
    private Renderer renderer;
    //ボスのパーティクル
    private ParticleSystem[] particles;

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

    //ボスの状態一覧
    private enum BossState
    {
        Move,//移動
        Shot,//攻撃
        Totugeki,//突進
        Beam,//ボスビーム
        DecideAction,//ボスの行動決定
    }
    //ボスの状態宣言
    BossState bossState;

    // Start is called before the first frame update
    void Awake()
    {
        //タイマーを代入して初期化できるようにする
        ResetTimer = Timer;
        particles = GetComponentsInChildren<ParticleSystem>();
        BeamCollider = transform.GetChild(1).gameObject;//1はビーム本体
        RedLine = transform.GetChild(2).gameObject;//2は弾道予測線
        BeamCollider.SetActive(false);//ビームの当たり判定
        RedLine.SetActive(false);//ビームの表示
        //色変更に使ったやつ
        renderer = GetComponent<Renderer>();
        //突撃タイマーの初期化
        InitTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        BossStateChanger();
    }

    //ボスの状態変更
    void BossStateChanger()
    {
        switch (bossState)
        {
            case BossState.Move:
                Move();
                Timer -= Time.deltaTime;
                if (Timer < 0)
                {
                    Timer = ResetTimer;
                    ChangeState(BossState.DecideAction);
                }
                break;
            case BossState.Shot:
                //タイマーが初期化されたとき弾を発射状態にする
                if (Timer == ResetTimer) OnBossShot();
                Move();
                Timer -= Time.deltaTime;
                if (Timer / 2 < 0)
                {
                    Timer = ResetTimer;
                    ChangeState(BossState.DecideAction);
                }
                break;
            case BossState.Totugeki:
                BossTotugeki();
                if (totu)
                {
                    ChangeState(BossState.DecideAction);
                }
                break;
            case BossState.Beam:

                //終了処理はBeamShot()に直接入ってる

                break;
            case BossState.DecideAction:
                DecideAction();
                break;
            default:
                break;
        }
    }
    //ボスの基本の移動
    void Move()
    {
        float step = speed * Time.deltaTime;
        playerpos = GameObject.FindGameObjectWithTag("Player").transform.position;
        MoveVerticle = new Vector3(0, playerpos.y, this.transform.position.z);
        this.transform.position = Vector3.MoveTowards(transform.position, MoveVerticle, step);
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
        //色を変更
        renderer.material.color = Color.green;
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
                playerpos = GameObject.FindGameObjectWithTag("Player").transform.position;
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
                        //色を戻す  
                        renderer.material.color = Color.white;
                        totu = true;
                    }
                }
                break;
            default:
                break;
        }
    }
    //ボスのビーム
    IEnumerator BeamShot()
    {
        //2秒動いて
        //Time.timeSinceLevelLoadはゲームを起動してからの時間
        //コルーチンの中で使うのであれば、Time.deltaよりいいらしい
        float endTime = Time.timeSinceLevelLoad + 2.0f;
        Debug.Log("プレイヤーの位置を補足...");
        while (endTime > Time.timeSinceLevelLoad)
        {
            Move();
            yield return null;
        }

        //動きを止める
        //点滅したり、エネルギー溜めたりする
        Debug.Log("チャージ中...");
        particles[1].Play();
        yield return new WaitForSeconds(3.0f);

        //弾道予測線を出したら
        particles[1].Stop();
        Debug.Log("弾道予測線表示..");
        RedLine.SetActive(true);
        yield return new WaitForSeconds(2.0f);

        //ビームを発射!!!
        RedLine.SetActive(false);
        particles[0].Stop();
        particles[0].Play();
        BeamCollider.SetActive(true);
        Debug.Log("発射！！");
        yield return new WaitForSeconds(5.0f);

        //ビーム停止
        particles[0].Stop();
        BeamCollider.SetActive(false);
        Debug.Log("終了");
        bossState = BossState.DecideAction;
    }
    //ボスの行動を決める
    void DecideAction()
    {
        //一応タイマーを初期化
        Timer = ResetTimer;
        //突撃状態初期化
        totu = false;
        //弾発射状態終了
        if (Timer == ResetTimer) OffBossShot();
        StopCoroutine("BeamShot");
        //次の行動を決定
        NextMove = Random.Range(0, 9);
        if (NextMove == 0) ChangeState(BossState.Move); //0なら移動
        if (0 < NextMove && NextMove <= 6) ChangeState(BossState.Shot); //0<x<=6ならショット
        if (NextMove == 7) ChangeState(BossState.Totugeki); //7なら突撃
        if (NextMove == 8) ChangeState(BossState.Beam);//8ならビーム
    }
    //ボスの状態がビームになった時に一度だけ呼び出したいもの
    void OnStateEnterBeam()
    {
        StartCoroutine("BeamShot");
    }


    //状態変更に使える
    //引数は移動したい状態
    void ChangeState(BossState state)
    {
        //現在の状態が移動したい状態と違ったら
        if (bossState != state)
        {

            //現在の状態の終了
            OnStateExit(bossState);

            //移動したい状態を代入
            bossState = state;

            //次の状態まで呼び出す
            OnStateEnter(state);

        }
    }
    //現在の状態が始まった時に一度だけ呼ばれる
    void OnStateEnter(BossState state)
    {
        //切り替えたい状態を選択する
        switch (state)
        {
            //状態変更
            case BossState.Beam:
                OnStateEnterBeam();
                break;
        }
    }
    //現在の状態を終了するときに一回呼ばれる
    void OnStateExit(BossState state)
    {

    }
    //いつか使うであろうボスの点滅
    //IEnumerator ColorAlpha()
    //{
    //    int count = 30;
    //    while (count > 0)
    //    {
    //        //透明にする
    //        renderer.material.color = Color.red;
    //        //0.05秒待つ
    //        yield return new WaitForSeconds(0.05f);
    //        //元に戻す
    //        renderer.material.color = Color.white;
    //        //0.05秒待つ
    //        yield return new WaitForSeconds(0.05f);
    //        count--;
    //    }
    //}
}
