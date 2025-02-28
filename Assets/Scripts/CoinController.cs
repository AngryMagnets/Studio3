using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    private int coins = 0;
  
    public void AddCoin ()
    {
        coins++;
        coinText.text = "Coins: " + coins;
    }
}
