using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JustCurcleTimer : MonoBehaviour
{
    public float time;
    public float Max;
    public Image Fill;
    public GameObject GoWin;

    private void FixedUpdate()
    {
        time -= Time.deltaTime;
        Fill.fillAmount = time / Max;
        if (time < 0)
        {
            time = 0;
            Time.timeScale = 0; //Время паузы
            GoWin.SetActive(true);
        }
    }
}
