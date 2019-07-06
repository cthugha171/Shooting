using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    private int number;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        number = Random.Range(0, enemy.Length);
        Instantiate(enemy[number], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(count%630==0)
        {
            number = Random.Range(0, enemy.Length);
            Instantiate(enemy[number], transform.position, transform.rotation);
        }

        count++;
    }
}