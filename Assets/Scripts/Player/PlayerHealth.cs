using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    public int startingHealth;
    public int currentHealth;
    public GameObject GoDie;
    public Animator AttackEnemy;

    public GameObject MainPlayer;

    private bool isTakingDamage = false;

    void Start()
    {
        currentHealth = startingHealth;
        healthSlider.maxValue = startingHealth;
        healthSlider.value = currentHealth;
    }

    public void OnTriggerEnter2D(Collider2D damageenemy)
    {
        if (damageenemy.CompareTag("EnemyAttack") && !isTakingDamage)
        {
            isTakingDamage = true;
            currentHealth--;
            healthSlider.value = currentHealth;
            if (currentHealth <= 0)
            {
                GoDie.SetActive(true);
                Destroy(MainPlayer);
            }
            StartCoroutine(ResetTakingDamageFlag());
        }
    }

    IEnumerator ResetTakingDamageFlag()
    {
        yield return new WaitForSeconds(0.7f); // Change the time according to your needs
        isTakingDamage = false;
    }
}
