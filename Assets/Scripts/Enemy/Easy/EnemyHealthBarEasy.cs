using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealthBarEasy : MonoBehaviour
{
    public Slider healthSlider;
    public Transform enemyTransform;
    public Vector3 offset;
    public int maxHealth;
    public int currentHealth;
    private bool isTakingDamage = false;
    public GameObject grearsPlayer;

    private bool hasDroppedCoin = false; // Флаг, который показывает, выпала ли монета

    void Start()
    {
        SetMaxHealth(maxHealth);
        SetHealth(currentHealth);
        SetHealthSliderPosition();
    }

    void FixedUpdate()
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
            if (!hasDroppedCoin) // Проверяем, выпала ли монета
            {
                Instantiate(grearsPlayer, transform.position, Quaternion.identity, null);
                hasDroppedCoin = true; // Устанавливаем флаг, что монета выпала
            }
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D damageplayer)
    {
        if ((damageplayer.CompareTag("Attackshayrmech") || (damageplayer.CompareTag("EnemyTriangle"))) && !isTakingDamage)
        {
            isTakingDamage = true;
            currentHealth--;
            SetHealth(currentHealth);
        }
        StartCoroutine(ResetTakingDamageFlag());

        if (damageplayer.CompareTag("HELL"))
        {
            currentHealth -= maxHealth;
            SetHealth(currentHealth);
        }
    }

    IEnumerator ResetTakingDamageFlag()
    {
        yield return new WaitForSeconds(0.1f);
        isTakingDamage = false;
    }
}