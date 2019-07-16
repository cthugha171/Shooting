using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingTest : MonoBehaviour
{
    GameObject Player;
    Vector3 PlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーオブジェクトを取得
        Player = GameObject.Find("Player");
        //プレイヤーの位置を取得
        PlayerPos = Player.transform.position;
        this.transform.LookAt(PlayerPos);
    }
}
