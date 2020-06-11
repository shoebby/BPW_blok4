using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class leverTrigger : MonoBehaviour
{
    public TilemapRenderer leverDown;
    public GameObject Splitter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            leverDown.enabled = true;
            gameObject.GetComponent<TilemapRenderer>().enabled = false;

            Splitter.SetActive(true);
        }
    }
}
