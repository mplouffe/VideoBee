using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class ObjectAnimator : MonoBehaviour, IEventReceiver<CutSceneEvent>, IEventReceiver<HideCursorEvent>
    {
        [SerializeField]
        private List<AnimateableObject> m_animObjects;

        private Dictionary<AnimObject, RectTransform> m_objectDictionary;

        private CutSceneEvent m_currentEvent;
        private Duration m_currentEventDuration;
        
        private bool m_animatingObject;


        private void Awake()
        {
            m_objectDictionary = new Dictionary<AnimObject, RectTransform>(m_animObjects.Count);
            foreach (var animObject in m_animObjects)
            {
                m_objectDictionary.Add(animObject.animObject, animObject.transform);
            }
        }

        private void OnEnable()
        {
            EventBus<CutSceneEvent>.Register(this);
            EventBus<HideCursorEvent>.Register(this);
        }

        private void OnDisable()
        {
            EventBus<CutSceneEvent>.Unregister(this);
            EventBus<HideCursorEvent>.Unregister(this);
        }

        public void OnEvent(CutSceneEvent e)
        {
            if (!m_animatingObject)
            {
                m_currentEvent = e;
                m_currentEventDuration = new Duration(m_currentEvent.moveDuration);
                m_animatingObject = true;

                m_objectDictionary[m_currentEvent.animObject].gameObject.SetActive(true);
                var currentTransform = m_objectDictionary[m_currentEvent.animObject];
                m_currentEvent.startingPosition = currentTransform.anchoredPosition;
            }
        }

        public void OnEvent(HideCursorEvent e)
        {
            m_objectDictionary[AnimObject.Cursor].gameObject.SetActive(false);
            EventBus<EventEndedEvent>.Raise(new EventEndedEvent());
        }

        private void Update()
        {
            if (m_animatingObject)
            {
                m_currentEventDuration.Update(Time.deltaTime);
                var currentTransform = m_objectDictionary[m_currentEvent.animObject];
                if (m_currentEventDuration.Elapsed())
                {
                    m_animatingObject = false;
                    currentTransform.anchoredPosition = m_currentEvent.endingPosition;
                    EventBus<EventEndedEvent>.Raise(new EventEndedEvent());
                }
                else
                {
                    currentTransform.anchoredPosition = Vector3.Lerp(m_currentEvent.startingPosition, m_currentEvent.endingPosition, m_currentEventDuration.Delta());
                }
            }
        }
    }

    [Serializable]
    public struct CutSceneEvent : IEvent
    {
        public AnimObject animObject;
        [HideInInspector]
        public Vector3 startingPosition;
        public Vector3 endingPosition;
        public float moveDuration;
    }

    public struct HideCursorEvent : IEvent
    { }

    [Serializable]
    public struct AnimateableObject
    {
        public AnimObject animObject;
        public RectTransform transform;
    }

    public enum AnimObject
    {
        Cursor
    }
}
