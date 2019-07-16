using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainAttack : MonoBehaviour
{
    //移動先
    [SerializeField] private GameObject[] MovePos;
    [SerializeField] private float timer = 2;//待ち時間
    [SerializeField] private GameObject Cloud;
    private float ResetTimer;

    int state;

    private void Start()
    {
        ResetTimer = timer;
    }

    private void Update()
    {
        FallRain();
    }

    void FallRain()
    {
        float step = 5.0f * Time.deltaTime;
        switch (state)
        {
            case 0:
                Debug.Log("真ん中に移動！");
                this.transform.position = Vector3.MoveTowards(
                    this.transform.position,
                    MovePos[0].transform.position,
                    step);
                if (transform.position == MovePos[0].transform.position)
                {
                    ChangeState(1);
                }
                break;
            case 1:
                Debug.Log("待ち時間....");
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    timer = ResetTimer;
                    ChangeState(2);
                }
                break;
            case 2:
                Debug.Log("上に移動！");
                this.transform.position = Vector3.MoveTowards(
                    this.transform.position,
                    MovePos[1].transform.position,
                    step);
                if (transform.position == MovePos[1].transform.position)
                {
                    ChangeState(3);
                }
                break;
            case 3:
                Debug.Log("雨発生");
                break;

            default:
                break;
        }

        #region ここに回転のを書いたよ
        //if (SceneManager.GetActiveScene().name == "SideView") { }

        //elseif (SceneManager.GetActiveScene().name == "TopView") { }
        #endregion
    }

    //状態変更に使える
    //引数は移動したい状態
    void ChangeState(int _state)
    {
        //現在の状態が移動したい状態と違ったら
        if (state != _state)
        {

            //現在の状態の終了
            OnStateExit(state);

            //移動したい状態を代入
            state = _state;

            //次の状態まで呼び出す
            OnStateEnter(_state);

        }
    }
    //現在の状態が始まった時に一度だけ呼ばれる
    void OnStateEnter(int state)
    {
        switch (state)
        {
            case 3:
                var obj = Instantiate(Cloud, this.transform.position, this.transform.rotation);
                break;
            default:
                break;
        }
    }
    //現在の状態を終了するときに一回呼ばれる
    void OnStateExit(int state)
    {

    }

    //IEnumerator RainFallAttack()
    //{
    //    while (IsMoveEnd == false)
    //    {
    //        this.transform.position = Vector3.MoveTowards(this.transform.position, MovePos[0], 2.0f);
    //        if (this.transform.position == MovePos[0])
    //        {
    //            IsMoveEnd = true;
    //        }
    //        yield return null;
    //    }

    //    //二秒待つ
    //    yield return new WaitForSeconds(2.0f);
    //    IsMoveEnd = false;

    //    while (IsMoveEnd == false)
    //    {
    //        this.transform.position = Vector3.MoveTowards(this.transform.position, MovePos[1], 2.0f);
    //        if (this.transform.position == MovePos[1])
    //        {
    //            IsMoveEnd = true;
    //        }
    //        yield return null;
    //    }
    //    test = true;

    //}
}
        #region 自身の子どもを取得する方法
        //transform.childCountは、子供の総数がintで入る
        //for (var i = 0; i < transform.childCount; ++i)
        //{
        //    //子どもを取得
        //    transform.GetChild(i);
        //    //子どもの頭文字を確認して該当するか確認
        //    if (transform.GetChild(i).gameObject.name.StartsWith("MovePos"))
        //    {
        //        //該当した子供をリストに入れる
        //        TargetPos.Add(transform.GetChild(i));
        //        Debug.Log(transform.GetChild(i).gameObject.name);
        //    }
        //    TargetPos[0] = transform.GetChild(i);
        ////子どもの位置を格納するためのリスト
        ////private List<Transform> TargetPos = new List<Transform>();
        //}
        #endregion
