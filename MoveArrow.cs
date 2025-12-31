using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;

    [SerializeField] private float offSet = 10.0f;
    public void OnEast_Button()
    {
        player.transform.DOMove(enemy.transform.position - new Vector3(offSet, 0, 0), 3f).SetEase(Ease.OutExpo);
    }
    public void OnSouth_Button()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(player.transform.DOMove())
    }
}
