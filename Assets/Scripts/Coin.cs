using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] CoinController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = FindFirstObjectByType<CoinController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            controller.AddCoin();
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        this.transform.Rotate(0, 1, 0);
    }
}
