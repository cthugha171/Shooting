using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject Boss;
    [SerializeField] private GameObject Item;
    private int number;
    private float posY;
    private int count;
    private int ItemCount;
    GameObject _Enemy;
    GameObject _Boss;
    GameObject _Item;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy[number], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        Spawn();
        ItemSpawn();
    }

    void Spawn()
    {
        if (count % 500 == 0 && !GameObject.FindGameObjectWithTag("Boss"))
        {
            number = Random.Range(0, enemy.Length);

            posY = Random.Range(-5, 5);
            if (number == 1 || number == 6)
            {
                _Enemy = Instantiate(enemy[number], transform.position, transform.rotation);

                Destroy(_Enemy, 50.0f);
            }
            else
            {
                _Enemy = Instantiate(enemy[number], transform.position + new Vector3(0, posY, 0), transform.rotation);

                Destroy(_Enemy, 50.0f);
            }
        }
        if (count >= 1000 && !GameObject.FindGameObjectWithTag("Boss"))
        {
            _Boss = Instantiate(Boss, transform.position, transform.rotation);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    void ItemSpawn()
    {
        if (count % 600 == 0 && ItemCount <= 4)
        {
            posY = Random.Range(-5, 5);
            _Item = Instantiate(Item, transform.position + new Vector3(0, posY, 0), transform.rotation);
        }
    }
}