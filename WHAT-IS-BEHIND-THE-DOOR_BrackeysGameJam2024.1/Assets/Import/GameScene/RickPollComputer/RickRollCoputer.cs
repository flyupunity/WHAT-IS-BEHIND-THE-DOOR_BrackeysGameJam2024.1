using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RickRollCoputer : MonoBehaviour
{
    [SerializeField] private GameObject screamer;
    [SerializeField] private GameObject rickRoll;
    public void RickRollOn()
    {
        rickRoll.SetActive(true);
        StartCoroutine(ScrimerCorutine());
    }
    public IEnumerator ScrimerCorutine()
    {
        yield return new WaitForSecondsRealtime(5);
        rickRoll.SetActive(false);
        screamer.SetActive(true);
        StartCoroutine(screamer.GetComponent<Screamer>().ScrimerCorutine());
        Destroy(this);
    }
}
