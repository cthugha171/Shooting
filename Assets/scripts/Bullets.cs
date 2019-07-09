using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
 

public class Bullets : MonoBehaviour
{
    [SerializeField] private Status status;
    [SerializeField] private UnityEvent onTrigger = null; 
    public GameObject player;
    public Helth helth;
    // Start is called before the first frame update

    public Status MyStatus
    {
        get { return status; }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        helth = player.GetComponent<Helth>();
        
   }
    public void Damage(Status other)
    {
        status.Damage(other.atk);
    }
    public void Damage(int atk)
    {
        status.Damage(atk);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {

            Debug.Log("当たった AA");
            var enemy = col.GetComponent<EnemyHealth>();
            enemy.Damage(MyStatus.atk);
        }
        if (col.gameObject.tag == "Benemy")
        {

            Debug.Log("当たった AA");
            var enemy = col.GetComponent<EnemyHealth>();
            enemy.Damage(MyStatus.atk);
        }
        //if(col.gameObject.tag == "Player")
        //{
        //    var player = col.GetComponent<Helth>();
        //    player.Damage(MyStatus.atk);
        //}
        Destroy(gameObject);
       // onTrigger.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (col.gameObject.tag == "Enemy")
        //{

        //    Debug.Log("当たった AA");
        //    var enemy = col.GetComponent<EnemyHealth>();
        //    enemy.Damage(MyStatus.atk);
        //}
        if (collision.gameObject.tag == "Player")
        {
            //var player = collision.GetComponent<Helth>();
            helth.Damage(MyStatus.atk);
        }
        if(collision.gameObject.tag =="Ebullet")
        {
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
