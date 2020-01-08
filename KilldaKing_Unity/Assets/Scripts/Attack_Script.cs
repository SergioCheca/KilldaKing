using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Script : MonoBehaviour
{
    public float m_chargeTime = 0.0f;
    public float m_chargeTotalTime = 3.0f;
    public float m_OldRange;
    public float m_NewRange;
    public float m_lerpValue;

    // Start is called before the first frame update
    void Start()
    {
        m_OldRange = m_chargeTotalTime;
        m_NewRange = 1;
    }

    // Update is called once per frame
    void Update()
    {
        m_lerpValue = ((m_chargeTime * m_NewRange) / m_OldRange);

        if (Input.GetKey(KeyCode.P))
        {
            m_chargeTime += Time.deltaTime;

            if(m_chargeTime > m_chargeTotalTime)
            {
                Attack();
            }
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            m_chargeTime = 0;
        }

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 120, m_lerpValue));
    }

    void Attack()
    {

    }
}
