using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class BasicAnimator : MonoBehaviour
    {

        [SerializeField]
        private float m_startWaitDuration;

        [SerializeField]
        private float m_animateWaitDuration;

        [SerializeField]
        private AnimationCurve m_moveEasingCurve;

        [SerializeField]
        private Vector3 m_endPosition;
        private Vector3 m_startPosition;

        [SerializeField]
        private Vector3 m_endScale;
        private Vector3 m_startScale;

        [SerializeField]
        private Transform m_cursorTransform;

        private AnimatorState m_currentState;

        private Duration m_waitDuration;
        private Duration m_animateDuration;

        private void Awake()
        {
            m_waitDuration = new Duration(m_startWaitDuration);
            m_animateDuration = new Duration(m_animateWaitDuration, m_moveEasingCurve);
            m_startPosition = m_cursorTransform.position;
            m_startScale = m_cursorTransform.localScale;
        }

        void OnEnable()
        {
            m_currentState = AnimatorState.Waiting;

        }

        // Update is called once per frame
        void Update()
        {
            switch (m_currentState)
            {
                case AnimatorState.Waiting:
                    m_waitDuration.Update(Time.deltaTime);
                    if (m_waitDuration.Elapsed())
                    {
                        m_currentState = AnimatorState.Animating;
                    }
                    break;
                case AnimatorState.Animating:
                    m_animateDuration.Update(Time.deltaTime);
                    m_cursorTransform.position = Vector3.Lerp(m_startPosition, m_endPosition, m_animateDuration.CurvedDelta()); ;
                    m_cursorTransform.localScale = Vector3.Lerp(m_startScale, m_endScale, m_animateDuration.CurvedDelta());
                    if (m_animateDuration.Elapsed())
                    {
                        m_currentState = AnimatorState.FinishedMoving;
                    }
                    break;
            }
        }
    }

    public enum AnimatorState
    {
        Waiting,
        Animating,
        FinishedMoving
    }
}