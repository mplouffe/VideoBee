using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField]
    private Collider2D m_targetCollider;

    public void SetCollider(bool turnOn)
    {
        if (m_targetCollider.enabled != turnOn)
        {
            m_targetCollider.enabled = turnOn;
        }
    }
}
