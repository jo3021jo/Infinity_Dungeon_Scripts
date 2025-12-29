using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public enum BattleState
    {
        Start, PlayerTurn, EnemyTurn, Won, Lost
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
        if (player.playerSPD > enemy.EnemySPD)
        {
            battleState = BattleState.PlayerTurn;
        }
        else if (player.playerSPD == enemy.EnemySPD)
        {
            battleState = BattleState.EnemyTurn;
        }
        else
        {
            battleState = BattleState.EnemyTurn;
        }
    }

    public void OnAttack_Button()
    {
        switch (battleState)
        {
            case BattleState.PlayerTurn:
                {
                    player.PlayerAction(
                        onHit: () =>
                        {
                            OnDamage(player.playerPower);
                        },
                        onFinished: () =>
                        {
                            battleState = BattleState.EnemyTurn;
                        });
                }break;
            default:
                {
                    Debug.Log("아직 턴이 아닙니다.");   // 나중에 UI 추가 예정
                }break;
        }
    }

    void OnDamage(int damage)
    {
        switch (battleState)
        {
            case BattleState.PlayerTurn:
                {
                    enemy.TakeDamage(damage);
                }
                break;
            case BattleState.EnemyTurn:
                {

                }
                break;
        }
    }

    void EnemyAttack()
    {
        switch (battleState)
        {
            case BattleState.EnemyTurn:
                {

                }
                break;
        }
    }
}
    
