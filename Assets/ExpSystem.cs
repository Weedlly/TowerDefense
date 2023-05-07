using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using System;


public class ExpSystem : MonoBehaviour
{
    // [SerializeField] private TMP_Text _currentExpText;
    // [SerializeField] private TMP_Text _slashText;
    // [SerializeField] private TMP_Text _expToNextLevelText;

    private static int _currentExp;
    private static int _expToNextLevel;

    public int _champLevel;

    public float delayUpExp = 6f;
    public bool isLevelUp;

    void Start()
    {
        _champLevel = 1;
        _currentExp = 0;
        _expToNextLevel = 20;

        // _currentExpText.text = _currentExp.ToString();
        // _expToNextLevelText.text = _expToNextLevel.ToString();
    }

    public void AddExperience(int amount)
    {
        _currentExp += amount;
        // _currentExpText.text = _currentExp.ToString();

        if (_currentExp >= _expToNextLevel)
        {
            //Enough exp to level up
            _champLevel++;
            _currentExp = 0;
            _expToNextLevel += _expToNextLevel;
            isLevelUp = true;

            // _currentExpText.text = _currentExp.ToString();
            // _expToNextLevelText.text = _expToNextLevel.ToString();
        }
    }

    public int GetLevelNumber()
    {
        return _champLevel;
    }

    public float GetAttackDameIncrease(float baseDame)
    {
        int currentLevel = GetLevelNumber();
        if (currentLevel > 1)
        {
            float part1 = (float) currentLevel / 10;
            float part2 = (float) currentLevel % 10;

            float dameIncrease = (float) currentLevel + ((part1 + part2) * Mathf.Pow(10, part1));
            baseDame += (int) dameIncrease;
        }
        
        return baseDame;
    }

    public float GetAttackSpeedIncrease(float baseAttackSpeed)
    {
        int currentLevel = GetLevelNumber();
        if (currentLevel > 1)
        {
            float part1 = (float) currentLevel / 10;
            float part2 = (float) currentLevel % 10;

            float attackSpeedIncrease = ((float) currentLevel + ((part1 + part2) * Mathf.Pow(10, part1))) / 100;
            baseAttackSpeed += Convert.ToSingle(string.Format("{0:0.00}", attackSpeedIncrease));
        }
        
        return baseAttackSpeed;
    }

    public float GetHealthIncrease(float baseHealth)
    {
        int currentLevel = GetLevelNumber();
        {
            float part1 = (float) currentLevel / 10;
            float part2 = (float) currentLevel % 10;

            float healthIncrease = (float) currentLevel + ((part1 + part2) * 10 * Mathf.Pow(10, part1));
            baseHealth += (int) healthIncrease;
        }

        return baseHealth;
    }

    private IEnumerator DelayUpExp()
    {
        yield return new WaitForSeconds(delayUpExp);
    }
}
