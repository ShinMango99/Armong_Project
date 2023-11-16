using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextSceneName = "Room1";
    public GameObject interactionText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionText.SetActive(true);
        }
        else
        {
            interactionText.SetActive(false);
        }
    }

    private void Update()
    {
        if (interactionText.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
