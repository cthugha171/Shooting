using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    public float BoilarAngle;//ボスの弾の角度
    //中ボスは0を入れて、ボスは1を入れる

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shot");
    }

    public IEnumerator Shot()
    {
        while (true)
        {
            //弾を撃つ処理を書く
            var ebullet = Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.2f);
            Destroy(ebullet, 0.2f);
        }
    }

    void Update()
    {
        this.transform.Rotate(new Vector3(-BoilarAngle, 0, 0));
    }
}
