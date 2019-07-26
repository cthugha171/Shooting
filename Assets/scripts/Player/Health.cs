using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Status status;
    public Slider slider;
    public Image damageImage;
    //public const int  maxHealth = 10;
    //public int currentHealth = maxHealth;

    public void Damage(Status other)
    {
        status.Damage(other.atk);
    }

    public void Damage(int atk)
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            status.hp -= 10;
            Debug.Log("ダメージを受けた");
        }
        status.Damage(atk);
        slider.value = status.hp;
        if (status.isDead)
        {
            Destroy();
            
        }
    }

    public void Destroy()
    {
        Debug.Log("当たった");
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
