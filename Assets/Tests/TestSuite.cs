using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine.UI;

public class TestSuite : MonoBehaviour
{
    [Test]
    public void CriticalDamageIsDisplayed()
    {
        GameObject go = new GameObject();
        var attackedScrollingText = go.AddComponent<AttackedScrollingText>();

        float damage = 50f;
        bool isCritical = true;

        attackedScrollingText.OnAttack(damage, isCritical);

        LogAssert.Expect(LogType.Log, "Critical damage: 50");
    }
    [Test]
    public void NormalDamageIsDisplayed()
    {
        GameObject go = new GameObject();
        go.AddComponent<AttackedScrollingText>();

        var attackedScrollingText = go.GetComponent<AttackedScrollingText>();

        float damage = 10f;
        bool isCritical = false;

        attackedScrollingText.OnAttack(damage, isCritical);

        LogAssert.Expect(LogType.Log, "Normal damage: 10");
    }
    [Test]
    public void HealthUIDisplaysCorrectHealthAmount()
    {
        GameObject go = new GameObject();
        var healthUI = go.AddComponent<HealthUI>();

        float healthValue = 30f;
        float maxValue = 100f;

        float expectedFillAmount = healthValue / maxValue;

        healthUI.DisplayHealth(healthValue, maxValue);

        LogAssert.Expect(LogType.Log, "Current health bar fill amount: " + expectedFillAmount);
    }
    [Test]
    public void ScoreIsSavedWhenAdded()
    {
        GameObject go = new GameObject();
        var gameManager = go.AddComponent<GameManager>();

        gameManager.score = 0;

        int scoreToAdd = 100;
        int expectedScore = gameManager.score + scoreToAdd;

        gameManager.AddScore(scoreToAdd);

        Assert.AreEqual(PlayerPrefs.GetInt("Score"), expectedScore);

    }
    
    [Test]
    public void SelectedPlayerNumberIsSaved()
    {
        GameObject go = new GameObject();
        var characterSelection = go.AddComponent<CharacterSelection>();

        int charNumber = 1;
        characterSelection.SelectPlayer(charNumber);

        Assert.AreEqual(PlayerPrefs.GetInt("PlayerChar"), charNumber);
    }

    [Test]
    public void NextSceneIsLoadedWhenAllEnemiesAreDefeated()
    {
        GameObject go = new GameObject();
        var enemyManager = go.AddComponent<EnemyManager>();

        enemyManager.numberOfWaves = 1;

        enemyManager.SpawnEnemyWave();
        enemyManager.SpawnEnemyWave();

        LogAssert.Expect(LogType.Log, "Level cleared!");

    }
}
