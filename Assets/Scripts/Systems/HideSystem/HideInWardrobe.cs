using UnityEngine;
using System.Collections;

public class HideInWardrobe : MonoBehaviour
{
    private bool isHidden = false;
    private bool playerInside = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = true;
            StartCoroutine(CheckForInput(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
            StopAllCoroutines();
        }
    }

    private IEnumerator CheckForInput(Collider2D player)
    {
        while (playerInside)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleHiding(player);
            }
            yield return null;
        }
    }

    private void ToggleHiding(Collider2D player)
    {
        isHidden = !isHidden;
        player.gameObject.GetComponentInChildren<SpriteRenderer>().enabled = !isHidden;
        player.gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.gameObject.transform.position.y, player.gameObject.transform.position.z);
        player.gameObject.GetComponent<MovementController>().enabled = !isHidden;
        Debug.Log(isHidden ? "Hidden" : "Visible");
    }
}