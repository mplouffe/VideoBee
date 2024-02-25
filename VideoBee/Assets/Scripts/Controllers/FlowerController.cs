using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem m_pollenSystem;

    private bool m_pollenated = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!m_pollenated && collision.collider.CompareTag("Player"))
        {
            m_pollenated = true;
            m_pollenSystem.Play();
        }
    }
}
