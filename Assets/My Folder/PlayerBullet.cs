using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;

    void Update()
    {
        this.transform.position += transform.forward * speed;
        Destroy(this.gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Enemy"||
            collision.gameObject.tag == "Boss")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            var EnemyHealth = other.transform.gameObject.GetComponent<BossSceneEnemyHealth>();
            EnemyHealth.EnemyHp -= 1;
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "Boss")
        {
            //1ダメージを与える
            var BossHealth= other.transform.gameObject.GetComponent<TrueBossHealth>();
            BossHealth.BossHp -= 1;
            Destroy(this.gameObject);
        }
    }
}
