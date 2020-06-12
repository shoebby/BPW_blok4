using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splitter : MonoBehaviour
{
    public GameObject splitBullet_1;
    public GameObject splitBullet_2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            splitBullet_1.SetActive(true);
            splitBullet_2.SetActive(true);
            Destroy(gameObject);
        }
    }
}
