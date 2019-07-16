using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallRain : MonoBehaviour
{
    [SerializeField] private GameObject Rain;
    [SerializeField] private float DelayTimer;
    private float ReSetTimer;

    // Start is called before the first frame update
    void Start()
    {
        ReSetTimer = DelayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        DelayTimer -= Time.deltaTime;
        if (DelayTimer < 0)
        {
            DelayTimer = ReSetTimer;

            var _rain = Instantiate(Rain, this.transform.position, this.transform.rotation);

            int pz = Random.Range(-8, 8);
            _rain.transform.position = new Vector3(0, this.transform.position.y, pz);
        }

        #region ここに回転のを書いたよ
        //if (SceneManager.GetActiveScene().name == "SideView") { }

        //elseif (SceneManager.GetActiveScene().name == "TopView") { }
        #endregion
    }
}
