using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace lvl_0
{
    public class UnsafeWallController : MonoBehaviour
    {
        [SerializeField]
        private float m_zapTime;

        private BeeController m_zappedBee;

        private Duration m_zappingDuration;

        private ZapperState m_state;

        private void Awake()
        {
            m_zappingDuration = new Duration(m_zapTime);
        }

        private void Update()
        {
            switch (m_state)
            {
                case ZapperState.Zapping:
                    m_zappingDuration.Update(Time.deltaTime);
                    if (m_zappingDuration.Elapsed())
                    {
                        m_zappedBee.Zapped();
                        ChangeState(ZapperState.Inert);
                    }
                    break;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (m_state == ZapperState.Inert)
            {
                if (collision.CompareTag("Player"))
                {
                    m_zappedBee = collision.GetComponent<BeeController>();
                    ChangeState(ZapperState.Zapping);
                }
            }
        }

        private void ChangeState(ZapperState newState)
        {
            switch (newState)
            {
                case ZapperState.Zapping:
                    m_zappingDuration.Reset();
                    break;
                case ZapperState.Inert:
                    m_zappedBee = null;
                    break;
            }
            m_state = newState;
        }
    }

    public enum ZapperState
    {
        Inert,
        Zapping
    }
}
