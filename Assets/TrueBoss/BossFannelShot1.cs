using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFannelShot1 : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    public float BoilarAngle;//ボスの弾の角度
    //中ボスは0を入れて、ボスは1を入れる

    int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shot");
    }

    public IEnumerator Shot()
    {
        while (count>0)
        {
            //弾を撃つ処理を書く
            var ebullet = Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.2f);
            Destroy(ebullet, 3f);
            count--;
        }
    }
}
