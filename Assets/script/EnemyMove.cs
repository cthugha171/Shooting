using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed_Rash = 5;
    [SerializeField] private float speed_Hard = 1;
    [SerializeField] private float speed_Hispeed = 10;
    [SerializeField] private float speed_Stalker = 2;
    [SerializeField] private float leaveplayer = 50;
    [SerializeField] private EnemySpawndata data;
    [SerializeField] private GameObject player;
    int count = 10;
    private Transform plPos;
    private Vector3 mov;
    private Vector3 enemyposint;
    private float x_abs;
    private float y_abs;
    private float z_abs;

    private Coroutine coroutine;

    public int dataIndext = 0;//ステータスを決める

    Status myData;//ステータスを入れる箱


    // Start is called before the first frame update
    void Start()
    {
        myData = data.statuses[dataIndext];
        gameObject.name = myData.name;
        plPos = player.GetComponent<Transform>();
        
        mov = new Vector3(0, 1, -1);
    }

    // Update is called once per frame
    void Update()
    {
        x_abs = Mathf.Abs(this.gameObject.transform.localPosition.x - player.transform.localPosition.x);
        y_abs = Mathf.Abs(this.gameObject.transform.localPosition.x - player.transform.localPosition.y);
        z_abs = Mathf.Abs(this.gameObject.transform.localPosition.z - player.transform.localPosition.z);

        if(coroutine==null)
        {
            coroutine = StartCoroutine(MoveCoroutine());
        }
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

    IEnumerator MoveCoroutine()
    {
        float speed = speed_Stalker * Time.deltaTime;

        while(x_abs>3||y_abs>3||z_abs>3)
        {
            yield return new WaitForEndOfFrame();
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, player.transform.position, speed);
        }
    }

    void Rash()
    {
        transform.localPosition -= new Vector3(0, 0, speed_Rash*Time.deltaTime);
    }

    void Shootable()
    {
        plPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        transform.localPosition = plPos.localPosition + new Vector3(0, 0, leaveplayer);
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
        transform.localPosition -= plPos.localPosition + new Vector3(0, 0, leaveplayer);
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
        transform.localPosition= plPos.localPosition + new Vector3(0, 0, leaveplayer);
    }
}