using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    Vector3 m_destination;
    public float m_distance;
    public float m_cadence;
    float m_cadenceTimer;
    public bool m_checkEnemy;

    float m_chargeTime = 0.0f;
    public float m_chargeTotalTime = 3.0f;
    float m_OldRange;
    float m_NewRange;
    float m_lerpValue;
    Transform m_arm;
    float m_yRotation;

    public float m_checkTime;
    float m_checkTimer;

    private void OnEnable()
    {
        m_cadenceTimer = m_cadence;
        m_OldRange = m_chargeTotalTime;
        m_NewRange = 1;
        m_arm = transform.Find("Arm");
        m_destination = transform.position;
        m_checkTimer = m_checkTime;
    }

    void Update()
    {
        m_checkTimer -= Time.deltaTime;
        if (m_checkEnemy)
        {
            m_yRotation = 180;
            m_checkTimer = m_checkTime;
        }
        else if(m_checkTimer<=0)
        {
            m_yRotation = 0;

            m_cadenceTimer -= Time.deltaTime;
            if (m_cadenceTimer <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    m_cadenceTimer = m_cadence;
                    m_destination = new Vector2(transform.position.x + m_distance, transform.position.y);
                }
            }

            if (Input.GetKey(KeyCode.P))
            {
                m_chargeTime += Time.deltaTime;

                if (m_chargeTime > m_chargeTotalTime)
                {
                    Attack();
                }
            }

            if (Input.GetKeyUp(KeyCode.P))
            {
                m_chargeTime = 0;

            }

        }
        transform.position = Vector2.Lerp(transform.position, m_destination, Time.deltaTime * 2);

        if (Input.GetKeyDown(KeyCode.A))
        {
            m_checkEnemy = true;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            m_checkEnemy = false;

        }

        m_lerpValue = ((m_chargeTime * m_NewRange) / m_OldRange);

        m_arm.rotation = Quaternion.Euler(0, m_yRotation, Mathf.Lerp(-60, 120, m_lerpValue));
        transform.rotation = Quaternion.Euler(0, m_yRotation, 0);
    }

    void Attack()
    {
        
    }
}
