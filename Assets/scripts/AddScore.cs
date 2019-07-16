using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//スコアを加算したい場所に
//GameObject.Find("Canvas").GetComponent<AddScore>().AddScores(10);
//を書く、引数がスコア
public class AddScore : MonoBehaviour
{
    int score = 0;
    GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {
        this.scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text =
            "Score:" + score.ToString("D4");
    }

    public void AddScores(int _score)
    {
        this.score += _score;
    }
}
