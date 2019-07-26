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
        if (state.isDead)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("TopView");
    }
}
