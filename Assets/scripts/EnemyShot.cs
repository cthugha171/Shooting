using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

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
        }
    }
}
