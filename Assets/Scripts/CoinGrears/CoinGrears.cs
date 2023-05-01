using UnityEngine;
using UnityEngine.UI;

public class CoinGrears : MonoBehaviour
{
    public Text text;
    public int money;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GrearsPlayer"))
        {
            Destroy(collision.gameObject);
            money++;
            text.text = money.ToString();
        }
        if (text != null)
        {
            text.text = money.ToString();
        }
    }
}
