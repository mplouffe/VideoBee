using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class DripController : MonoBehaviour
    {
        [SerializeField]
        private Transform m_drip;

        [SerializeField]
        private WaterDroplet m_dropletPrefab;

        [SerializeField]
        private float m_droopTime;

        [SerializeField]
        private float m_droopAmount;

        [SerializeField]
        private Transform m_dripLocation;

        [SerializeField]
        private Vector3 m_dripVelocity;

        private Duration m_droopDuration;

        private Vector3 m_droopStart;
        private Vector3 m_droopTarget;

        private void Awake()
        {
            m_droopDuration = new Duration(m_droopTime);

            m_droopStart = m_drip.localScale;
            m_droopTarget = new Vector3(m_drip.localScale.x, m_drip.localScale.y + m_droopAmount, m_drip.localScale.z);
        }

        private void Update()
        {
            m_droopDuration.Update(Time.deltaTime);
            if (m_droopDuration.Elapsed())
            {
                var waterDroplet = Instantiate(m_dropletPrefab, m_dripLocation.position, Quaternion.identity);
                Debug.Log("Droplet Created");
                waterDroplet.SetFallingRate(m_dripVelocity);
                m_drip.localScale = m_droopStart;
                m_droopDuration.Reset();
            }
            else
            {
                m_drip.localScale = Vector3.Lerp(m_droopStart, m_droopTarget, m_droopDuration.Delta());
            }
        }
    }
}
