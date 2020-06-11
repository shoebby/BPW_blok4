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
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (other.gameObject.tag == "Wall")
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Brazier")
        {
            other.gameObject.GetComponent<Animator>().enabled = true;
            Destroy(gameObject);
        }
    }
}