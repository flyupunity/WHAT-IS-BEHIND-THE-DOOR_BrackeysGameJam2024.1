using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private KeyCode Tab;
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public GameObject loadingPanel;
    void Update()
    {
        if(Input.GetKeyDown(Tab))
        {
            if (pausePanel.activeSelf)
            {
                ReproduseScene();
            }
            else if (!pausePanel.activeSelf) 
            {
                PauseScene();
            }
        }
    }
    public void PauseScene()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().cameraCanMove = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().playerCanMove = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<MyPlayerScript>().UnlockCursor();
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ReproduseScene()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().cameraCanMove = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().playerCanMove = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<MyPlayerScript>().LockCursor();
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
