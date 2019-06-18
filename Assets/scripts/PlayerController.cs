using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;

    public float Clampz;
    public float Clampy;

    private Vector3 playerpos;
    void Update()
    {
        //横移動
        float z = Input.GetAxisRaw("Horizontal");
        //縦移動
        float y = Input.GetAxisRaw("Vertical");
        //代入
        this.transform.position += new Vector3(0, y, z) * speed;

        Clamp();
    }

    void Clamp()
    {
        //プレイヤーの位置を取得
        playerpos = transform.position;

        playerpos.y = Mathf.Clamp(playerpos.y, -Clampy, Clampy);
        playerpos.z = Mathf.Clamp(playerpos.z, -Clampz, Clampz);

        transform.position = playerpos;
    }
}
