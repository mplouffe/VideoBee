using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTrigger : MonoBehaviour
{
    public Action OnTriggerTripped;

    private bool m_triggerTripped;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!m_triggerTripped && collision.collider.CompareTag("Player"))
        {
            m_triggerTripped = true;
            OnTriggerTripped?.Invoke();
        }
    }
}
