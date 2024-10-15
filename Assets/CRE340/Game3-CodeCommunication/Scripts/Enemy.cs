
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public EnemyData enemyData;
    public int health = 10;
    private Material mat;
    private Color originalColor;

    private void Awake()
    {
        gameObject.name = enemyData.enemyName;
        GetComponent<Renderer>().material.color = enemyData.enemyColor;

    }
    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalColor = mat.color;
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;

        // Trigger the OnObjectDamaged event
        HealthEventManager.OnObjectDamaged?.Invoke(gameObject.name, health);

        ShowHitEffect();

        if (health <= 0)
        {
            Die();

            // Trigger the OnObjectDestroyed event
            HealthEventManager.OnObjectDestroyed?.Invoke(gameObject.name, health);
        }
    }
    
    public void ShowHitEffect()
    {
        mat.color = Color.red;
        Invoke("ResetMaterial", 0.1f);
    }

    private void ResetMaterial(){
        mat.color = originalColor;
    }

    private void Die()
    {
        // Optional: add death logic, like spawning loot or playing an animation
        Destroy(gameObject);
        //debug log to show that the enemy has died
        Debug.Log("Enemy has died");
    }
}
