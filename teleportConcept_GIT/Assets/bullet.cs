using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSpeed = 0.1f;

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, bulletSpeed * Time.deltaTime, 0) * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "wall")
        {
            Destroy(col.gameObject);
        }
    }
}