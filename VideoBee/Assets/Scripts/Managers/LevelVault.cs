using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class LevelVault : SingletonBase<LevelVault>
    {
        [SerializeField]
        private int m_startingPlayerLives;

        [SerializeField]
        private int m_numberOfLevels;

        private int m_currentPlayerLives;
        private int m_currentLevel = 1;

        public void Reset()
        {
            m_currentPlayerLives = m_startingPlayerLives;
            m_currentLevel = 1;
        }

        public int GetCurrentLevel()
        {
            return m_currentLevel;
        }

        public void IncrementLevel()
        {
            m_currentLevel++;
        }

        public void DecrementLives()
        {
            m_currentPlayerLives--;
        }

        public int GetCurrentLives()
        {
            return m_currentPlayerLives;
        }

        public bool GameComplete()
        {
            return m_currentLevel > m_numberOfLevels;
        }
    }
}
