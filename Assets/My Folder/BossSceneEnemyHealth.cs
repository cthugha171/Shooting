using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSceneEnemyHealth : MonoBehaviour
{
    public int EnemyHp;
    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHp = 10;
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.EnemyHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullets" ||
            other.gameObject.tag == "PlayerBom")
        {
            StartCoroutine("Damage");
        }

        if (other.gameObject.tag == "PlayerBeam")
        {
            EnemyHp -= 5;
            StartCoroutine("Damage");
        }
    }

    IEnumerator Damage()
    {
        renderer.material.color = Color.black;
        yield return new WaitForSeconds(0.05f);
        renderer.material.color = Color.white;
    }
}
