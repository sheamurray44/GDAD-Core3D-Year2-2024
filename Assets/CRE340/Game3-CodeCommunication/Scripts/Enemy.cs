using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public int health = 10;
    private Material mat;
    private Color originalColor;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalColor = mat.color;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        ShowHitEffect();

        if (health <= 0)
        {
            Die();
        }
    }

    public void ShowHitEffect()
    {
        mat.color = Color.red;
        Invoke("ResetMaterial", 0.1f);
    }

    private void ResetMaterial()
    {
        mat.color = originalColor;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
