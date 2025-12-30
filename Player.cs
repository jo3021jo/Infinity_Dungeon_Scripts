using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI HpText;
    [SerializeField] private SpriteRenderer playerImage;
    [SerializeField] private float AttackOffset = 2.0f;
    public int playerHP { get; private set; }
    private int currentHP;
    public int playerPower { get; private set; }
    public int playerDEF { get; private set; }
    public int playerSPD { get; private set; }


    void Start()
    {
        playerHP = 20;
        playerPower = 10;
        playerDEF = 10;
        playerSPD = 10;
        SetUp();
    }

    void SetUp()
    {
        currentHP = playerHP;
        HPUpdate();
    }

    public void PlayerAction(Vector3 targetPos, Action onHit, Action onFinished)
    {
        Vector3 startPos = transform.position;
        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOMove(targetPos - new Vector3(AttackOffset, 0, 0), 1f).SetEase(Ease.OutExpo));
        seq.AppendCallback(() =>
        {
            onHit?.Invoke();
        });
        seq.AppendInterval(1f);
        seq.Append(transform.DOMove(startPos, 1f).SetEase(Ease.OutExpo));
        seq.OnComplete(() =>
        {
            onFinished?.Invoke();
        });
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        HPUpdate();
    }

    void HPUpdate()
    {
        HpText.text = $"Hp : {currentHP}/{playerHP}";
    }
}
