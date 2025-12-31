using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public enum BattleState
    {
        Start, PlayerTurn, EnemyTurn, Won, Lost, Busy
    }
    public BattleState battleState;

    [SerializeField]private Player player;
    [SerializeField]private Enemy enemy;

    void Start()
    {
        StartSetUp();
    }

void StartSetUp()
    {
        if (player.playerSPD > enemy.enemySPD)
        {
            battleState = BattleState.PlayerTurn;
        }
        else
        {
            battleState = BattleState.EnemyTurn;
            EnemyAttack();
        }
    }

    void OnDamage(int damage)
    {
        enemy.TakeDamage(damage);
    }

    void EonDamage(int damage)
    {
        player.TakeDamage(damage);
    }

    public void OnAttack_Button()
    {
        switch (battleState)
        {
            case BattleState.PlayerTurn:
                {
                    battleState = BattleState.Busy;

                    player.PlayerAction(
                        targetPos: enemy.transform.position,
                        onHit: () =>
                        {
                            OnDamage(player.playerPower);
                        },
                        onFinished: () =>
                        {
                            battleState = BattleState.EnemyTurn;
                            EnemyAttack();
                        });
                }break;
            default:
                {
                    Debug.Log("아직 턴이 아닙니다.");   // 나중에 UI 추가 예정
                }break;
        }
    }

    void EnemyAttack()
    {
        switch (battleState)
        {
            case BattleState.EnemyTurn:
                {
                    enemy.EnemyAction(
                        targetPos: player.transform.position,
                        onHit: () =>
                        {
                            EonDamage(enemy.enemyPower);
                        },
                        onFinished: () =>
                        {
                            battleState = BattleState.PlayerTurn;
                        });
                }
                break;
        }
    }
}
    
