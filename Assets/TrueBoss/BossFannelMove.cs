using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFannelMove : MonoBehaviour
{
    [SerializeField] private GameObject MovePos;
    [SerializeField] private GameObject Beam;
    GameObject Obj;
    int state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = 2.0f * Time.deltaTime;

        switch (state)
        {
            case 0:
                this.transform.position = Vector3.MoveTowards(
                    this.transform.position,
                    MovePos.transform.position,
                    step);
                if (this.transform.position == MovePos.transform.position)
                {
                    ChangeState(1);
                }
                break;
            case 1:
                OnFireBeam();
                ChangeState(2);
                break;
            case 2:
                OffFireBeam();
                ChangeState(0);
                break;
            default:
                break;
        }
    }

    void OnFireBeam()
    {
        Obj = Instantiate(Beam, this.transform.position, this.transform.rotation);
        Obj.transform.parent = transform;//自分の子どもとして登録
    }

    void OffFireBeam()
    {
        Destroy(Obj);
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
    void OnStateEnter(int _state)
    {
        //切り替えたい状態を選択する
        switch (_state)
        {
            //状態変更
            case 0:
                break;
        }
    }
    //現在の状態を終了するときに一回呼ばれる
    void OnStateExit(int _state)
    {

    }
}
