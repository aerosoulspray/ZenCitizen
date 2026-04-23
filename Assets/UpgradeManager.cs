using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public GameManager gameManager;
    public int level = 1;

    public TextMeshProUGUI levelText; //Displays text for current level
    public TextMeshProUGUI amountToLevel; //Displays text for current amount to level up
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level: " + level;
        //Calculation shows the multiplier becoming a cube of the level
        //Math.Pow = first parameter is the number to raise to power of second parameter
        //In this case, the level is raised to the power of 3
        amountToLevel.text = "Level up Cost: " + (100 * Mathf.Pow(level * 1f, 3f));

    }

    public void Upgrade()
    {
        if (gameManager.totalCurrency >= (100 * Mathf.Pow(level * 1f,3f)))
        {
            gameManager.totalCurrency -= (100* Mathf.Pow(level * 1f, 3f));
            level++;
        }
        
    }
}
