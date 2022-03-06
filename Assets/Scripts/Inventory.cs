using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Singleton class
    public int coinsCount;

    public static Inventory instance;
    public Text coinsCountText;

    // Awake metho : called whenever a gameObject with this script component is 'rendered'
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }
        instance = this;
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();

    }


    
}
