using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace lvl_0
{
    public class SpriteFlasher : MonoBehaviour
    {
        [SerializeField]
        private Image m_flasingImage;

        [SerializeField]
        private float m_flashingSpeed;
        private Duration m_flashing;

        private bool m_isFlashing;
        private bool m_towardsEnd;

        private Color m_startingColor = Color.clear;
        private Color m_endingColor = Color.white;

        private void Awake()
        {
            m_flashing = new Duration(m_flashingSpeed);
            m_flasingImage.color = m_startingColor;
        }

        private void Update()
        {
            if (m_isFlashing)
            {
                var endTarget = m_towardsEnd ? m_endingColor : m_startingColor;
                var startTarget = m_towardsEnd ? m_startingColor : m_endingColor;

                m_flashing.Update(Time.deltaTime);
                if (m_flashing.Elapsed())
                {

                    m_flasingImage.color = endTarget;
                    m_flashing.Reset();
                    m_towardsEnd = !m_towardsEnd;
                }
                else
                {
                    m_flasingImage.color = Color.Lerp(startTarget, endTarget, m_flashing.Delta());
                }
            }
        }

        public void StartFlashing()
        {
            m_flashing.Reset();
            m_isFlashing = true;
            m_towardsEnd = true;
            m_flasingImage.color = m_startingColor;
        }

        public void StopFlashing()
        {
            m_isFlashing = false;
        }

    }
}
