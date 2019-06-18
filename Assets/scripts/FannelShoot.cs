using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FannelShoot : MonoBehaviour
{
    //入れる
    [SerializeField] private GameObject bullet = null;

    public float Timer = 0;
    private float defalt = 0;
    public float interbal = 1;

    //回転の中心を取るために使う
    private GameObject targetPos;

    // Start is called before the first frame update
    void Start()
    {
        GameObject FirePos = GameObject.Find("Fannel");
        targetPos = FirePos;
    }

    // Update is called once per frame
    void Update()
    {
        //回転し続けるファンネルをの位置を取得
        Vector3 FirePos = new Vector3(this.transform.position.x,
            this.transform.position.y, this.transform.position.z + 1);

        //時間加算
        Timer += Time.deltaTime;
        if (Timer > interbal)
        {
            //時間を0に戻す
            Timer = defalt;
            var GObullet = Instantiate(bullet, FirePos, transform.rotation);
        }

        //スペースで発射
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var GObullet = Instantiate(bullet, FirePos, transform.rotation);
        }
    }
}
