using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRining : MonoBehaviour
{
    //移動先
    [SerializeField] private GameObject[] MovePos;
    [SerializeField] private float timer = 2;//待ち時間
    [SerializeField] private GameObject Cloud;
    private float ResetTimer;//初期化用
    int state;//状態遷移

    // Start is called before the first frame update
    void Start()
    {
        ResetTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        FallRain();
    }

    void FallRain()
    {
        float step = 5.0f * Time.deltaTime;
        switch (state)
        {
            case 0:
                this.transform.position = Vector3.MoveTowards(
                    this.transform.position,
                    MovePos[0].transform.position,
                    step/2);
                if (transform.position == MovePos[0].transform.position)
                {
                    ChangeState(1);
                }
                break;
            case 1:
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    timer = ResetTimer;
                    ChangeState(2);
                }
                break;
            case 2:
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
                break;
            default:
                break;
        }
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
                obj.transform.parent = transform;
                break;
            default:
                break;
        }
    }
    //現在の状態を終了するときに一回呼ばれる
    void OnStateExit(int state)
    {

    }
}
