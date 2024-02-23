using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_StateText;

    private void Awake()
    {
        m_StateText.text = string.Empty;
        HideText();
    }

    public void UpdateStateText(string newText)
    {
        m_StateText.text = newText;
        ShowText();
    }

    public void ShowText()
    {
        m_StateText.gameObject.SetActive(true);
    }

    public void HideText()
    {
        m_StateText.gameObject.SetActive(false);
    }
}
