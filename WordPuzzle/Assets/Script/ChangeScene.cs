using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
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
