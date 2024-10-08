using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingCrate : MonoBehaviour, IDamageable
{
    public int health = 10;
    public GameObject explosionEffectPrefab;
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
            Explode();
            Destroy(gameObject);
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

    private void Explode()
    {
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
