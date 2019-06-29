using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//弾のホーミング
public class HomingLaser : MonoBehaviour
{
    Rigidbody rigid;
    Vector3 velocity;//弾の速度
    Vector3 position;//発射する初期位置
    public Vector3 acceleration;//加速度
    //public Transform target;//ターゲットをセット
    float period = 2.0f;//敵に当たるまでの時間

    GameObject enemy;
    Vector3 EnemyPos;

    void Start()
    {
        //初期位置をpositionに格納
        position = this.transform.position;
        rigid = GetComponent<Rigidbody>();

        enemy = GameObject.FindGameObjectWithTag("Enemy");
        EnemyPos = enemy.transform.position;

        //初速度をランダムで加える
        velocity = new Vector3(0, Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
    }

    void Update()
    {
        Homing();
    }

    void FixedUpdate()
    {
        // 移動処理
        rigid.MovePosition(transform.position + velocity * Time.deltaTime);
        Destroy(this.gameObject, 2.5f);
    }

    /// <summary>
    /// 移動の計算
    /// </summary>
    void Homing()
    {
        //加速度の初期化
        acceleration = Vector3.zero;

        //ターゲットとの距離を計算
        var diff = EnemyPos - this.transform.position;

        //加速度の計算
        acceleration += (diff - velocity * period) * 2f
                        / (period * period);

        //加速度の上限を設定してそれ以上にしないように
        if (acceleration.magnitude > 100.0f)
        {
            acceleration = acceleration.normalized * 100.0f;
        }

        //着弾時間から減らしていく
        period -= Time.deltaTime;

        //速度の計算
        velocity += acceleration * Time.deltaTime;
    }

    /// <summary>
    /// 当たった処理
    /// </summary>
    void OnCollisionEnter()
    {
        // 何かに当たったら自分自身を削除
        Destroy(this.gameObject);

    }
}
