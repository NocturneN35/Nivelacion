using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject uiObject; // Reference to the UI GameObject

    void Start()
    {
        uiObject.SetActive(false); // Initially hide the UI
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player")) // Check if the player has entered the trigger zone
        {
            uiObject.SetActive(true); // Show the UI
            StartCoroutine(WaitForSec()); // Start the coroutine to wait for 5 seconds
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(300);
        Destroy(uiObject); // Destroy the UI object
        Destroy(gameObject); // Optionally destroy this object (the trigger zone)
    }
}
