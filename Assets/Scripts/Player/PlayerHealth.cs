using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    public int startingHealth;
    public int currentHealth;
    public GameObject GoDie;
    public Animator AttackEnemy;


    void Start()
    {
        currentHealth = startingHealth;
        healthSlider.maxValue = startingHealth;
        healthSlider.value = currentHealth;
    }

    public void OnTriggerEnter2D(Collider2D damageenemy)
    {
        if (damageenemy.CompareTag("EnemyAttack"))
        {
            currentHealth--;
            healthSlider.value = currentHealth;
            if (currentHealth <= 0)
            {
                GoDie.SetActive(true);
            }
        }
    }
}
