using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private bool canTeleportToStart = false;
    private bool canTeleportToEnd = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (canTeleportToEnd)
            {
                TeleportPlayer(GameObject.Find("TeleportStart").transform.position);
            }
            else if (canTeleportToStart)
            {
                TeleportPlayer(GameObject.Find("TeleportEnd").transform.position);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Check if the player is on top of "TeleportEnd" and then teleport to "TeleportStart"
            if (Vector2.Distance(transform.position, GameObject.Find("TeleportEnd").transform.position) < 0.5f)
            {
                TeleportPlayer(GameObject.Find("TeleportStart").transform.position);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TeleportStart"))
        {
            canTeleportToStart = true;
        }
        else if (other.CompareTag("TeleportEnd"))
        {
            canTeleportToEnd = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TeleportStart"))
        {
            canTeleportToStart = false;
        }
        else if (other.CompareTag("TeleportEnd"))
        {
            canTeleportToEnd = false;
        }
    }

    void TeleportPlayer(Vector2 destination)
    {
        transform.position = destination;
    }
}