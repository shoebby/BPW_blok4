using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMovement : MonoBehaviour
{
    public Vector3 target;
    public Vector3 previousPosition;
    public GameObject bullet;
    public healthbar manaBar;

    Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;

    public timeManager timeManager;

    public LayerMask WallLayer;

    public float maxMana = 100f;
    public float minMana = 0f;
    public float currentMana;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = transform.position;

        currentMana = maxMana;
        manaBar.setMaxMana(currentMana);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            timeManager.doSlowmotion();

            if (currentMana > minMana)
            {
                currentMana -= 0.05f;
                manaBar.setMana(currentMana);
            }
        }
        else
        {
            manaRegen();
            manaBar.setMana(currentMana);
        }

        if (Input.GetMouseButtonUp(0) && currentMana >= 25)
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
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    public void Teleport()
    {
        currentMana = currentMana - 25;
        manaBar.setMana(currentMana);

        previousPosition = gameObject.transform.position;

        target = mousePos;
        target.z = transform.position.z;
        transform.position = target;

        GameObject go = Instantiate(bullet, previousPosition, Quaternion.identity);
        go.transform.rotation = transform.rotation;

        timeManager.doSlowmotion();
    }

    public void manaRegen()
    {
        if (currentMana < maxMana)
        {
            currentMana += 0.1f;
        }
    }
}
