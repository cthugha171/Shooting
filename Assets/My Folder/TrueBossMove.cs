using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueBossMove : MonoBehaviour
{
    //ボスの色変更用
    private Renderer renderer;

    #region 基本のカニ歩き
    //プレイヤー位置取得用
    Vector3 playerpos;
    //移動速度
    public float MoveSpeed = 2.0f;
    //移動で、移動する位置
    Vector3 MovedPos;
    #endregion

    #region 突撃
    //突撃前の位置の保存用
    Vector3 defaultPos;
    //突撃のstate遷移間隔
    public float TotugekiTimer = 2.0f;
    //state遷移タイマー初期化用
    float InitTimer;
    //Switch遷移用変数
    int Totugekistate;
    //突撃速度
    float TotugekiSpeed = 8.0f;
    //突撃が終了したかどうかの判定
    bool EndTotugeki = false;
    #endregion

    #region アメフラシ
    //アメフラシ
    [SerializeField] private GameObject FallRaining;
    //アメフラシ格納用
    GameObject Amefurashi;
    #endregion

    #region ボスのショット攻撃
    //ボスの弾二種類を格納
    [SerializeField] private GameObject BossShot1;
    GameObject SetFire1;
    [SerializeField] private GameObject BossShot2;
    GameObject SetFire2;
    #endregion

    #region ファンネル攻撃
    //ファンネル展開
    [SerializeField] private GameObject BossFannel;
    //ファンネル格納用
    GameObject Fannel;
    #endregion

    float ActionTime = 5.0f;
    float ReSetTimer;
    float NextMove;

    //ボスの状態一覧
    private enum BossAction
    {
        CallZako,        //ザコ呼び出し
        RotateTotugeki,  //回転突撃クリア
        OpenShield,      //シールド展開
        FourPointFire,   //四方向弾幕クリア
        FallRaining,     //雨ごいクリア
        OpenFannel,      //ファンネル展開
        DecideAction,
        EndBeam,         //このビームを撃ったら死ぬ
    }
    private BossAction bossAction;
    void Awake()
    {
        renderer = GetComponent<Renderer>();
        //突撃タイマーの初期化
        InitTimer = TotugekiTimer;
        //アクションタイムの初期化
        ReSetTimer = ActionTime;
        bossAction = BossAction.FourPointFire;
    }

    
    void Update()
    {
        switch (bossAction)
        {
            case BossAction.RotateTotugeki:
                Totugeki();
                if (EndTotugeki)
                {
                    ChangeState(BossAction.DecideAction);
                }
                break;
            case BossAction.FourPointFire:
                ActionTime -= Time.deltaTime;
                if (ActionTime < 0)
                {
                    ChangeState(BossAction.DecideAction);
                }
                break;
            case BossAction.FallRaining:
                ActionTime -= Time.deltaTime;
                if (ActionTime+10 < 0)
                {
                    ChangeState(BossAction.DecideAction);
                }
                break;
            case BossAction.OpenFannel:
                ActionTime -= Time.deltaTime;
                if (ActionTime+10 < 0)
                {
                    ChangeState(BossAction.DecideAction);
                }
                break;
            case BossAction.DecideAction:
                StopAllAction();
                NextMove = Random.Range(0, 9);
                if (NextMove <= 4) ChangeState(BossAction.FourPointFire);
                if (4 < NextMove && NextMove <= 6) ChangeState(BossAction.RotateTotugeki);
                if (NextMove == 7) ChangeState(BossAction.OpenFannel);
                if (NextMove == 8) ChangeState(BossAction.FallRaining);
                break;
            default:
                break;
        }
    }


    /// <summary>
    /// ボスの基本移動
    /// 今回は[x]が横なので[x]に動く
    /// </summary>
    void Move()
    {
        float step = MoveSpeed * Time.deltaTime;
        playerpos = GameObject.Find("Player").transform.position;
        MovedPos = new Vector3(playerpos.x, 0.0f, this.transform.position.z);
        this.transform.position = Vector3.MoveTowards(transform.position, MovedPos, step);
    }

    /// <summary>
    /// ボスの突撃
    /// 今回は色変更ではなく回転でわかりやすく
    /// 長くなったのは申し訳ない
    /// </summary>
    void Totugeki()
    {
        float step = TotugekiSpeed * Time.deltaTime;
        switch (Totugekistate)
        {
            //自身の位置を保存
            case 0:
                TotugekiTimer -= Time.deltaTime;
                if (TotugekiTimer < 0)
                {
                    TotugekiTimer = InitTimer;
                    defaultPos = this.transform.position;
                    Totugekistate = 1;
                }
                break;
            //プレイヤーの位置を取得
            case 1:
                playerpos = GameObject.Find("Player").transform.position;
                Totugekistate = 2;
                break;
            //回転して後退
            case 2:
                this.transform.Rotate(new Vector3(0, 0, 45));
                this.transform.position = Vector3.MoveTowards(
                    transform.position, new Vector3(defaultPos.x, defaultPos.y, defaultPos.z + 2), step);
                if(this.transform.position== new Vector3(defaultPos.x, defaultPos.y, defaultPos.z + 2))
                {
                    Totugekistate = 3;
                }
                break;
            //プレイヤーに突撃
            case 3:
                this.transform.Rotate(new Vector3(0, 0, 45));
                //プレイヤーの位置から[z-2]の位置に向かう
                this.transform.position = Vector3.MoveTowards(
                    transform.position, new Vector3(playerpos.x, playerpos.y, playerpos.z - 5), step);
                if (this.transform.position == new Vector3(playerpos.x, playerpos.y, playerpos.z - 5))
                {
                    //回転を0に戻す
                    this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                    Totugekistate = 4;
                }
                break;
            //戻ってくる
            case 4:
                TotugekiTimer -= Time.deltaTime;
                if (TotugekiTimer < 0)
                {
                    this.transform.position = Vector3.MoveTowards(
                        transform.position, defaultPos, step);
                    //元の位置に戻ったら
                    if (this.transform.position == defaultPos)
                    {
                        TotugekiTimer = InitTimer;
                        Totugekistate = 0;
                        EndTotugeki = true;
                    }
                }
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// アメフラシ
    /// 敵がy180回転しているので、生成する雲も同じく回転させておく
    /// 子どもに入れることで親で一括管理
    /// </summary>
    void StartRain()
    {
        Amefurashi = Instantiate(FallRaining, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.Euler(0.0f, 180.0f, 0.0f));
        Amefurashi.transform.parent = transform;
    }

    /// <summary>
    /// アメフラシ終了
    /// 親子を削除
    /// </summary>
    void StopRain()
    {
        Destroy(Amefurashi);
    }

    /// <summary>
    /// ボスショット ランダムで二種類の弾からどちらかを選んで発射
    /// </summary>
    void StartFier()
    {
        int SelectFire = Random.Range(0, 2);
        if (SelectFire == 0)
        {
            SetFire1 = Instantiate(BossShot1, this.transform.position, this.transform.rotation);
            SetFire1.transform.parent = transform;
        }
        if (SelectFire == 1)
        {
            SetFire2 = Instantiate(BossShot2, this.transform.position, this.transform.rotation);
            SetFire2.transform.parent = transform;
        } 
    }

    /// <summary>
    /// ボスショット終了　親子を削除
    /// </summary>
    void StopFire()
    {
        Destroy(SetFire1);
        Destroy(SetFire2);
    }

    /// <summary>
    /// ファンネル展開
    /// </summary>
    void StartFannel()
    {
        Fannel = Instantiate(BossFannel, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z-1.5f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
        Fannel.transform.parent = transform;
    }

    /// <summary>
    /// ファンネル終了
    /// </summary>
    void StopFannel()
    {
        Destroy(Fannel);
    }

    /// <summary>
    /// 全ての行動を終了
    /// </summary>
    void StopAllAction()
    {
        StopFire();//ショット終了
        StopRain();//アメフラシ終了
        StopFannel();//ファンネル終了
        EndTotugeki = false;//突撃終了解除
        ActionTime = ReSetTimer;//アクションタイマーリセット
    }

    //状態変更に使える
    //引数は移動したい状態
    void ChangeState(BossAction state)
    {
        //現在の状態が移動したい状態と違ったら
        if (bossAction != state)
        {

            //現在の状態の終了
            OnStateExit(bossAction);

            //移動したい状態を代入
            bossAction = state;

            //次の状態まで呼び出す
            OnStateEnter(state);

        }
    }

    //現在の状態が始まった時に一度だけ呼ばれる
    void OnStateEnter(BossAction state)
    {
        //切り替えたい状態を選択する
        switch (state)
        {
            case BossAction.FourPointFire:
                StartFier();
                break;
            case BossAction.FallRaining:
                StartRain();
                break;
            case BossAction.OpenFannel:
                StartFannel();
                break;
        }
    }

    //現在の状態を終了するときに一回呼ばれる
    void OnStateExit(BossAction state)
    {

    }
}
