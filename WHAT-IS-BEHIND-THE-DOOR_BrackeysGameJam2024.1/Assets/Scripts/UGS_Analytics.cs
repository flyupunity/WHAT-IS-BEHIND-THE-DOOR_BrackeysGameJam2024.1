using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class UGS_Analytics : MonoBehaviour
{
        async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
            GiveConsent(); //Get user consent according to various legislations
        }
        catch (ConsentCheckException e)
        {
            Debug.Log(e.ToString());
        }
    }

    public void GiveConsent()
    {
        // Call if consent has been given by the user
        AnalyticsService.Instance.StartDataCollection();
        Debug.Log($"Consent has been provided. The SDK is now collecting data!");
    }
    /*public void StartingMemCustomEvent()
    {
        try
        {
            await UnityServices.InitializeAsync();
            MemCustomEvent();
        }
        catch (ConsentCheckException e)
        {
            Debug.Log(e.ToString());
        }
    }
    public void MemCustomEvent()
    {
        //int currentLevel = Random.Range(1, 4);
        /*Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "levelName", SceneManager.GetActiveScene().name}
        };*/

        /*
        AnalyticsService.Instance.CustomData("Mem");//, parameters);
        AnalyticsService.Instance.Flush();
        */
        //Analytics.FlushEvents();
   //}
}
