using System;
using UnityEngine;

internal class Experience : MonoBehaviour
{
    private int current;
    public event Action Changed;

    private int previousExperienceToLevel = 2;
    private int experienceToLevel = 3;

    public float GetExperienceProgress() => (float) current / experienceToLevel;

    public void Add(int amount = 1)
    {
        current += amount;
        Changed?.Invoke();

        if (current < GetLevelUpExperienceRequirement())
            return;

        current -= GetLevelUpExperienceRequirement();
        LevelUp();
    }

    private void LevelUp()
    {
        (experienceToLevel, previousExperienceToLevel) = (experienceToLevel + previousExperienceToLevel, experienceToLevel);
        Changed?.Invoke();
    }

    private int GetLevelUpExperienceRequirement()
    {
        return experienceToLevel;
    }
}