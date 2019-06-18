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
    private Transform plPos;
    private GameObject player;

    public int dataIndext = 0;//ステータスを決める

    Status myData;//ステータスを入れる箱


    // Start is called before the first frame update
    void Start()
    {
        myData = data.statuses[dataIndext];
        gameObject.name = myData.name;
        plPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
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
                Stalker();//ついてくる
                break;
            case 5:
                break;
            case 6:
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

        transform.localPosition = plPos.localPosition - new Vector3(0, 0, leaveplaer);
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
        transform.localPosition -= Vector3.MoveTowards(this.transform.position, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z),speed_Stalker*Time.deltaTime);
    }
}