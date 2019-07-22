using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFannelAction : MonoBehaviour
{
    [SerializeField] private GameObject MovePos;
    [SerializeField] private GameObject Beam;
    GameObject RedLine;
    GameObject player;//オブジェクト格納用
    Vector3 playerPos;//位置格納用
    GameObject obj;
    int FannelState;
    public int FannelHp = 5;

    void Start()
    {
        RedLine = transform.GetChild(0).gameObject;
        RedLine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float step = 2.0f * Time.deltaTime;
        switch (FannelState)
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
                ChangeState(2);
                break;
            case 2:
                break;
            default:
                break;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            FannelHp -= 1;
            Debug.Log(FannelHp);
        }

        if (FannelHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    //状態変更に使える
    //引数は移動したい状態
    void ChangeState(int _state)
    {
        //現在の状態が移動したい状態と違ったら
        if (FannelState != _state)
        {

            //現在の状態の終了
            OnStateExit(FannelState);

            //移動したい状態を代入
            FannelState = _state;

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
            case 1:
                OnStateEnterBeam();
                break;
        }
    }
    //現在の状態を終了するときに一回呼ばれる
    void OnStateExit(int _state)
    {

    }

    void OnStateEnterBeam()
    {
        StartCoroutine("FannelBeam");
    }

    IEnumerator FannelBeam()
    {
        while (FannelHp > 0)
        {
            //向きを修正
            player = GameObject.Find("Player");
            playerPos = player.transform.position;
            this.transform.LookAt(playerPos);
            Debug.Log("弾道予測線表示");
            RedLine.SetActive(true);
            yield return new WaitForSeconds(1.0f);

            RedLine.SetActive(false);
            obj = Instantiate(Beam, this.transform.position, this.transform.rotation);
            obj.transform.parent = transform;//自分の子どもとして登録
            Debug.Log("発射！！！");
            yield return new WaitForSeconds(1.0f);

            Debug.Log("削除");
            Destroy(obj);
            yield return new WaitForSeconds(2.0f);
        }
    }
}
