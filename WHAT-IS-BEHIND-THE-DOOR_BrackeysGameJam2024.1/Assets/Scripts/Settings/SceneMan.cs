using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
//using UnityEngine.Audio;

public class SceneMan : MonoBehaviour
{
    public void SceneNum(int Num)
    {
        Instantiate(SetValuesForVariables.Instance.LoadingScreenPrefab);
        SceneManager.LoadScene(Num);
    }
    public void SceneName(string Nam)
    {
        Instantiate(SetValuesForVariables.Instance.LoadingScreenPrefab);
        SceneManager.LoadScene(Nam);
    }
    public void LevelSceneNam(string Nam)
    {
        Instantiate(SetValuesForVariables.Instance.LoadingScreenPrefab);
        SceneManager.LoadScene(Nam);
    }
    public void SceneRestart()
    {
        Instantiate(SetValuesForVariables.Instance.LoadingScreenPrefab);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SceneNext()
    {
        Instantiate(SetValuesForVariables.Instance.LoadingScreenPrefab);
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
