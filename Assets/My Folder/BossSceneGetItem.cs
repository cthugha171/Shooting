using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class BossData
//{
//    public int HP;
//    public int State;
//}

//public class GameManager
//{
//    public BossData BossCommonData;
//    private void Awake()
//    {
//        BossCommonData = new BossData();
//    }

//    public void ChangeBossState(int state)
//    {
//        BossCommonData.State = state;
//    }
//}

public class BossSceneGetItem : MonoBehaviour
{
    //ファンネル1
    private GameObject fannel1;
    //ファンネル２
    private GameObject fannel2;
    //ファンネルの表示状態変更用
    int state;

    FannelShoot[] shoots;

    FannelShoot fannelShoot;
    int fannelShootstate;

    //private BossData bossData;

    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instace man = GameObject.Find();
        //bossData = man.BossCommonData;

        //GameManager man = GameObject.Find();
        //man.ChangeBossState(2);

        //for( var i=0; i<shoots.Length; ++i)
        //{
        //    shoots[i].Shotstate = 2;
        //}
        //GameObject obj=GameObject.FindObjectOfType<FannelShoot>()

        shoots = GameObject.FindObjectsOfType<FannelShoot>();

        state = 0;

        //受け取り
        fannel1 = transform.GetChild(0).gameObject;
        fannel2 = transform.GetChild(1).gameObject;

        fannel1.SetActive(false);
        fannel2.SetActive(false);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            if (state == 0)
            {
                fannel1.SetActive(true);
                state = 1;
                return;
            }
            if (state == 1)
            {
                fannel2.SetActive(true);
                state = 2;
                return;
            }
            if (state == 2)
            {
                for (var i = 0; i < shoots.Length; ++i)
                {
                    shoots[i].Shotstate = 1;
                }
                state = 3;
                return;
            }
            if (state == 3)
            {
                for (var i = 0; i < shoots.Length; ++i)
                {
                    shoots[i].Shotstate = 2;
                }
                state = 4;
                return;
            }
        }
    }
}
