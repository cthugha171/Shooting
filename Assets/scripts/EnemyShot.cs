using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    //private int count = 20;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shot");
    }

    public IEnumerator Shot()
    {
        while (true/*count > 0*/)
        {
            //弾を撃つ処理を書く
            var ebullet = Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.3f);
            //count--;
        }
    }
}
