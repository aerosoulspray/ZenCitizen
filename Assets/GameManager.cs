using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    float counter2 = 0;
    public float totalCurrency = 0f; // Total currency earned by all residents

    public GameObject[] residents; // Array to hold references to resident GameObjects


    public TextMeshProUGUI taxText;
    public TextMeshProUGUI populationCount;

    public int populationCounter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       SpawnRandomResident();
    }

    // Update is called once per frame
    void Update()
    {
        counter2+= Time.deltaTime;
        if (counter2 >= 0.5f)
        {
            SpawnRandomResident();
            counter2=0;
        }

        taxText.text= "Tax Collected: " + totalCurrency;
        populationCount.text = "Population Count: " + populationCounter;

    }

    public void SpawnResident(int index)
    {
        populationCounter++;
        Instantiate(residents[index], new Vector3(Random.Range(-7.10f,7.10f), Random.Range(-4.01f, 4.01f), 0), Quaternion.identity); // Spawn the first resident at the specified position
    }

    public void SpawnRandomResident()
    {
        populationCounter++;
        int random = Random.Range(0,residents.Length);
        Debug.Log(random);
        Instantiate(residents[random], new Vector3(Random.Range(-7.10f,7.10f), Random.Range(-4.01f, 4.01f), 0), Quaternion.identity); // Spawn the first resident at the specified position
    }
}
