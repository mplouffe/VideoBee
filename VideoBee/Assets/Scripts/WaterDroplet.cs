using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class WaterDroplet : MonoBehaviour
    {

        [SerializeField]
        private ParticleSystem m_dropletBurst;

        [SerializeField]
        private GameObject m_graphicsObject;

        [SerializeField]
        private float m_burstTime;

        [SerializeField]
        private Collider2D m_dropCollider;

        private Vector3 m_fallingVelocity;

        private BeeController m_trappedPlayer;

        private DropletState m_state;

        private Duration m_burstDuration;

        private void Awake()
        {
            m_burstDuration = new Duration(m_burstTime);
            ChangeState(DropletState.Falling);
        }

        public void SetFallingRate(Vector3 fallingVelocity)
        {
            m_fallingVelocity = fallingVelocity;
        }

        private void FixedUpdate()
        {
            switch (m_state)
            {
                case DropletState.Trapping:
                    transform.position += m_fallingVelocity * Time.deltaTime;
                    m_trappedPlayer.transform.position = transform.position;
                    break;
                case DropletState.Falling:
                    transform.position += m_fallingVelocity * Time.deltaTime;
                    break;
                case DropletState.Bursting:
                    m_burstDuration.Update(Time.deltaTime);
                    if (m_burstDuration.Elapsed())
                    {
                        ChangeState(DropletState.Pooling);
                        Destroy(gameObject);
                    }
                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (m_state)
            {
                case DropletState.Falling:
                    if (collision.CompareTag("Player"))
                    {
                        m_trappedPlayer = collision.GetComponent<BeeController>();
                        ChangeState(DropletState.Trapping);
                    }
                    break;
            }

            if (collision.CompareTag("UnsafeWall") || collision.CompareTag("SafeWall"))
            {
                ChangeState(DropletState.Bursting);
            }

        }

        private void ChangeState(DropletState newState)
        {
            switch (newState)
            {
                case DropletState.Bursting:
                    if (m_state == DropletState.Trapping)
                    {
                        m_trappedPlayer.Drowned();
                        m_trappedPlayer = null;
                    }
                    m_dropCollider.enabled = false;
                    m_burstDuration.Reset();
                    m_graphicsObject.SetActive(false);
                    m_dropletBurst.Play();
                    break;
            }

            m_state = newState;
        }
    }

    public enum DropletState
    {
        Pooling,
        Falling,
        Trapping,
        Bursting
    }
}
