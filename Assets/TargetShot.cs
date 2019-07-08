using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShot : MonoBehaviour
{
    int state;
    Vector3 PlayerPos;
    //// 緑のキューブが赤い球体を向くような回転を取得し、
    ////それを青いシリンダーに適用するプログラム。
    //public Transform red_sphere;
    //public Transform green_cube;
    //public Transform blue_cylinder;

    //Quaternion init_rot;// 緑のキューブが赤い球体を向くような初期状態での回転。
    //// 単位クォータニオン(x,y,z,w)=(0,0,0,1)になるのは、緑のキューブからみて、z軸性の方向に赤い球体がある場合のみ。
    ////この場合のみ、init_rotを保存しておいて、逆クオータニオンを計算する必要はない
    // Start is called before the first frame update
    void Start()
    {
        //// Quaternion.LookRotation(方向ベクトル)で、その方向ベクトルに向けるための回転を取得する。
        //init_rot = Quaternion.LookRotation(red_sphere.position - green_cube.position);
        //print("初期のクオータニオン" + init_rot);
        //print("初期のオイラー角度[度]" + init_rot.eulerAngles);
    }

    // Update is called once per frame
    void Update()
    {
        //Quaternion q = Quaternion.LookRotation(red_sphere.position - green_cube.position);
        //print("q:" + q);

        //// クオータニオン同士の掛け算は、回転を加えることを意味する。
        ////ここでは、初期クオータニオンのインバース(逆)をかけることによって、
        //// 初期回転状態からの差分の回転を取得している。
        //Quaternion qq = q * Quaternion.Inverse(init_rot);
        //print("qq:" + qq);
        //// 初期状態からどのぐらい回転したかをオイラー角度でprintする。
        //print("qq[オイラー角度]:" + qq.eulerAngles);

        //// 青いシリンダーに回転を適用させる。
        //blue_cylinder.rotation = qq;


        float speed = .0f;
        float step = Time.deltaTime * speed;
        switch (state)
        {
            case 0:
                PlayerPos = GameObject.Find("Player").transform.position;
                state = 1;
                break;
            case 1:
                transform.position = Vector3.MoveTowards(transform.position, PlayerPos, step);
                break;
            default:
                break;
        }
    }
}
