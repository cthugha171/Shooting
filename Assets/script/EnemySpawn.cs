using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    public List<GameObject> enemyList;
    private int number;
    private float posY;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy[number], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(count%630==0)
        {
            number = Random.Range(0,enemy.Length);
            posY = Random.Range(-5, 5);
            if (number == 1 || number == 6)
            {
                var _Enemy = Instantiate(enemy[number], transform.position, transform.rotation);
                enemyList.Add(_Enemy);
                Debug.Log("敵見つけたからリスト入れとく");
            }
            else
            {
                var _Enemy = Instantiate(enemy[number], transform.position + new Vector3(0, posY, 0), transform.rotation);
                enemyList.Add(_Enemy);
                Debug.Log("敵見つけたからリスト入れとく");
            }
        }

        count++;
    }
}