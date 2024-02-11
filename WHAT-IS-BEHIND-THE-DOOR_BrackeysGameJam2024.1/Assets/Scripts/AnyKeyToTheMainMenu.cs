using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyKeyToTheMainMenu : MonoBehaviour
{
    void Update()
    {
        if (!Input.GetMouseButton(1) && !Input.GetMouseButton(0) && Input.anyKey)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
