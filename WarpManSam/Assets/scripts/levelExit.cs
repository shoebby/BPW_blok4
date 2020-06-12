using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class levelExit : MonoBehaviour
{
    private GameObject[] braziers;

    public int activatedBraziers;
    public int allBraziers;

    private void Start()
    {
        braziers = GameObject.FindGameObjectsWithTag("Brazier");

        allBraziers = braziers.Length;
    }

    private void Update()
    {
        if (activatedBraziers == allBraziers)
        {
            gameObject.GetComponent<TilemapRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("levelLoader").GetComponent<levelLoader>().LoadNextLevel();
        }
    }
}