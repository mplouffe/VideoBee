using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class BeeWing : MonoBehaviour
    {
        [SerializeField]
        private float m_wingTime;

        [SerializeField]
        private float m_scaleAmount;

        [SerializeField]
        private float m_rotationAmount;

        private Duration m_wingDuration;

        private Vector3 m_targetScale;
        private Vector3 m_startingScale;

        private Vector3 m_startingRotation;
        private Vector3 m_targetRotation;

        private void Awake()
        {
            m_wingDuration = new Duration(m_wingTime);
            m_startingScale = transform.localScale;
            m_targetScale = transform.localScale * m_scaleAmount;

            m_startingRotation = transform.eulerAngles;
            m_targetRotation = new Vector3(0, 0, transform.eulerAngles.z + m_rotationAmount);
        }

        // Update is called once per frame
        void Update()
        {
            m_wingDuration.Update(Time.deltaTime);
            if (m_wingDuration.Elapsed())
            {
                m_wingDuration.Reset();
                // Rotate targets, tra-la-la
                transform.localScale = m_targetScale;
                m_targetScale = m_startingScale;
                m_startingScale = transform.localScale;

                transform.eulerAngles = m_targetRotation;
                m_targetRotation = m_startingRotation;
                m_startingRotation = transform.eulerAngles;
            }
            else
            {
                transform.localScale = Vector3.Lerp(m_startingScale, m_targetScale, m_wingDuration.Delta());
                transform.eulerAngles = Vector3.Lerp(m_startingRotation, m_targetRotation, m_wingDuration.Delta());
            }
        }
    }
}
