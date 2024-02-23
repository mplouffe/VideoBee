using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField]
        private BeeController m_player;

        [SerializeField]
        private TargetController m_beehive;

        [SerializeField]
        private TargetController m_flower;

        [SerializeField]
        private HUDController m_hud;

        [SerializeField]
        private CinemachineVirtualCamera m_camera;

        [SerializeField]
        private float m_startTime;

        [SerializeField]
        private float m_restTime;

        [SerializeField]
        private float m_endTime;


        private Duration m_startingDuration;
        private Duration m_restingDuration;
        private Duration m_endingDuration;

        private LevelState m_levelState;

        private void Awake()
        {
            m_player.OnBeeCollison += OnBeeCollision;
            m_startingDuration = new Duration(m_startTime);
            m_restingDuration = new Duration(m_restTime);
            m_endingDuration = new Duration(m_endTime);
            ChangeState(LevelState.Starting);
        }

        private void OnDisable()
        {
            m_player.OnBeeCollison -= OnBeeCollision;
        }

        private void Update()
        {
            switch (m_levelState)
            {
                case LevelState.Starting:
                    m_startingDuration.Update(Time.deltaTime);
                    if (m_startingDuration.Elapsed())
                    {
                        ChangeState(LevelState.Fetching);
                    }
                    break;
                case LevelState.Fetching:

                    break;
                case LevelState.Resting:
                    m_restingDuration.Update(Time.deltaTime);
                    if (m_restingDuration.Elapsed())
                    {
                        ChangeState(LevelState.Returning);
                    }
                    break;
                case LevelState.Returning:
                    break;
                case LevelState.Ending:
                    m_endingDuration.Update(Time.deltaTime);
                    if (m_endingDuration.Elapsed())
                    {
                        ChangeState(LevelState.Starting);
                    }
                    break;
            }
        }

        private void ChangeState(LevelState newState)
        {
            if (newState == m_levelState)
            {
                Debug.LogError($"Error: Attempting to switch to current state: [{m_levelState}]");
                return;
            }

            switch (newState)
            {
                case LevelState.Starting:
                    m_startingDuration.Reset();
                    m_player.SetState(BeeState.Resting);
                    m_beehive.SetCollider(false);
                    m_flower.SetCollider(true);
                    m_hud.UpdateStateText("Starting...");
                    m_camera.Follow = m_player.transform;
                    break;
                case LevelState.Fetching:
                    m_flower.SetCollider(true);
                    m_player.SetState(BeeState.Alive);
                    m_hud.UpdateStateText("Fetching...");
                    break;
                case LevelState.Resting:
                    m_restingDuration.Reset();
                    m_flower.SetCollider(false);
                    m_player.SetState(BeeState.Resting);
                    m_hud.UpdateStateText("Resting...");
                    break;
                case LevelState.Returning:
                    m_beehive.SetCollider(true);
                    m_player.SetState(BeeState.Alive);
                    m_hud.UpdateStateText("Returning...");
                    break;
                case LevelState.Ending:
                    m_endingDuration.Reset();
                    m_beehive.SetCollider(false);
                    m_player.SetState(BeeState.Resting);
                    m_hud.UpdateStateText("Ending...");
                    break;
            }

            m_levelState = newState;
        }

        private void OnBeeCollision(Collider2D collider)
        {
            if (collider.CompareTag("Beehive"))
            {
                if (m_levelState == LevelState.Returning)
                {
                    ChangeState(LevelState.Ending);
                }
            }
            else if (collider.CompareTag("Flower"))
            {
                if (m_levelState == LevelState.Fetching)
                {
                    ChangeState(LevelState.Resting);
                }
            }
        }
    }

    public enum LevelState
    {
        Unset,
        Starting,
        Fetching,
        Resting,
        Returning,
        Ending
    }
}
