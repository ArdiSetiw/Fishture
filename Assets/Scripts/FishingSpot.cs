using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingSpot : MonoBehaviour
{
    private bool Spot;
    [SerializeField] List<FishBase> Fish; 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Spot)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Spot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Spot = false;
        }
    }
}
