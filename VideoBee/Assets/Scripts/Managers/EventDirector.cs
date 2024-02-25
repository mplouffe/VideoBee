using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class EventDirector : MonoBehaviour, IEventReceiver<EventEndedEvent>
    {
        private int m_currentEventIndex;

        [SerializeField]
        private List<DirectorEvent> m_events;

        private Duration m_waitDuration;
        private bool m_waiting;

        public void OnEvent(EventEndedEvent e)
        {
            m_currentEventIndex++;
            if (m_currentEventIndex < m_events.Count)
            {
                switch (m_events[m_currentEventIndex].EventType)
                {
                    case GameEvent.TextWindowEvent:
                        EventBus<TextWindowEvent>.Raise(m_events[m_currentEventIndex].TextWindowEvent);
                        break;
                    case GameEvent.CutSceneEvent:
                        EventBus<CutSceneEvent>.Raise(m_events[m_currentEventIndex].CutSceneEvent);
                        break;
                    case GameEvent.Wait:
                        m_waitDuration = new Duration(m_events[m_currentEventIndex].Wait);
                        m_waiting = true;
                        break;
                    case GameEvent.GameOver:
                        LevelAttendant.Instance.LoadGameState(GameState.GameOver);
                        break;
                    case GameEvent.GameStartEvent:
                        EventBus<GameStartEvent>.Raise(m_events[m_currentEventIndex].GameStartEvent);
                        break;
                    case GameEvent.HideCursorEvent:
                        EventBus<HideCursorEvent>.Raise(new HideCursorEvent());
                        break;

                }
            }
        }

        private void Awake()
        {
            EventBus<EventEndedEvent>.Register(this);
            m_currentEventIndex = -1;
        }

        private void OnDestroy()
        {
            EventBus<EventEndedEvent>.Unregister(this);
        }

        private void Update()
        {
            if (m_waiting)
            {
                m_waitDuration.Update(Time.deltaTime);
                if (m_waitDuration.Elapsed())
                {
                    m_waiting = false;
                    OnEvent(new EventEndedEvent());
                }
            }
        }
    }

    public struct EventEndedEvent : IEvent { }

    [Serializable]
    public struct GameStartEvent : IEvent
    {
        public Game Game;
    }

    public enum Game
    {
        BrowserBrickBreaker,
        CaptchaCatchYa,
        ClippyFileDestroyer,
    }
}
