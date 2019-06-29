using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int shotSpeed=5;
    [SerializeField] private EnemyMove move;
    private GameObject player;
    private GameObject _bullet;
    
    private int dataNum;
    private int makeBullet;//弾の発射間隔用
    



    // Start is called before the first frame update
    void Start()
    {
       
        dataNum = move.dataIndext;
        Debug.Log(dataNum);
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        makeBullet++;

        if (player!=null)
        {
            Debug.Log("Player見つけたぜ");
            Debug.Log(dataNum);

            switch (dataNum)
            {
                case 0:
                    Rash();//突進
                    Debug.Log("猪突猛進");
                    break;
                case 1:
                    Debug.Log("俺弾撃つ");
                    Shootable();//弾撃ってくる
                    break;
                case 2:
                    Debug.Log("カッチカチ");
                    Hard();//硬い
                    break;
                case 3:
                    HiSpeed();//早い
                    Debug.Log("⊂二二二（ ＾ω＾）二⊃ ﾌﾞｰﾝ");
                    break;
                case 4:
                    Debug.Log("まっがーれ");
                    Stalker();//ホーミングを撃つ
                    break;
                case 5:
                    Debug.Log("あああああ");
                    Dropper();//アイテム落とす
                    break;
                case 6:
                    Debug.Log("ズドン");
                    Cannon();//固定砲台
                    break;
                default:
                    Debug.Log("いないものは消しますね");
                    Destroy(gameObject);
                    break;
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        
    }

    private void Rash()
    {
        return;
    }
    
    private void Shootable()
    {
        if (makeBullet % 60 == 0)
        {
            var _bullet = Instantiate(bullet, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
           //_bullet.transform.position=Vector3.MoveTowards(_bullet.transform.position,player.transform.position,)
            Debug.Log("球を発射");
            Destroy(_bullet, 5);
        }
        
    }

    private void HiSpeed()
    {
        return;
    }

    private void Hard()
    {
        if (makeBullet % 60 == 0)
        {
            var _bullet = Instantiate(bullet, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
            Destroy(_bullet, 10);
        }
    }

    private void Stalker()
    {
        if (makeBullet % 60 == 0)
        {
            var _bullet = Instantiate(bullet, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
            Destroy(_bullet, 10);
        }
    }

    private void Dropper()
    {
        return;
    }

    private void Cannon()
    {
        transform.LookAt(player.transform);
        if (makeBullet % 60 == 0)
        {
            _bullet = Instantiate(bullet, transform.position + new Vector3(0, 0, -1), Quaternion.identity);
            Destroy(_bullet, 10);
        }
    }
}