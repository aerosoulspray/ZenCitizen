 using UnityEngine;

public class ResidentScript : MonoBehaviour
{
    public float currencyToEarn = 10f; // Amount of currency the resident will earn per day
    public float interval = 1.5f; // Time interval in seconds for earning currency
    public float currentCurrency = 0f; // Current amount of currency the resident has earned

    public float timeCounter = 0f; // Counter to track time for earning currency

    public GameManager gameManager; // Reference to the GameManager script

    public SpriteRenderer sprite;
    public GameObject crown;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        crown.SetActive(false);
        int rarity = Random.Range(1,20001);
        if (rarity>=1 && rarity <=2000)
        {
            crown.SetActive(true);
        }
        sprite.color = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f, 1f),1f);
        gameManager = FindObjectOfType<GameManager>(); // Find the GameManager script in the scene
    
    }

    // Update is called once per frame
    void Update()
    {
        
        timeCounter+= Time.deltaTime; // Increment the time counter by the time elapsed since the last frame
        //Debug.Log("Time Counter: " + timeCounter);

        if(timeCounter >= interval) // Check if the time counter has reached or exceeded the specified interval
        {
            currentCurrency += currencyToEarn; // Add the specified amount of currency to the current total
            gameManager.totalCurrency += currencyToEarn; // Add the earned currency to the total currency in the GameManager
            //Debug.Log("Current Currency: " + currentCurrency);
            timeCounter = 0f; // Reset the time counter to start counting for the next interval
        }

    }

    private void OnMouseDown()
    {
        gameManager.populationCounter--;
        Destroy(this.gameObject);
    }
}
