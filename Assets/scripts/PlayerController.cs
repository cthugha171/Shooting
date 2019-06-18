using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;

    public camerashake shake;
    void Update()
    {
        //横移動
        float z = Input.GetAxisRaw("Horizontal");
        //縦移動
        float y = Input.GetAxisRaw("Vertical");
        //代入
        this.transform.position += new Vector3(0, y, z) * speed;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            shake.Shake(0.25f, 0.1f);
        }
    }
}
