using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Totugeki : MonoBehaviour
{
    [SerializeField] private Status status;
    [SerializeField] private UnityEvent onTrigger = null;
    public GameObject player;
    public Health helth;
    public int count;
    
    // Start is called before the first frame update

    public Status MyStatus
    {
        get { return status; }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        helth = player.GetComponent<Health>();

    }
   

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == "Enemy")
    //    {

    //        Debug.Log("当たった AA");
    //        var enemy = col.GetComponent<EnemyHealth>();
    //        enemy.Damage(MyStatus.atk);
    //    }
    //    //if(col.gameObject.tag == "Player")
    //    //{
    //    //    var player = col.GetComponent<Helth>();
    //    //    player.Damage(MyStatus.atk);
    //    //}
    //    Destroy(gameObject);
    //    // onTrigger.Invoke();
    //}

    private void OnCollisionEnter(Collision collision)
    {
       

        if (collision.gameObject.tag == "Player")
        {
            helth.Damage(MyStatus.atk);
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (count >= 60)
            {
                //var player = collision.GetComponent<Helth>();
                Debug.Log("あ立ってる");

                helth.Damage(MyStatus.Tatk);
                count = 0;
            }
            count++;
        }

    }
}
