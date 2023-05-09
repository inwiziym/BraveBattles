using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider; //Публичная переменная для слайдера ХП
    public int maxHealth; //Публичаня переменная для максимального ХП
    public int currentHealth; //Публичная переменная для текущего ХП
    public GameObject GoDie; //Публияная переменная для отображения "окна смерти"
    public Animator AttackEnemy; //Анимация Атаки Врага

    public GameObject MainPlayer; //Публичная переменая для указания go_player

    private bool isTakingDamage = false; //Флаг для получения урона

    void Start()
    {
        currentHealth = maxHealth; //Текущее ХП соответствует максимальному
        healthSlider.maxValue = maxHealth; //Текущее масимальное ХП отображается на слайдер
        healthSlider.value = currentHealth; //Текущее ХП отображается на слайдер
    }

    public void OnTriggerEnter2D(Collider2D damageenemy)
    {
        if((damageenemy.CompareTag("EnemyAttackEasy") || (damageenemy.CompareTag("EnemyTriangle"))) && !isTakingDamage)
        {
            isTakingDamage = true;
            currentHealth--;
            healthSlider.value = currentHealth;
            StartCoroutine(ResetTakingDamageFlag());
            if (currentHealth <= 0)
            {
                GoDie.SetActive(true);
                Destroy(MainPlayer);
            }
        }
        if ((damageenemy.CompareTag("EnemyEasyBullet")) && !isTakingDamage)
        {
            isTakingDamage = true;
            currentHealth --;
            currentHealth --;
            healthSlider.value = currentHealth;
            StartCoroutine(ResetTakingDamageFlag());
            if (currentHealth <= 0)
            {
                GoDie.SetActive(true);
                Destroy(MainPlayer);
            }
        }

        if (damageenemy.CompareTag("HELL") && !isTakingDamage)
        {
            isTakingDamage = true;
            currentHealth-= maxHealth;
            healthSlider.value = currentHealth;
            if (currentHealth <= 0)
            {
                GoDie.SetActive(true);
                Destroy(MainPlayer);
            }
        }
    }

    IEnumerator ResetTakingDamageFlag()
    {
        yield return new WaitForSeconds(0.1f);
        isTakingDamage = false;
    }
}
