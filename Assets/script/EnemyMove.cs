using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float speed = 5;
    [SerializeField] EnemySpawndata data;

    public int DataIndext = 0;//ステータスを決める

    Status myData;//ステータスを入れる箱


    // Start is called before the first frame update
    void Start()
    {
        myData = data.statuses[DataIndext];
        gameObject.name = myData.name;
    }

    // Update is called once per frame
    void Update()
    {
        //エネミーのステータスごとに行動を変える
        switch (DataIndext)
        {
            case 0 :
                Rash();//突進
                break;
            case 1:
                Shootable();//弾撃ってくる
                break;
        }
    }

    void Rash()
    {
        transform.localPosition -= new Vector3(0, 0, speed);
    }

    void Shootable()
    {
       
    }
}