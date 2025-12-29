using UnityEngine;

[CreateAssetMenu(fileName = "New_Char", menuName =" RPG/Enemy")]
public class EnemyData : ScriptableObject
{
    [Header("몬스터 정보")]
    public string enemyName;
    public Sprite enemyImage;

    public int enemyHP;
    public int enemyPower;
    public int enemyDEF;
    public int enemySPD;
}