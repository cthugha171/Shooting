using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private EnemyMove move;
    [SerializeField] private GameObject Item;
    private Status status;
    private int stateNum;//enemyの種類判別用
                         //[SerializeField] private tukkomi Tukkomi;
                         // Tenmetu tenmetu;
    public AudioClip se;


    // Start is called before the first frame update
    void Start()
    {
        status = move.myData;
        stateNum = move.dataIndext;
    }

    public void Damage(Status other)
    {
        //status.Damage(other.atk);
        Damage(other.atk);
    }

    public void Damage(int atk)
    {
        status = status.Damage(atk);

        //int damage = atk -status.def;
        //status.hp -= damage;
        //if (status.hp <= 0) status.isDead = true;

        
        if (status.isDead)
        {
            Debug.Log("死んだ");
            AudioSource.PlayClipAtPoint(se, transform.position);
            if (stateNum == 5)
            {
                Debug.Log("アイテムを落とした");
                Instantiate(Item);
            }
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    } 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
         if(status.hp<=2)
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="DeathPoint")
        {
            Destroy(this.gameObject);
        }
    }


}
