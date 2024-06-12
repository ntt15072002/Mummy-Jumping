using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Platform
{
    public float moveSpeed;
    private bool m_canMoveLeft;
    private bool m_canMoveRight;

    protected override void Start()
    {
        base.Start();

        float randCheck = Random.Range(0f, 1f);
        if (randCheck <= 0.5f)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1,
                                transform.localScale.y, transform.localScale.z);
            m_canMoveLeft = true;
            m_canMoveRight = false;
        }
        else if (randCheck > 0.5f)
        {
            transform.localScale = new Vector3(transform.localScale.x * 1,
                                transform.localScale.y, transform.localScale.z);
            m_canMoveLeft = false;
            m_canMoveRight = true;
        }
    }

    private void FixedUpdate()
    {
        float curSpeed = 0;

        if (!m_rd) return;

        if (m_canMoveLeft)
        {
            curSpeed = -moveSpeed;
        }
        else if (m_canMoveRight)
        {
            curSpeed = moveSpeed;
        }

        m_rd.velocity = new Vector2(curSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(GameTag.Leftcorner.ToString()))
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1,
                                transform.localScale.y, transform.localScale.z);
            }
            
            m_canMoveLeft = false;
            m_canMoveRight = true;
        }
        else if (col.CompareTag(GameTag.Rightcorner.ToString()))
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1,
                                transform.localScale.y, transform.localScale.z);
            }
            m_canMoveLeft = true;
            m_canMoveRight = false;
        }

    }
}