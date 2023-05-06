using UnityEngine;
using UnityEngine.UI;

public class CoinGrears : MonoBehaviour
{
    public Text coinText;
    public int �oinGrears;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GrearsPlayer"))
        {
            �oinGrears++;
            coinText.text = �oinGrears.ToString();
            Destroy(collision.gameObject);
        }
        if (coinText != null)
        {
            coinText.text = �oinGrears.ToString();
        }
    }
}
