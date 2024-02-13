using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OtherSettings : MonoBehaviour
{

    public AudioMixer audioMixer;


    public TMPro.TMP_Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown qualityDropdown;


    public bool IsFullscreen;

    public int ResolutionIndex;
    public int QualityIndex;

    public float Volume;
    public float Pitch;

    float currentVolume;
    Resolution[] resolutions;

    void Awake()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width
                  && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();

    }
    /*void Update()
    {
        Coin;
        PlayerPosition;
    }*/

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
	IsFullscreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,
                  resolution.height, Screen.fullScreen);
        ResolutionIndex = resolutionIndex;
    }
    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        QualityIndex = qualityIndex;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        Volume = volume;
    }
    public void SetPitch(float pitch)
    {
        audioMixer.SetFloat("pitch", pitch);
        Pitch = pitch;
    }
}
/*


























    public GameObject SaveButtonGameObject;
    public bool LoadSaveOnAwake = true;

    public bool IsAutoSave;

    public Coin Coin;
    public PlayerMovement Player;


	public void SavePlayer()
	{
		SaveSystem.Save(this);
	}

	public void LoadPlayer()
	{
		SettingsData data = SaveSystem.LoadSettings();

		SetAutoSave(data.IsAutoSave);
		SetFullscreen(data.IsFullscreen);

		SetResolution(data.ResolutionIndex);
		SetQuality(data.QualityIndex);

		SetVolume(data.Volume);
		SetPitch(data.Pitch);

		Coin.IntCoin = data.Coin;

		Player.transform.position = new Vector3(data.PlayerPosition[0], data.PlayerPosition[1], data.PlayerPosition[2]);
	}*/