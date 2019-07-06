using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;

    GameObject InGMObject;
    GameManager InGMScript;

    //範囲制限
    public float Clampz;
    public float Clampy;
    private Vector3 playerpos;

    //移動
    float MoveHor;
    float MoveVer;

    //無敵点滅用？
    private Renderer renderer;
    private BoxCollider colTrigger;


    private void Start()
    {
        InGMObject = GameObject.Find("GameManager");
        InGMScript = InGMObject.GetComponent<GameManager>();
        //プレイヤーの位置を取得
        playerpos = this.transform.position;

        //無敵点滅用？
        renderer = GetComponent<Renderer>();
        colTrigger = GetComponent<BoxCollider>();
    }
    void Update()
    {
        Move();
        Clamp();

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Physics.Linecast(transform.position, transform.position + transform.forward * 5.0f))
            {
                Debug.Log("aaaaaaaaa");
            }
        }
    }

    /// <summary>
    /// 画面外に出ないようにする
    /// </summary>
    void Clamp()
    {
        playerpos.y = Mathf.Clamp(playerpos.y, -Clampy, Clampy);
        playerpos.z = Mathf.Clamp(playerpos.z, -Clampz, Clampz);

        transform.position = playerpos;
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    void Move()
    {
        int State = InGMScript.ICsta;
        switch (State)
        {
            case 0://縦画面の時の移動
                //横移動
                MoveHor = Input.GetAxisRaw("Horizontal");
                //縦移動
                MoveVer = Input.GetAxisRaw("Vertical");
                //代入
                playerpos += new Vector3(0, MoveVer, MoveHor) * speed;
                break;
            case 1://横画面の時の移動
                //横移動
                MoveHor = Input.GetAxisRaw("Horizontal");
                //縦移動
                MoveVer = Input.GetAxisRaw("Vertical");
                //代入
                playerpos += new Vector3(0, -MoveHor, MoveVer) * speed;
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //Enemyとぶつかったらコルーチンを実行する
        if (other.gameObject.tag == "Enemy")
        {
            StartCoroutine("Damage");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Enemyとぶつかったらコルーチンを実行する
        if (other.gameObject.tag == "Enemy")
        {
            StartCoroutine("Damage");
        }
    }

    IEnumerator Damage()
    {
        //無敵時間なので当たり判定を無くす
        colTrigger.isTrigger = true;
        //レイヤーをPlayerからPlayerDamageに変更
        this.gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
        //Whileループ
        int count = 10;
        while (count > 0)
        {
            //透明にする
            renderer.material.color = Color.red;
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            renderer.material.color = Color.white;
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            count--;
        }
        //抜けたらレイヤーをPlayerに戻す
        this.gameObject.layer = LayerMask.NameToLayer("Player");
        //処理が終わったら復活
        colTrigger.isTrigger = false;
    }
}
