using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class Enemy : MonoBehaviour
{
    [SerializeField]private SpriteRenderer enemyImage;
    [SerializeField]private TextMeshProUGUI enemyName;
    [SerializeField]private TextMeshProUGUI enemyHPText;

    private int enemyHP;
    private int enemyCurrHP;
    private int enemyPower;
    private int enemyDEF;
    private int enemySPD;
    public int EnemySPD => enemySPD;

    public EnemyData EData;

    void Start()
    {
        if (EData != null)
        {
            SetEnemy();
        }
    }

    public void SetEnemy()
    {
        enemyHP = EData.enemyHP;
        enemyCurrHP = enemyHP;
        enemyPower = EData.enemyPower;
        enemyDEF = EData.enemyDEF;
        enemySPD = EData.enemySPD;
        enemyName.text = EData.enemyName;
        enemyHPText.text = $"HP: {enemyCurrHP}/{enemyHP.ToString()}";
        enemyImage.sprite = EData.enemyImage;
    }

    public void TakeDamage(int damage)
    {
        enemyCurrHP -= damage;
        enemyHPText.text = $"HP: {enemyCurrHP}/{enemyHP.ToString()}";
    }
}
