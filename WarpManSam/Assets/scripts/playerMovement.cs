using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public Vector3 target;
    public Vector3 previousPosition;
    public GameObject bullet;
    public healthbar chargeBar;

    Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;

    public timeManager timeManager;

    public LayerMask WallLayer;

    public float maxCharges = 4f;
    public float minCharges = 0f;
    public float currentCharges;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = transform.position;

        currentCharges = maxCharges;
        chargeBar.setMaxCharges(currentCharges);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            timeManager.doSlowmotion();
        }

        if (Input.GetMouseButtonUp(0) && currentCharges >= 1)
        {
            if (Physics2D.CircleCast(mousePos, 0.35f, Vector3.forward, 1, WallLayer))
            {
                Debug.Log("nothing");
            }
            else
            {
                Teleport();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            gameObject.GetComponentInChildren<Animator>().enabled = true;

            GameObject.Find("levelLoader").GetComponent<levelLoader>().ReloadCurrentLevel();
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void Teleport()
    {
        currentCharges = currentCharges - 1;
        chargeBar.setCharges(currentCharges);

        previousPosition = gameObject.transform.position;

        target = mousePos;
        target.z = transform.position.z;
        transform.position = target;

        GameObject go = Instantiate(bullet, previousPosition, Quaternion.identity);
        go.transform.rotation = transform.rotation;

        timeManager.doSlowmotion();
    }
}