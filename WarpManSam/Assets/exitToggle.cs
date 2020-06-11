using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class exitToggle : MonoBehaviour
{
    public Animator brazier1;
    public Animator brazier2;
    public Animator brazier3;
    public Animator brazier4;

    private void Start()
    {
        brazier1 = GameObject.Find("topLeftBrazier").GetComponent<Animator>();
        brazier2 = GameObject.Find("topRightBrazier").GetComponent<Animator>();
        brazier3 = GameObject.Find("bottomRightBrazier").GetComponent<Animator>();
        brazier4 = GameObject.Find("bottomLeftBrazier").GetComponent<Animator>();
    }

    void Update()
    {
        if (brazier1.enabled == true && brazier2.enabled == true && brazier3.enabled == true && brazier4.enabled == true)
        {
            gameObject.GetComponent<TilemapRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(1);
        }
    }
}
