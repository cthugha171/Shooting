using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FannelShoot : MonoBehaviour
{
    //入れる
    [SerializeField] private GameObject Homing = null;
    [SerializeField] private GameObject Beam;
    [SerializeField] private GameObject Normal;

    public float Timer = 0;
    private float defalt = 0;
    public float interbal = 1;

    public int Shotstate;

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
        Shot();
    }

    /// <summary>
    /// 弾を撃つ
    /// </summary>
    void Shot()
    {
        //回転し続けるファンネルをの位置を取得
        Vector3 FirePos = new Vector3(this.transform.position.x,
            this.transform.position.y, this.transform.position.z);

        //ここコルーチン使おう！
        //時間加算
        Timer += Time.deltaTime;
        if (Timer > interbal)
        {
            switch (Shotstate)
            {
                case 0:
                    //時間を0に戻す
                    Timer = defalt;
                    for (int i = 0; i < 5; i++)
                    {
                        var Hbullet = Instantiate(Homing, FirePos, transform.rotation);
                    }
                    break;
                case 1:
                    //時間を0に戻す
                    Timer = defalt;
                    var Bbullet = Instantiate(Beam, FirePos, new Quaternion());
                    Destroy(Bbullet, 0.5f);
                    break;
                case 2:
                    //時間を0に戻す
                    Timer = defalt;
                    var Nbullet = Instantiate(Normal, FirePos, new Quaternion());
                    Destroy(Nbullet, 3.0f);
                    break;
                default:
                    break;
            }
        }
    }
}
