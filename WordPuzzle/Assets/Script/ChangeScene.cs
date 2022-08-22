using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SceneChange_RESTART()
    {
        if (GameManager.Instance.scene.name == "EAZY_SCENE")
            SceneManager.LoadScene("EAZY_SCENE");
        if (GameManager.Instance.scene.name == "NORMAL_SCENE")
            SceneManager.LoadScene("NORMAL_SCENE");
        if (GameManager.Instance.scene.name == "HARD_SCENE")
            SceneManager.LoadScene("HARD_SCENE");
    }

    public void SceneChange_SCENE_EAZY()
    {
        Debug.Log("eazyscene");
        SceneManager.LoadScene("EAZY_SCENE");
    }

    public void SceneChange_SCENE_LOBBY()
    {
        Debug.Log("lobbyscene");
        SceneManager.LoadScene("LOBBY_SCENE");
    }

    public void SceneChange_SCENE_NORMAL()
    {
        Debug.Log("NormalScene");
        SceneManager.LoadScene("NORMAL_SCENE");
    }

    public void SceneChange_SCENE_HARD()
    {
        Debug.Log("HardScene");
        SceneManager.LoadScene("HARD_SCENE");
    }
}
