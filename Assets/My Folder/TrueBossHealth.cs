using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueBossHealth : MonoBehaviour
{
    public int BossHp;
    Renderer renderer;
    string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        SceneName = "GoodEnding";
    }

    // Update is called once per frame
    void Update()
    {
        if (this.BossHp <= 0)
        {
            SceneManager.LoadScene(SceneName);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullets")
        {
            StartCoroutine("Damage");
        }

        if(other.gameObject.tag == "PlayerBom")
        {
            BossHp -= 1;
        }

        if (other.gameObject.tag == "PlayerBeam")
        {
            BossHp -= 5;
            StartCoroutine("Damage");
        }
    }

    IEnumerator Damage()
    {
        renderer.material.color = Color.black;
        yield return new WaitForSeconds(0.05f);
        renderer.material.color = Color.white;
    }
}
