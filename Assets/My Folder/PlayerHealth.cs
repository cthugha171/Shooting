using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerHp;
    private string BadEnd;
    public bool SetIsDamage;
    private CapsuleCollider col;

    private float MutekiTime;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHp = 10;
        BadEnd = "BadEnding";
        SetIsDamage = false;
        col = GetComponent<CapsuleCollider>();
        if(SetIsDamage) col.enabled = false;
        if (!SetIsDamage) col.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (SetIsDamage)
        {
            col.enabled = false;
            MutekiTime += Time.deltaTime;
            if (MutekiTime > 1.5f)
            {
                MutekiTime = 0;
                SetIsDamage = false;
            }
        }
        else if (!SetIsDamage) col.enabled = true;
        if (PlayerHp <= 0)
        {
            SceneManager.LoadScene(BadEnd);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy"||
            other.gameObject.tag=="EnemyBullet"||
            other.gameObject.tag=="Boss")
        {
            PlayerHp -= 1;
            SetIsDamage = true;
        }
    }
}
