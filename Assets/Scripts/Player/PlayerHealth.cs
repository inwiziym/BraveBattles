using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider; //��������� ���������� ��� �������� ��
    public int maxHealth; //��������� ���������� ��� ������������� ��
    public int currentHealth; //��������� ���������� ��� �������� ��
    public GameObject GoDie; //��������� ���������� ��� ����������� "���� ������"
    public Animator AttackEnemy; //�������� ����� �����

    public GameObject MainPlayer; //��������� ��������� ��� �������� go_player

    private bool isTakingDamage = false; //���� ��� ��������� �����

    void Start()
    {
        currentHealth = maxHealth; //������� �� ������������� �������������
        healthSlider.maxValue = maxHealth; //������� ����������� �� ������������ �� �������
        healthSlider.value = currentHealth; //������� �� ������������ �� �������
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
