using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace lvl_0
{
    public class LevelController : SingletonBase<LevelController>
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

        [SerializeField]
        private float m_deadTime;

        [SerializeField]
        private Transform m_beehiveSpawnPoint;

        private Vector3 m_levelStartPosition;

        private Duration m_startingDuration;
        private Duration m_restingDuration;
        private Duration m_endingDuration;
        private Duration m_deadDuration;

        private LevelState m_levelState;
        private LevelState m_previousLevelState;

        private Controls m_controls;

        protected override void Awake()
        {
            base.Awake();
            m_startingDuration = new Duration(m_startTime);
            m_restingDuration = new Duration(m_restTime);
            m_endingDuration = new Duration(m_endTime);
            m_deadDuration = new Duration(m_deadTime);
            m_controls = new Controls();
        }

        private void OnEnable()
        {
            m_levelStartPosition = m_beehiveSpawnPoint.position;
            m_player.OnBeeCollison += OnBeeCollision;
            m_controls.EscapeMenu.Confirm.performed += OnConfirmPerformed;
            m_controls.EscapeMenu.Cancel.performed += OnCancelPerformed;
            m_controls.PauseMenu.Pause.performed += OnPausePerformed;
        }

        private void OnDisable()
        {
            m_player.OnBeeCollison -= OnBeeCollision;
            m_controls.EscapeMenu.Confirm.performed -= OnConfirmPerformed;
            m_controls.EscapeMenu.Cancel.performed -= OnCancelPerformed;
            m_controls.PauseMenu.Pause.performed -= OnPausePerformed;
        }

        private void Start()
        {
            m_hud.UpdateLives(LevelVault.Instance.GetCurrentLives());
            ChangeState(LevelState.Starting);
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
                case LevelState.Pollenating:
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
                        PopupsManager.Instance.LevelEnd(false);
                        LevelAttendant.Instance.LoadGameState(GameState.LevelEnd);
                    }
                    break;
                case LevelState.Dead:
                    m_deadDuration.Update(Time.deltaTime);
                    if (m_deadDuration.Elapsed())
                    {
                        if (LevelVault.Instance.GetCurrentLives() > 0)
                        {
                            ChangeState(LevelState.Starting);
                        }
                        else
                        {
                            LevelAttendant.Instance.LoadGameState(GameState.GameOver);
                        }
                    }
                    break;
            }
        }

        public void Escape()
        {
            switch (m_levelState)
            {
                case LevelState.Escaped:
                    LevelAttendant.Instance.LoadGameState(GameState.Menu);
                    break;
                case LevelState.Paused:
                case LevelState.Fetching:
                case LevelState.Returning:
                    ChangeState(LevelState.Escaped);
                    break;
            }
        }

        public void Pause()
        {
            switch (m_levelState)
            {
                case LevelState.Paused:
                    ChangeState(m_previousLevelState);
                    break;
                case LevelState.Escaped:
                case LevelState.Fetching:
                case LevelState.Returning:
                    ChangeState(LevelState.Paused);
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
            
            switch (m_levelState)
            {
                case LevelState.Paused:
                    PopupsManager.Instance.Pause(false);
                    m_controls.PauseMenu.Disable();
                    break;
                case LevelState.Escaped:
                    PopupsManager.Instance.Escaped(false);
                    m_controls.EscapeMenu.Disable();
                    break;
                case LevelState.Starting:
                    PopupsManager.Instance.LevelStart(false);
                    break;
                case LevelState.Pollenating:
                    PopupsManager.Instance.Pollenating(false);
                    break;
            }

            switch (newState)
            {
                case LevelState.Starting:
                    m_startingDuration.Reset();
                    m_player.ResetPlayer(m_levelStartPosition);
                    m_player.ChangeState(BeeState.Resting);
                    m_beehive.SetCollider(false);
                    m_flower.SetCollider(true);
                    PopupsManager.Instance.LevelStart(true, LevelVault.Instance.GetCurrentLevel());
                    m_camera.Follow = m_player.transform;
                    break;
                case LevelState.Fetching:
                    m_flower.SetCollider(true);
                    m_player.ChangeState(BeeState.Alive);
                    m_hud.UpdateStateText("Find Flowers");
                    break;
                case LevelState.Pollenating:
                    m_restingDuration.Reset();
                    m_flower.SetCollider(false);
                    m_player.ChangeState(BeeState.Resting);
                    m_hud.UpdateStateText("");
                    PopupsManager.Instance.Pollenating(true);
                    break;
                case LevelState.Returning:
                    m_beehive.SetCollider(true);
                    m_player.ChangeState(BeeState.Alive);
                    m_hud.UpdateStateText("Return Home");
                    break;
                case LevelState.Ending:
                    m_endingDuration.Reset();
                    m_beehive.SetCollider(false);
                    m_player.ChangeState(BeeState.Resting);
                    m_hud.UpdateStateText("");
                    PopupsManager.Instance.LevelEnd(true);
                    break;
                case LevelState.Dead:
                    LevelVault.Instance.DecrementLives();
                    m_hud.UpdateLives(LevelVault.Instance.GetCurrentLives());
                    m_deadDuration.Reset();
                    m_hud.UpdateStateText("Dead!");
                    break;
                case LevelState.Paused:
                    m_previousLevelState = m_levelState;
                    m_player.ChangeState(BeeState.Resting);
                    m_controls.PauseMenu.Enable();
                    PopupsManager.Instance.Pause(true);
                    break;
                case LevelState.Escaped:
                    m_previousLevelState = m_levelState;
                    m_player.ChangeState(BeeState.Resting);
                    m_controls.EscapeMenu.Enable();
                    PopupsManager.Instance.Escaped(true);
                    break;
            }

            m_levelState = newState;
        }

        private void OnBeeCollision(CollisionObject collision)
        {
            switch (collision)
            {
                case CollisionObject.Beehive:
                    if (m_levelState == LevelState.Returning)
                    {
                        ChangeState(LevelState.Ending);
                    }
                    break;
                case CollisionObject.Flower:
                    if (m_levelState == LevelState.Fetching)
                    {
                        ChangeState(LevelState.Pollenating);
                    }
                    break;
                case CollisionObject.Enemy:
                    ChangeState(LevelState.Dead);
                    break;
            }
        }

        private void OnConfirmPerformed(CallbackContext context)
        {
            m_controls.EscapeMenu.Disable();
            LevelAttendant.Instance.LoadGameState(GameState.Menu);
        }

        private void OnCancelPerformed(CallbackContext context)
        {
            ChangeState(m_previousLevelState);
        }

        private void OnPausePerformed(CallbackContext context)
        {
            ChangeState(m_previousLevelState);
        }
    }

    public enum LevelState
    {
        Unset,
        Starting,
        Fetching,
        Pollenating,
        Returning,
        Ending,
        Dead,
        Paused,
        Escaped
    }

    public enum CollisionObject
    {
        Beehive,
        Flower,
        Enemy
    }
}
