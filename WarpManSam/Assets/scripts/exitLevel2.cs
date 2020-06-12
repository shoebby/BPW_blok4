using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class exitLevel2 : MonoBehaviour
{
    public Animator brazier1;
    public Animator brazier2;

    private void Start()
    {
        brazier1 = GameObject.Find("brazierLeft").GetComponent<Animator>();
        brazier2 = GameObject.Find("brazierRight").GetComponent<Animator>();
    }

    void Update()
    {
        if (brazier1.enabled == true && brazier2.enabled == true)
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
