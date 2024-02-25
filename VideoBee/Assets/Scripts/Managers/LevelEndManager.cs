using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class LevelEndManager : MonoBehaviour
    {
        [SerializeField]
        private float m_levelEndTime;

        private Duration m_levelEndDuration;
        private bool m_loaded = false;

        private void Awake()
        {
            m_levelEndDuration = new Duration(m_levelEndTime);
        }

        private void Update()
        {
            m_levelEndDuration.Update(Time.deltaTime);
            if (m_levelEndDuration.Elapsed() && !m_loaded)
            {
                m_loaded = true;
                LevelVault.Instance.IncrementLevel();
                if (LevelVault.Instance.GameComplete())
                {
                    LevelAttendant.Instance.LoadGameState(GameState.GameComplete);
                }
                else
                {
                    LevelAttendant.Instance.LoadLevel(LevelVault.Instance.GetCurrentLevel());
                }
            }
        }
    }
}
