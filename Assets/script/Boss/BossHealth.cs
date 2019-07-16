using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private Status state;
    public void Damage(Status other)
    {
        state.Damage(other.atk);
    }

    public void Damage(int atk)
    {
        state.Damage(atk);
        Debug.Log("ボスの残り体力:" + state.hp);
        if (state.isDead)
        {
            Destroy();

        }
    }

    public void Destroy()
    {
        Debug.Log("当たった");
        Destroy(gameObject);
        SceneManager.LoadScene("GoodEnding");
    }
}
