using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using DG.Tweening;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float AttackOffset = 2.0f;
    [SerializeField]private SpriteRenderer enemyImage;
    [SerializeField]private TextMeshProUGUI enemyName;
    [SerializeField]private TextMeshProUGUI enemyHPText;

    public int enemyHP { get; private set; }
    public int enemyCurrHP { get; private set; }
    public int enemyPower { get; private set; }
    public int enemyDEF { get; private set; }
    public int enemySPD { get; private set; }

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
        HPUpdate();
        enemyImage.sprite = EData.enemyImage;
    }

    public void TakeDamage(int damage)
    {
        enemyCurrHP -= damage;
        HPUpdate();


    }

    void HPUpdate()
    {
        enemyHPText.text = $"HP: {enemyCurrHP}/{enemyHP}";
    }

    public void EnemyAction(Vector3 targetPos, Action onHit, Action onFinished)
    {
        Vector3 EstartPos = transform.position;

        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOMove(targetPos + new Vector3(AttackOffset, 0, 0), 1f).SetEase(Ease.OutExpo));
        seq.AppendCallback(() =>
        {
            onHit?.Invoke();
        });
        seq.AppendInterval(1f);
        seq.Append(transform.DOMove(EstartPos, 1f).SetEase(Ease.OutExpo));
        seq.OnComplete(() =>
        {
            onFinished?.Invoke();
        });
    }
}
