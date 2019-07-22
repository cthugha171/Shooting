using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueBossShot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;//ボスの弾を入れる
    public float BoilarAngle;//弾を打ち出す角度
    public float BulletDelay = 0.2f;//弾を打ち出す間隔
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shot");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0, -BoilarAngle, 0));
    }

    IEnumerator Shot()
    {
        while (true)
        {
            var _bullet = Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(BulletDelay);
        }
    }
}
