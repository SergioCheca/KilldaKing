using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Transform m_transform;
    public Vector3 m_destination;
    public float m_distance;
    public float m_cadence;
    public float m_cadenceTimer;


    void Start()
    {
        m_transform = transform;
    }


    void Update()
    {
        
    }
}
