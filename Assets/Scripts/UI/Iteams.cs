using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Iteams : MonoBehaviour
{
    public GameObject menuSet;

    private GameObject collidedItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Iteams"))
        {
            collidedItem = collision.gameObject;
            menuSet.SetActive(true);
        }
        else
        {
            collidedItem = null;
            menuSet.SetActive(false);
        }
    }

    public void ClickYes()
    {
        Debug.Log("ClickYes method called");

        if (collidedItem != null)
        {
            Debug.Log("Collided item tag: " + collidedItem.tag);

            if (collidedItem.CompareTag("Iteams"))
            {
                Debug.Log("Destroying item with Iteams tag");
                Destroy(collidedItem);
            }
            else
            {
                Debug.Log("Collided item does not have Iteams tag");
            }
        }
        else
        {
            Debug.Log("Collided item is null");
        }

        menuSet.SetActive(false);
    }
}
