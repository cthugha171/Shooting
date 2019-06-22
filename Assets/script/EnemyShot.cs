using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    private ParticleSystem bullet;
    private Status myData;//ステータスを入れる箱
    private string Ename;


    // Start is called before the first frame update
    void Start()
    {
        bullet=GetComponent<ParticleSystem>();
        myData = GetComponent<Status>();
        Ename = myData.name;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            Debug.Log("Player見つけたぜ");
            switch (Ename)
            {
                case "突っ込む":
                    Rash();//突進
                    break;
                case "弾":
                    Shootable();//弾撃ってくる
                    break;
                case "硬い":
                    Hard();//硬い
                    break;
                case "高速":
                    HiSpeed();//早い
                    break;
                case "追尾":
                    Stalker();//ホーミングを撃つ
                    break;
                case "アイテム":
                    Dropper();//アイテム落とす
                    break;
                case "固定砲台":
                    Cannon();//固定砲台
                    break;
            }
        }
    }

    private void Rash()
    {
        throw new NotImplementedException();
    }
    
    private void Shootable()
    {
        bullet.Play();
    }

    private void HiSpeed()
    {
        throw new NotImplementedException();
    }

    private void Hard()
    {
        throw new NotImplementedException();
    }

    private void Stalker()
    {
        throw new NotImplementedException();
    }

    private void Dropper()
    {
        throw new NotImplementedException();
    }

    private void Cannon()
    {
        throw new NotImplementedException();
    }
}


