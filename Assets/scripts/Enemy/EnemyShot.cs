using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private EnemyMove move;
    [SerializeField] private int shotSpeed=5;
    private GameObject player;
    private GameObject _bullet;
    private Vector3 playerPos;
    
    private int dataNum;
    private int makeBullet;//弾の発射間隔用
    



    // Start is called before the first frame update
    void Start()
    {
       
        dataNum = move.dataIndext;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        makeBullet++;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (player!=null)
        {
            Debug.Log("Player見つけたぜ");
            EnemyState();
        }
    }

    void EnemyState()
    {
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

    private void Rash()
    {
        return;
    }
    
    private void Shootable()
    {
        if (SceneManager.GetActiveScene().name == "SideView")
        {
            if (makeBullet % 60 == 0)
            {
                var _bullet = Instantiate(bullet, this.transform.position, Quaternion.identity);
                Debug.Log("弾の射出位置：" + _bullet.transform.position);
                Debug.Log("球を発射");
                Destroy(_bullet, 5);
            }
        }
        else if (SceneManager.GetActiveScene().name == "TopView")
        {
            if (makeBullet % 60 == 0)
            {
                var _bullet = Instantiate(bullet, this.transform.position, Quaternion.identity);
                Debug.Log("弾の射出位置：" + _bullet.transform.position);
                Debug.Log("球を発射");
                Destroy(_bullet, 5);
            }
        }
        
    }

    private void HiSpeed()
    {
        return;
    }

    private void Hard()
    {
        if (SceneManager.GetActiveScene().name == "SideView")
        {
            if (makeBullet % 60 == 0)
            {
                var _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                Debug.Log("弾の射出位置：" + _bullet.transform.position);
                Destroy(_bullet, 10);
            }
        }
        else if (SceneManager.GetActiveScene().name == "TopView")
        {
            if (makeBullet % 60 == 0)
            {
                var _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                Debug.Log("弾の射出位置：" + _bullet.transform.position);
                Destroy(_bullet, 10);
            }
        }
    }

    private void Stalker()
    {
        if (SceneManager.GetActiveScene().name == "SideView")
        {
            if (makeBullet % 60 == 0)
            {
                var _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                Debug.Log("弾の射出位置：" + _bullet.transform.position);
                Destroy(_bullet, 10);
            }
        }
        else if (SceneManager.GetActiveScene().name == "TopView")
        {
            if (makeBullet % 60 == 0)
            {
                var _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                Debug.Log("弾の射出位置：" + _bullet.transform.position);
                Destroy(_bullet, 10);
            }
        }
    }

    private void Dropper()
    {
        return;
    }

    private void Cannon()
    {
        transform.LookAt(playerPos);
        if (SceneManager.GetActiveScene().name == "SideView")
        {
            if (makeBullet % 60 == 0)
            {
                _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                Debug.Log("弾の射出位置：" + _bullet.transform.position);
                Destroy(_bullet, 10);
            }
        }
        else if (SceneManager.GetActiveScene().name == "TopView")
        {
            if (makeBullet % 30 == 0)
            {
                _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                Debug.Log("弾の射出位置：" + _bullet.transform.position);
                Destroy(_bullet, 10);
            }
        }
    }
}