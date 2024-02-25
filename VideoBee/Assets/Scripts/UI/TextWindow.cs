namespace lvl_0
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    [Serializable]
    public struct TextWindowEvent : IEvent
    {
        public string[] texts;
    }

    public class TextWindow : MonoBehaviour, IEventReceiver<TextWindowEvent>
    {
        [SerializeField]
        private CanvasGroup m_textWindowCanvasGroup;

        [SerializeField]
        private TextMeshProUGUI m_textField;

        [SerializeField]
        private TextMeshProUGUI m_nextButtonText;

        [SerializeField]
        private Button m_nextButton;

        private bool m_isShowing;
        private string[] m_texts;
        private int m_currentText;

        void Start()
        {
            EventBus<TextWindowEvent>.Register(this);
        }

        private void OnDestroy()
        {
            EventBus<TextWindowEvent>.Unregister(this);
        }

        void Awake()
        {
            m_textWindowCanvasGroup.alpha = 0;
            m_textWindowCanvasGroup.interactable = false;
            m_textWindowCanvasGroup.blocksRaycasts = false;
        }

        public void OnEvent(TextWindowEvent e)
        {
            if (!m_isShowing)
            {
                m_isShowing = true;
                m_textWindowCanvasGroup.alpha = 1;
                m_textWindowCanvasGroup.interactable = true;
                m_textWindowCanvasGroup.blocksRaycasts = true;

                m_texts = (string[])e.texts.Clone();
                m_currentText = 0;

                m_textField.SetText(m_texts[0]);
                if (m_texts.Length > 1)
                {
                    SetNextButton();
                }
                else
                {
                    SetCloseButton();
                }
            }
        }

        private void SetNextButton()
        {
            m_nextButtonText.text = "->";
            m_nextButton.onClick.AddListener(OnNextButtonClicked);
        }

        private void SetCloseButton()
        {
            m_nextButtonText.text = "X";
            m_nextButton.onClick.AddListener(OnCloseButtonClicked);
        }

        public void OnNextButtonClicked()
        {
            m_currentText++;
            if (m_currentText < m_texts.Length)
            {
                m_textField.SetText(m_texts[m_currentText]);

                if (m_texts.Length - m_currentText == 1)
                {
                    m_nextButton.onClick.RemoveListener(OnNextButtonClicked);
                    SetCloseButton();
                }
            }
        }

        public void OnCloseButtonClicked()
        {
            m_textWindowCanvasGroup.alpha = 0;
            m_textWindowCanvasGroup.interactable = false;
            
            m_nextButton.onClick.RemoveListener(OnCloseButtonClicked);
            m_isShowing = false;
            EventBus<EventEndedEvent>.Raise(new EventEndedEvent());
        }
    }
}
