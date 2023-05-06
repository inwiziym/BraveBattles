using UnityEngine;
using UnityEngine.UI;

public class CoinGrears : MonoBehaviour
{
    public Text coinText;
    public int ñoinGrears;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GrearsPlayer"))
        {
            ñoinGrears++;
            coinText.text = ñoinGrears.ToString();
            Destroy(collision.gameObject);
        }
        if (coinText != null)
        {
            coinText.text = ñoinGrears.ToString();
        }
    }
}
