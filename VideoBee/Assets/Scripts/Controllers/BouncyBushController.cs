using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class BouncyBushController : MonoBehaviour
    {
        [SerializeField]
        private float m_bounceAmount;

        [SerializeField]
        private float m_bounceTime;

        [SerializeField]
        private float m_reductionMultiplier;

        private Duration m_bounceDuration;

        private Vector3 m_startSize;
        private Vector3 m_targetSize;

        private bool m_isBouncing;
        private bool m_isContracting;
        private float m_currentBounceTime;
        private float m_currentBounceAmount;

        private void Awake()
        {
            m_bounceDuration = new Duration(m_bounceTime);
        }


        private void Update()
        {
            if (m_isBouncing)
            {
                m_bounceDuration.Update(Time.deltaTime);
                if (m_bounceDuration.Elapsed())
                {
                    if (m_isContracting)
                    {
                        if (m_currentBounceAmount > 1)
                        {
                            m_currentBounceTime *= m_reductionMultiplier;
                            m_bounceDuration.Reset(m_currentBounceTime);
                            m_currentBounceAmount *= m_reductionMultiplier;
                            m_targetSize = Vector3.one * m_currentBounceAmount;
                            m_startSize = Vector3.one;
                            m_isContracting = false;
                        }
                        else
                        {
                            transform.localScale = Vector3.one;
                            m_isBouncing = false;
                        }
                    }
                    else
                    {
                        m_bounceDuration.Reset();
                        m_isContracting = true;
                        m_targetSize = Vector3.one;
                        m_startSize = transform.localScale;
                    }
                }
                else
                {
                    transform.localScale = Vector3.Lerp(m_startSize, m_targetSize, m_bounceDuration.Delta());
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            m_isBouncing = true;
            m_bounceDuration.Reset(m_bounceTime);
            m_currentBounceTime = m_bounceTime;
            m_startSize = Vector3.one;
            m_targetSize = Vector3.one * m_bounceAmount;
            m_currentBounceAmount = m_bounceAmount;
            m_isContracting = false;
        }

    }
}
