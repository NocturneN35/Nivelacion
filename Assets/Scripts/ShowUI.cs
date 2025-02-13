using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject; 

    void Start()
    {
        uiObject.SetActive(false); 
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player")) 
        {
            uiObject.SetActive(true); 
            StartCoroutine(WaitForSec()); 
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(300);
        Destroy(uiObject); 
        Destroy(gameObject); 
    }
}
