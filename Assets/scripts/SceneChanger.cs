using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string SceneName;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(SceneName);
        }
    }

    public void ButtonClicked(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void EndGame()
    {
        //Unityで実行中の場合は実行停止
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
		
#else
        //ビルドしたデータで実行中はゲーム停止
		Application.Quit();
#endif
    }
}
