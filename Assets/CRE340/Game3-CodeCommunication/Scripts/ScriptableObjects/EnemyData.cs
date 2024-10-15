using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int health;
    public float speed;
    public Color enemyColor;
}
