using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float speed_Rash = 5;
    [SerializeField] float speed_Hard = 1;
    [SerializeField] float speed_Hispeed = 10;
    [SerializeField] float speed_Stalker = 2;
    [SerializeField] EnemySpawndata data;
    [SerializeField] float leaveplaer = 50;
    int count = 10;
    private Transform plPos;
    private GameObject player;
    private Vector3 mov;
    private Vector3 enemyposint;

    public int dataIndext = 0;//ステータスを決める

    Status myData;//ステータスを入れる箱


    // Start is called before the first frame update
    void Start()
    {
        myData = data.statuses[dataIndext];
        gameObject.name = myData.name;
        plPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.Find("Player");
        mov = new Vector3(0, 1, -1);
        if (dataIndext == 5)
        {
            enemyposint = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
            enemyposint.z = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        //エネミーのステータスごとに行動を変える
        switch (dataIndext)
        {
            case 0 :
                Rash();//突進
                break;
            case 1:
                Shootable();//弾撃ってくる
                break;
            case 2:
                Hard();//硬い
                break;
            case 3:
                HiSpeed();//早い
                break;
            case 4:
                Stalker();//ホーミングを撃つ
                break;
            case 5:
                Dropper();//アイテム落とす
                break;
            case 6:
                Cannon();//固定砲台
                break;
        }
    }

    void Rash()
    {
        transform.localPosition -= new Vector3(0, 0, speed_Rash*Time.deltaTime);
    }

    void Shootable()
    {
        plPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        transform.localPosition = plPos.localPosition + new Vector3(0, 0, leaveplaer);
    }

    void Hard()
    {
        transform.localPosition -= new Vector3(0, 0, speed_Hard*Time.deltaTime);
    }

    void HiSpeed()
    {
        transform.localPosition -= new Vector3(0, 0, speed_Hispeed*Time.deltaTime);
    }

    void Stalker()
    {
        
    }

    void Dropper()
    {
        if (count <= 0)
        {
            mov.y = Random.Range(-8, 10);
            mov.z = Random.Range(-2, 0);
            count = 10;
        }
        count--;
        transform.localPosition += new Vector3(mov.x, mov.y, mov.z) * Time.deltaTime;
    }

    void Cannon()
    {
        plPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.localPosition= plPos.localPosition + new Vector3(0, 0, leaveplaer);
    }
}