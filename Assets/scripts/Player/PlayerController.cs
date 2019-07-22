using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;

    private Vector3 playerpos;

    //移動
    float MoveHor;
    float MoveVer;

    GameObject PHobject;
    public PlayerHealth PHscript;
    private Renderer renderer;

    private void Start()
    {
        playerpos = this.transform.position;
        PHobject = transform.GetChild(2).gameObject;//PlayerHit検索
        PHscript = PHobject.GetComponent<PlayerHealth>();
        renderer = GetComponent<Renderer>();
    }
    void Update()
    {
        Move();
        Clamp();

        bool isDamage = PHscript.SetIsDamage;

        if (isDamage)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            renderer.material.color = Color.white;
        }
    }

    /// <summary>
    /// 画面外に出ないようにする
    /// </summary>
    void Clamp()
    {
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0.07f, 0.08f, 0));
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(0.92f, 0.92f, 1));

        playerpos.x = Mathf.Clamp(playerpos.x, min.x, max.x);
        playerpos.z = Mathf.Clamp(playerpos.z, min.z, max.z);

        transform.position = playerpos;
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    void Move()
    {
        //横移動
        MoveHor = Input.GetAxisRaw("Horizontal");
        //縦移動
        MoveVer = Input.GetAxisRaw("Vertical");
        //左シフトを押しているときは速度低下
        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveHor /= 2;
            MoveVer /= 2;
        }
        //代入
        playerpos += new Vector3(MoveHor, 0, MoveVer) * speed;
    }
}
