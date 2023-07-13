using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IDieble, IResatable
{
    public static UnityEvent EnemyDiedEvent = new UnityEvent();

    [SerializeField] private float health;
    [SerializeField] private Animator animator;

    private HpUI hpUI;

    private Rigidbody rb;

    private float currentHealth;

    public bool isDead { get; private set; }

    private Vector3 startPos;
    private Quaternion startRot;

    private void Awake()
    {
        hpUI = GetComponent<HpUI>();

        rb = GetComponent<Rigidbody>();

        currentHealth = health;

        UpdateHpUI();
    }

    private void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    public void Damage(float damageAmount)
    {
        if (!isDead)
        {
            currentHealth -= damageAmount;
            if (currentHealth <= 0) Die();

            UpdateHpUI();
        }
    }

    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            EnemyDiedEvent?.Invoke();

            animator.enabled = false;
        }
    }

    public void ResetAll()
    {
        rb.isKinematic = true;

        isDead = false;
        animator.enabled = true;

        transform.position = startPos;
        transform.rotation = startRot;

        rb.isKinematic = false;

        currentHealth = health;
        UpdateHpUI();
    }

    private void UpdateHpUI()
    {
        hpUI.SetHpValue(currentHealth / health);
    }
}