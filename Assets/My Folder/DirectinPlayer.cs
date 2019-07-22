using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectinPlayer : MonoBehaviour
{
    GameObject player;//オブジェクト格納用
    Vector3 playerPos;//位置格納用
    void Update()
    {
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
        this.transform.LookAt(playerPos);
    }
}
