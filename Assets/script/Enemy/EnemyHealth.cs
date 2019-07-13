using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private EnemyMove move;
    private Status status;
    //[SerializeField] private tukkomi Tukkomi;
   // Tenmetu tenmetu;
   
    
    // Start is called before the first frame update
    void Start()
    {
        status = move.myData;
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
        //if (status.hp <= 0) status.isdead = true;

        Debug.Log("Atk = " + atk + " " + "life = " + status.hp);
        if(status.isDead)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
      
            Debug.Log("当たった");
            Destroy(gameObject);
        SceneManager.LoadScene("SideView");
       
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
