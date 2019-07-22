using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FannelRotate : MonoBehaviour
{
    //一秒あたりの回転角度（12秒で一周？）
    public float angle = 180;

    //回転の中心を取るために使う
    private GameObject targetPos;

    //前に構えるときの位置
    public float FrontPosX;

    void Update()
    {
        RotFannel();
    }

    void RotFannel()
    {
        //プレイヤーのトランスフォームを取得
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        targetPos = target;
        transform.RotateAround(targetPos.transform.position, new Vector3(0, 1, 0), angle * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.RotateAround(targetPos.transform.position, new Vector3(0, 0, 0), angle * Time.deltaTime);

            //ファンネルを前につけたときのポジション
            Vector3 FrontPos = new Vector3(targetPos.transform.position.x + FrontPosX, targetPos.transform.position.y, targetPos.transform.position.z + 1);
            transform.position = FrontPos;
        }
    }
}
