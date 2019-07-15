using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    private void Start()
    {
        InGMObject = GameObject.Find("GameManager");
        InGMScript = InGMObject.GetComponent<GameManager>();
        //プレイヤーの位置を取得
        playerpos = this.transform.position;
       
    }
    void Update()
    {
        Move();
        Clamp();
    }

    /// <summary>
    /// 画面外に出ないようにする
    /// </summary>
    void Clamp()
    {
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 1));

        playerpos.y = Mathf.Clamp(playerpos.y, min.y, max.y);
        playerpos.z = Mathf.Clamp(playerpos.z, min.z, max.z);

        transform.position = playerpos;
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    void Move()
    {
        //    if (SceneManager.GetActiveScene().name == "SideView")
        //    {
        //横移動
        MoveHor = Input.GetAxisRaw("Horizontal");
            //縦移動
            MoveVer = Input.GetAxisRaw("Vertical");
            //代入
            playerpos += new Vector3(0, MoveVer, MoveHor) * speed;
        //}
        //else if (SceneManager.GetActiveScene().name == "TopView")
        //{
        //    //横移動
        //    MoveHor = Input.GetAxisRaw("Horizontal");
        //    //縦移動
        //    MoveVer = Input.GetAxisRaw("Vertical");
        //    //代入
        //    playerpos += new Vector3(0, -MoveHor, MoveVer) * speed;
        //}
    }
}
