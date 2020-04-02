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
    [Test]
    public void BossHealthUIDisplaysCorrectHealthAmount()
    {
        GameObject go = new GameObject();
        var healthUI = go.AddComponent<HealthUI>();
        healthUI.isBoss = true;

        float healthValue = 120f;
        float maxValue = 500f;

        float expectedFillAmount = healthValue / maxValue;

        healthUI.DisplayHealthUsingScale(healthValue, maxValue);

        LogAssert.Expect(LogType.Log, "Current boss health bar fill amount: " + expectedFillAmount);
    }
    [Test]
    public void BossIsSpawnedAfterDefeatingAllWaves()
    {
        GameObject go = new GameObject();
        var enemyManager = go.AddComponent<EnemyManager>();
        enemyManager.enemyBoss = new GameObject();

        enemyManager.numberOfWaves = 1;

        enemyManager.SpawnEnemyWave();
        enemyManager.SpawnEnemyWave();

        LogAssert.Expect(LogType.Log, "Boss appeared!");

    }
    [Test]
    public void NextSceneIsLoadedWhenBossIsDefeated()
    {
        GameObject go = new GameObject();
        var enemyManager = go.AddComponent<EnemyManager>();
        enemyManager.enemyBoss = new GameObject();

        enemyManager.numberOfWaves = 1;

        enemyManager.SpawnEnemyWave();
        enemyManager.SpawnEnemyWave();

        LogAssert.Expect(LogType.Log, "Boss appeared!");

        enemyManager.SpawnEnemyWave();

        LogAssert.Expect(LogType.Log, "Level cleared!");

    }
    [Test]
    public void ShieldCountIsSaved()
    {
        GameObject go = new GameObject();
        var playerInventory = go.AddComponent<PlayerInventory>();

        playerInventory.AddShield(10f);
        playerInventory.AddShield(10f);

        int expectedAmountOfShield = 2;

        Assert.AreEqual(PlayerPrefs.GetInt("ShieldCount"), expectedAmountOfShield);
    }
    [Test]
    public void ShieldCountIsDeductedOnUse()
    {
        GameObject go = new GameObject();
        var playerInventory = go.AddComponent<PlayerInventory>();
        go.AddComponent<HealthScript>();

        playerInventory.AddShield(10f);
        playerInventory.AddShield(10f);

        playerInventory.UseShield();

        int expectedAmountOfShield = 2 - 1;

        Assert.AreEqual(PlayerPrefs.GetInt("ShieldCount"), expectedAmountOfShield);
    }
    [Test]
    public void SpawningBossWorking()
    {
        GameObject go = new GameObject();
        var enemyManager = go.AddComponent<EnemyManager>();
        enemyManager.enemyBoss = new GameObject();

        enemyManager.SpawnBoss();

        LogAssert.Expect(LogType.Log, "Spawning boss!");

    }
    [Test]
    public void CannotApplyDamageWhenInvulnerable()
    {
        GameObject go = new GameObject();
        GameObject child = new GameObject();
        child.transform.parent = go.transform;
        child.AddComponent<CharacterAnimation>();
        var healthScript = go.AddComponent<HealthScript>();

        healthScript.invulnerable = true;
        healthScript.maxHealth = 200f;
        healthScript.health = healthScript.maxHealth;

        healthScript.ApplyDamage(100f, false);

        float expectedHealth = 200f;
        Assert.AreEqual(healthScript.health, expectedHealth);
    }
    [Test]
    public void CanAddHealthWhenNotInvulnerable()
    {
        GameObject go = new GameObject();
        GameObject child = new GameObject();
        child.transform.parent = go.transform;
        child.AddComponent<CharacterAnimation>();
        var healthScript = go.AddComponent<HealthScript>();

        healthScript.invulnerable = false;
        healthScript.maxHealth = 200f;
        healthScript.health = 150f;

        healthScript.AddHealth(100f);

        float expectedHealth = 150f + 100f;
        if (expectedHealth > healthScript.maxHealth)
        {
            expectedHealth = healthScript.maxHealth;
        }
        Assert.AreEqual(healthScript.health, expectedHealth);
    }
}
