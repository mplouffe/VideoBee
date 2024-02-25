using lvl_0;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    [SerializeField]
    private float m_inputCooldown;

    private Duration m_inputCooldownDuration;

    private Controls m_inputActions;

    private void Awake()
    {
        m_inputCooldownDuration = new Duration(m_inputCooldown);
        m_inputActions = new Controls();
    }

    private void OnEnable()
    {
        m_inputActions.SettingsScreen.Enable();
        m_inputActions.SettingsScreen.Back.performed += OnBackSelected;
    }

    private void OnDisable()
    {
        m_inputActions.SettingsScreen.Back.performed -= OnBackSelected;
        m_inputActions.SettingsScreen.Disable();
    }

    private void Update()
    {
        m_inputCooldownDuration.Update(Time.deltaTime);
    }

    private void OnBackSelected(CallbackContext context)
    {
        if (m_inputCooldownDuration.Elapsed())
        {
            m_inputCooldownDuration.Reset();
            LevelAttendant.Instance.LoadGameState(GameState.Menu);
        }
    }
}
