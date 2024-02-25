using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class HeadAnimator : MonoBehaviour
    {
        [SerializeField]
        private RectTransform m_headTransform;

        [SerializeField]
        private float m_bobLength;

        [SerializeField]
        private AnimationCurve m_bobCurve;

        private Duration m_bobDuration;

        [SerializeField]
        private Vector2 m_bobTopPoint;

        [SerializeField]
        private Vector2 m_bobLowPoint;

        private bool m_isBobbingUp;

        private Vector2 m_currentStart;
        private Vector2 m_currentEnd;

        private HeadAnimationState m_currentState;

        private void Start()
        {
            m_bobDuration = new Duration(m_bobLength, m_bobCurve);
        }

        private void OnEnable()
        {
            ChangeState(HeadAnimationState.Bobbing);
        }

        private void ChangeState(HeadAnimationState newState)
        {
            switch (newState)
            {
                case HeadAnimationState.Bobbing:
                    var distanceToTop = Vector2.Distance(m_headTransform.anchoredPosition, m_bobTopPoint);
                    var distanceToBottom = Vector2.Distance(m_headTransform.anchoredPosition, m_bobLowPoint);
                    m_isBobbingUp = distanceToTop > distanceToBottom;
                    m_currentStart = m_headTransform.anchoredPosition;
                    m_currentEnd = m_isBobbingUp ? m_bobTopPoint : m_bobLowPoint;
                    break;
            }

            m_currentState = newState;
        }


        private void Update()
        {
            switch (m_currentState)
            {
                case HeadAnimationState.Bobbing:
                    m_bobDuration.Update(Time.deltaTime);
                    if (m_bobDuration.Elapsed())
                    {
                        m_headTransform.anchoredPosition = m_currentEnd;
                        m_isBobbingUp = !m_isBobbingUp;
                        m_currentEnd = m_isBobbingUp ? m_bobTopPoint : m_bobLowPoint;
                        m_currentStart = m_headTransform.anchoredPosition;
                        m_bobDuration.Reset();
                    }
                    else
                    {
                        m_headTransform.anchoredPosition = Vector2.Lerp(m_currentStart, m_currentEnd, m_bobDuration.CurvedDelta());
                    }
                    break;
            }
        }
    }

    public enum HeadAnimationState
    {
        Bobbing
    }
}
