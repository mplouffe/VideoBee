using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class WindController : MonoBehaviour
    {
        [SerializeField]
        private Vector3 m_wind;

        [SerializeField]
        private bool m_isTriggered;

        [SerializeField]
        private WindTrigger m_windtrigger;

        [SerializeField]
        private ParticleSystem m_windParticles;

        [SerializeField]
        private Collider2D m_collider;

        private WindState m_state;

        private bool m_isApplied;

        private void OnEnable()
        {
            if (m_isTriggered)
            {
                m_state = WindState.Inert;
                m_windtrigger.OnTriggerTripped += OnTriggerTripped;
                m_collider.enabled = false;
            }
            else
            {
                m_state = WindState.Animated;
                m_windParticles.Play();
            }
        }

        private void OnDisable()
        {
            if (m_isTriggered)
            {
                m_windtrigger.OnTriggerTripped -= OnTriggerTripped;
            }
        }

        private void OnTriggerTripped()
        {
            if (m_state == WindState.Inert)
            {
                m_state = WindState.Animated;
                m_windParticles.Play();
                m_collider.enabled = true;
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (m_state == WindState.Inert)
            {
                return;
            }

            if (!m_isApplied && collision.CompareTag("Player"))
            {
                var beeController = collision.GetComponent<BeeController>();
                beeController.ChangeWind(m_wind);
                m_isApplied = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (m_state == WindState.Inert)
            {
                return;
            }

            if (m_isApplied && collision.CompareTag("Player"))
            {
                var beeController = collision.GetComponent<BeeController>();
                beeController.ChangeWind(Vector3.zero);
                m_isApplied = false;
            }
        }
    }

    public enum WindZoneType
    {
        Triggered,
        Constant,
        Random
    }

    public enum WindState
    {
        Animated,
        Inert,
    }
}
