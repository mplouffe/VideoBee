using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace lvl_0
{ 
    public class SpiderController : MonoBehaviour
    {
        [SerializeField]
        private float m_travelTime;

        [SerializeField]
        private Transform m_hangStart;

        [SerializeField]
        private Transform m_hangEnd;

        [SerializeField]
        private float m_hangTime;

        [SerializeField]
        private float m_trapTime;

        [SerializeField]
        private float m_feastTime;

        [SerializeField]
        private Transform m_webRoot;

        [SerializeField]
        private SpiderWeb m_web;

        [SerializeField]
        private Transform m_graphicsObject;

        [SerializeField]
        private GameObject m_anchors;

        private Vector3 m_trapStartPosition;
        private Vector3 m_targetPosition;
        private BeeController m_targetBee;

        private Vector3 m_hangStartPosition;
        private Vector3 m_hangEndPosition;
        private Vector3 m_webRootPosition;

        private Duration m_movingDuration;
        private Duration m_hangingDuration;
        private Duration m_trappingDuration;
        private Duration m_feastingDuration;

        private SpiderState m_state;

        private void Awake()
        {
            m_movingDuration = new Duration(m_travelTime);
            m_hangingDuration = new Duration(m_hangTime);
            m_trappingDuration = new Duration(m_trapTime);
            m_feastingDuration = new Duration(m_feastTime);
            m_web.OnBeeContact += OnBeeWebContact;

            m_hangStartPosition = m_hangStart.position;
            m_hangEndPosition = m_hangEnd.position;
            m_webRootPosition = m_webRoot.position;
            Destroy(m_anchors);

            ResetSpider();
        }

        private void OnDisable()
        {
            m_web.OnBeeContact -= OnBeeWebContact;
        }

        private void Update()
        {
            switch (m_state)
            {
                case SpiderState.Ascending:
                    m_movingDuration.Update(Time.deltaTime);
                    if (m_movingDuration.Elapsed())
                    {
                        ChangeState(SpiderState.Descending);
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(m_hangEndPosition, m_hangStartPosition, m_movingDuration.Delta());
                        m_web.Span(m_webRootPosition, transform.position);
                    }
                    break;
                case SpiderState.Descending:
                    m_movingDuration.Update(Time.deltaTime);
                    if (m_movingDuration.Elapsed())
                    {
                        ChangeState(SpiderState.Hanging);
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(m_hangStartPosition, m_hangEndPosition, m_movingDuration.Delta());
                        m_web.Span(m_webRootPosition, transform.position);
                    }
                    break;
                case SpiderState.Hanging:
                    m_hangingDuration.Update(Time.deltaTime);
                    if (m_hangingDuration.Elapsed())
                    {
                        ChangeState(SpiderState.Ascending);
                    }
                    break;
                case SpiderState.Trapping:
                    m_trappingDuration.Update(Time.deltaTime);
                    if (m_trappingDuration.Elapsed())
                    {
                        transform.position = m_targetPosition;
                        ChangeState(SpiderState.Feasting);
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(m_trapStartPosition, m_targetPosition, m_trappingDuration.Delta());
                        m_web.Span(m_webRootPosition, transform.position);
                    }
                    break;
                case SpiderState.Feasting:
                    m_feastingDuration.Update(Time.deltaTime);
                    if (m_feastingDuration.Elapsed())
                    {
                        ResetSpider();
                    }
                    break;
            }
        }

        private void ResetSpider()
        {
            transform.position = m_hangStartPosition;
            m_web.Span(m_webRootPosition, transform.localPosition);
            ChangeState(SpiderState.Descending);
        }

        private void OnBeeWebContact(Vector3 targetPosition, BeeController beeController)
        {
            m_targetPosition = targetPosition;
            m_trapStartPosition = transform.position;
            m_targetBee = beeController;
            ChangeState(SpiderState.Trapping);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                m_targetBee = collision.GetComponent<BeeController>();
                ChangeState(SpiderState.Feasting);
            }
        }

        private void ChangeState(SpiderState newState)
        {
            switch (newState)
            {
                case SpiderState.Ascending:
                    m_movingDuration.Reset();
                    m_graphicsObject.eulerAngles = new Vector3(0, 0, 180);
                    break;
                case SpiderState.Descending:
                    m_movingDuration.Reset();
                    m_graphicsObject.eulerAngles = new Vector3(0, 0, 0);
                    break;
                case SpiderState.Trapping:
                    m_trappingDuration.Reset();
                    var zRotation = m_targetPosition.y >= transform.position.y ? 180 : 0;
                    m_graphicsObject.eulerAngles = new Vector3(0, 0, zRotation);
                    break;
                case SpiderState.Hanging:
                    m_hangingDuration.Reset();
                    break;
                case SpiderState.Feasting:
                    m_targetBee.Eaten();
                    m_feastingDuration.Reset();
                    break;
            }

            m_state = newState;
        }
    }

    public enum SpiderState
    {
        Descending,
        Ascending,
        Hanging,
        Trapping,
        Feasting
    }
}
