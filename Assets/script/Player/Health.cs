using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private Status status;
    
    //public const int  maxHealth = 10;
    //public int currentHealth = maxHealth;

    public void Damage(Status other)
    {
        status.Damage(other.atk);
    }

    public void Damage(int atk)
    {
        
        status.Damage(atk);
        if(status.isDead)
        {
            Destroy();
            
        }
    }

    public void Destroy()
    {
        Debug.Log("当たった");
        Destroy(gameObject);
        SceneManager.LoadScene("BadEnding");
    }

    //public void TakeDamage(int amount)
    //{
    //    currentHealth -= amount;

    //    if (currentHealth <= 0)
    //    {
    //        currentHealth = 0;
    //        Debug.Log("死亡");
    //    }
    //}


}
