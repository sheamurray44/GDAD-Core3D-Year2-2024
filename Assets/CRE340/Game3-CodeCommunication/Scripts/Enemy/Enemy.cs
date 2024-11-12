using UnityEngine;
using DG.Tweening;
public class Enemy : EnemyBase
{
    public EnemyData enemyData;
    [SerializeField] private int damage = 10;
    [SerializeField] private int health = 10;
    public float speed = 2f;
    public float chaseRange = 5f;
    private IEnemyState currentState;
    [HideInInspector]
    public Transform target;
    public GameObject dieEffectPrefab;
    private void Awake()
    {
        gameObject.name = enemyData.enemyName;
        health = enemyData.health;
        damage = enemyData.damage;
        speed = enemyData.speed;
        chaseRange = enemyData.chaseRange;
        GetComponent<Renderer>().material.color = enemyData.enemyColor;
    }
    private void Start()
    {
        SetState(new EnemyState_Idle());
        Invoke("LocatePlayer", 1f);
        LocatePlayer();
    }

    private void OnEnable()
    {
        // Spawn animation: Scale from 0 to 1 over 1 second with DOTween
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);
    }

    private void Update()
    {
        currentState?.Update(this);
    }

    public void SetState(IEnemyState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState?.Enter(this);
    }

    public string GetCurrentStateName()
    {
        return currentState != null ? currentState.GetType().Name.Replace("Enemy", "") : "No State";
    }


    public override void TakeDamage(int damage)
    {
        health -= damage;
        // Trigger damage event and inherited hit effect
        HealthEventManager.OnObjectDamaged?.Invoke(gameObject.name, health);
        ShowHitEffect(); // Inherited from EnemyBase
        if (health <= 0)
        {
            Die();
            HealthEventManager.OnObjectDestroyed?.Invoke(gameObject.name, health);
        }
    }
    protected override void Die()
    {
        // Play death effect and sound
        if (dieEffectPrefab != null)
        {
            Instantiate(dieEffectPrefab, transform.position, Quaternion.identity);
        }
        //AudioEventManager.PlaySFX(null, "Explosion Flesh", 1.0f, 1.0f, true, 0.1f, 0f);
        Destroy(gameObject);
        Debug.Log("Enemy has died");
        // Update score based on enemy health
        GameManager.Instance.AddScore(10 * enemyData.health);
    }
    public override void Move()
    {
        // Define movement specific to this enemy, if needed
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Apply damage to other objects implementing IDamagable
        IDamagable damagableObject = collision.gameObject.GetComponent<IDamagable>();
        if (damagableObject != null && collision.gameObject.tag != "Enemy")
        {
            damagableObject.TakeDamage(damage);
            Debug.Log($"{gameObject.name} dealt {damage} damage to {collision.gameObject.name}.");
        }
    }
    private void LocatePlayer()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
