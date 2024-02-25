using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace lvl_0
{
    public class InstructionsManager : MonoBehaviour
    {
        [SerializeField]
        private List<Instruction> m_instructions;

        [SerializeField]
        private TextMeshProUGUI m_instructionsText;

        private Duration m_instructionDuration;
        private Duration m_inputDelay;

        private int m_currentInstruction;

        private Controls m_controls;

        private bool m_loading = false;

        private void Awake()
        {
            m_currentInstruction = 0;
            SetInstruction();
            m_inputDelay = new Duration(0.5f);
            m_controls = new Controls();
        }

        private void OnEnable()
        {
            m_controls.Instructions.Confirm.performed += OnConfirmPressed;
            m_controls.Instructions.Enable();
        }

        // Update is called once per frame
        void Update()
        {
            m_instructionDuration.Update(Time.deltaTime);
            if (m_instructionDuration.Elapsed())
            {
                m_currentInstruction++;
                if (m_currentInstruction >= m_instructions.Count)
                {
                    m_currentInstruction = 0;
                }
                SetInstruction();
            }

            if (!m_inputDelay.Elapsed())
            {
                m_inputDelay.Update(Time.deltaTime);
            }
        }

        private void SetInstruction()
        {
            m_instructionsText.text = m_instructions[m_currentInstruction].text;
            m_instructionDuration = new Duration(m_instructions[m_currentInstruction].duration);
        }
        private void OnConfirmPressed(CallbackContext context)
        {
            if (m_inputDelay.Elapsed() && !m_loading)
            {
                m_loading = true;
                LevelAttendant.Instance.LoadGameState(GameState.GameStart);
            }
        }

    }

    [Serializable]
    public struct Instruction
    {
        public float duration;
        public string text;
    }
}
