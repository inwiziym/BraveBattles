using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarEasy : MonoBehaviour
{
    public Slider healthSlider;
    public Transform enemyTransform;
    public Vector3 offset;
    public int maxHealth;
    public int currentHealth;

    void Awake()
    {
        SetMaxHealth(maxHealth);
        SetHealth(currentHealth);
    }

    void Start()
    {
        SetHealthSliderPosition();
    }

    void Update()
    {
        SetHealthSliderPosition();
    }

    void SetHealthSliderPosition()
    {
        healthSlider.transform.position = Camera.main.WorldToScreenPoint(enemyTransform.position + offset);
    }

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
        healthSlider.value = health;
        if (health <= 0)
        {
            Die();
        }
    }

    public void OnTriggerEnter2D(Collider2D damageplayer)
    {
        if (damageplayer.CompareTag("Attackshayrmech"))
        {
            currentHealth -= 1;
            SetHealth(currentHealth);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}