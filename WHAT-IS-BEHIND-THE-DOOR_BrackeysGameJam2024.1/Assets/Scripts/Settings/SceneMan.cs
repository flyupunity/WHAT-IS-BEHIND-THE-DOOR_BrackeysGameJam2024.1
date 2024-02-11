using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
//using UnityEngine.Audio;

public class SceneMan : MonoBehaviour
{
    public void SceneNum(int Num)
    {
        SceneManager.LoadScene(Num);
    }
    public void SceneName(string Nam)
    {
        SceneManager.LoadScene(Nam);
    }
    public void LevelSceneNam(string Nam)
    {
        SceneManager.LoadScene(Nam);
    }
    public void SceneRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SceneNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Reproduse()
    {
        Time.timeScale = 1f;
    }
    public void QuitFromApp()
    {
        Application.Quit();
    }
    public void OpenURLWhenClick(string url)
    {
        Application.OpenURL(url);
    }
}
