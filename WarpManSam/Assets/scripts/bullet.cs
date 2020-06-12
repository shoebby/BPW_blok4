using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    public float bulletSpeed = 0.1f;
    public GameObject impactEffect;

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, bulletSpeed * Time.deltaTime, 0) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);

            GameObject.Find("player").GetComponent<BoxCollider2D>().enabled = false;

            GameObject.Find("player").GetComponentInChildren<Animator>().enabled = true;

            GameObject.Find("levelLoader").GetComponent<levelLoader>().ReloadCurrentLevel();

            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Wall")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Brazier")
        {
            other.gameObject.GetComponent<Animator>().enabled = true;

            GameObject.FindWithTag("Exit").GetComponent<levelExit>().activatedBraziers += 1;

            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Splitter")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            GameObject.Find("player").GetComponent<playerMovement>().currentCharges = 4;
            GameObject.Find("player").GetComponent<playerMovement>().chargeBar.setMaxCharges(4);

            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}