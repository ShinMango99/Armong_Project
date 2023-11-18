using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public enum InteractionType
{
    Enemy,
    Door
}

public class Interaction : MonoBehaviour
{
    public InteractionType currentType;

    //public string nextSceneName = "Room1";
    public GameObject interactionSprite;
    public GameObject healthText;

    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private EnemyBehaviour enemy;

    [Header("==========Player==========")]
    //public PlayerMovement player;

    [Header("==========Enemy==========")]

    //[Header("==========Door==========")]
    private GameObject currentDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionSprite.SetActive(true);

            switch (currentType)
            {
                case InteractionType.Enemy:
                    enemy.neerPlayer = true;
                    healthText.SetActive(true);
                    break;
                case InteractionType.Door:
                    currentDoor = transform.gameObject;
                    print(transform.gameObject);
                    break;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactionSprite.SetActive(false);

            switch (currentType)
            {
                case InteractionType.Enemy:
                    enemy.neerPlayer = false;
                    healthText.SetActive(false);
                    break;
                case InteractionType.Door:
                    currentDoor = null;
                    print(transform.gameObject);
                    break;
            }
        }
    }

    private void Update()
    {
        InteractionInput();
    }

    public void InteractionInput()
    {
        switch (currentType)
        {
            case InteractionType.Enemy:
                if (!interactionSprite.activeSelf && !enemy.neerPlayer)
                {
                    return;
                }
                else if (!enemy.isFighting && Input.GetKeyDown(KeyCode.E))
                {
                    print("1");
                    //SceneManager.LoadScene(nextSceneName);
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //#.Moving to Same Scene
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //#.Moving to Next Scene You set on Build Setting.
                    enemy.isFighting = true;
                    interactionSprite.SetActive(false);
                    ZoomInOnEnemy();
                }
                else if (enemy.isFighting && Input.GetKeyDown(KeyCode.E))
                {
                    print("2");
                    enemy.isFighting = false;
                    ResetCameraSettings();
                }
                break;
            case InteractionType.Door:
                if (interactionSprite.activeSelf && Input.GetKeyDown(KeyCode.W))
                {
                    player.transform.position = currentDoor.GetComponent<DoorDestination>().GetDestination().position;
                }
                break;
        }
    }

    public void ZoomInOnEnemy()
    {
        virtualCamera.m_Lens.OrthographicSize = 2.5f; // Adjust this value based on your preference
        Vector3 enemyPosition = enemy.transform.position;
        Vector3 playerPosition = player.transform.position;
        Vector3 combatStatusViewPoint = (playerPosition + enemyPosition) / 2;
        virtualCamera.transform.position = new Vector3(combatStatusViewPoint.x, combatStatusViewPoint.y, -10f);
        // Add any other logic you need during the zoom-in state
    }

    public void ResetCameraSettings()
    {
        // Reset the camera settings to their default values
        virtualCamera.m_Lens.OrthographicSize = 5f;
        virtualCamera.transform.position = new Vector3(0, 0, -10f);
    }
}
