using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/*[System.Serializable]
public class SettingsInfo
{
    public float volume;
    public float mouseSensitivity;

    public int audioToggle;
    public int postProcessingToggle;
}*/
[System.Serializable]
public class PlayerInfo
{
    public int coin;
    public bool[] maxLevelIndex = new bool[10];
    public string language;//ru|en
}  
public class Progress : MonoBehaviour
{
    //Progress.Instance.Save()
    //public SettingsInfo SettingsInfo;

    //Progress.Instance.SettingsInfo.audioToggle
    //Progress.Instance.SettingsInfo.postProcessingToggle

    public bool adShowing = false;
    public bool gameInPause = false;
    public bool playerAuthorized = false;

    /*[DllImport("__Internal")]
    private static extern void CheckAuthorization();*/

    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    public PlayerInfo PlayerInfo;
    public static Progress Instance;
    void Awake()
    {
        if(Instance == null){    
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            //LoadExtern();
            LoadDataFromPlayerPrefs();
        }else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (PlayerInfo.maxLevelIndex[0] == false){
            PlayerInfo.maxLevelIndex[0] = true;
            Debug.LogWarning("maxLevelIndex[0] == false");
        }
    }
    private void Update() {
        //CheckAuthorization();
    }
    /*public void AuthorizationStatus(bool value){
        playerAuthorized = value;
    }*/
    public void Save_PlayerPrefs(){
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        PlayerPrefs.SetString("progressData", jsonString);
    }
    public void LoadDataFromPlayerPrefs(){
        if(PlayerPrefs.GetString("progressData") != ""){
            string value = PlayerPrefs.GetString("progressData");
            PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        }
    }
    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
    }
}
