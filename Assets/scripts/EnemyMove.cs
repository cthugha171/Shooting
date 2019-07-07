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
    private Transform plPos;
    private Vector3 mov;
    private Vector3 enemyposint;
    private int count = 10;
    private float x_abs;
    private float y_abs;
    private float z_abs;
    public float clampY;

    private Coroutine coroutine;

    public int dataIndext = 1;//ステータスを決める

    Status myData;//ステータスを入れる箱


    // Start is called before the first frame update
    void Start()
    {
        myData = data.statuses[dataIndext];
        gameObject.name = myData.name;
        enemyposint = this.transform.position;
        
        mov = new Vector3(0, 1, -1);
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

        Debug.Log("MoveCroutine");
        while (x_abs > 3 || y_abs > 3 || z_abs > 3)
        {
            Debug.Log("ENemy Move Start " + speed);
            //yield return new WaitForEndOfFrame();
            yield return null;
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, player.transform.position, speed);
            Debug.Log("EnemyMove");
        }
        Debug.Log("完了");
    }

    void Rash()
    {
        transform.localPosition -= new Vector3(0, 0, speed_Rash*Time.deltaTime);
    }

    void Shootable()
    {
        this.transform.LookAt(player.transform);
        if(this.transform.position.x>=player.transform.position.x)
        {
            transform.localPosition -= new Vector3(0, 0, speed_Hard * Time.deltaTime);
        }
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
        x_abs = Mathf.Abs(this.gameObject.transform.localPosition.x - player.transform.localPosition.x);
        y_abs = Mathf.Abs(this.gameObject.transform.localPosition.x - player.transform.localPosition.y);
        z_abs = Mathf.Abs(this.gameObject.transform.localPosition.z - player.transform.localPosition.z);


        if (coroutine==null)
        {
            coroutine = StartCoroutine(MoveCoroutine());
        }
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
        transform.localPosition += new Vector3(mov.x, Mathf.Clamp(mov.y, -clampY, clampY), mov.z) * Time.deltaTime;
    }

    void Cannon()
    {
        transform.LookAt(player.transform);
        transform.localPosition -= new Vector3(0, 0, speed_Hard*Time.deltaTime);
    }
}