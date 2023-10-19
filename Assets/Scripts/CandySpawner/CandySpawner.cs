using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] private GameObject candyPrefab;
    float timeBeforeSpawn = 0;
    int maxCandies = 15;

    [SerializeField] private TMP_Text candyRemaining;

    [SerializeField] private Sprite commonCandy;
    [SerializeField] private Sprite rareCandy;
    [SerializeField] private Sprite specialCandy;
    [SerializeField] private Sprite epicCandy;
    [SerializeField] private Sprite legendCandy;
    [SerializeField] private Sprite godCandy;

    // Start is called before the first frame update
    void Start()
    {
        candyRemaining.text = "Candy Left: " + maxCandies;
        timeBeforeSpawn = Random.Range(1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        timeBeforeSpawn -= Time.deltaTime;
        if (timeBeforeSpawn < 0)
        {
            if (maxCandies > 0)
            {
                maxCandies--;
                spawnCandy();
            }
            else
            {
                gameEnded();
            }
            timeBeforeSpawn = Random.Range(1f, 3f);
        }
    }


    public void spawnCandy()
    {
        candyRemaining.text = "Candy Left: " + maxCandies;
        Vector3 candySpawn = new Vector3((Random.Range(-8, 8)), 4, 0);
        GameObject newCandy = Instantiate(candyPrefab, candySpawn, Quaternion.identity);
        int randomChance = Random.Range(1, 100);
        if (randomChance < 60)
        {
            newCandy.GetComponent<SpriteRenderer>().sprite = rareCandy;
            newCandy.GetComponent<CandyCollectable>().setCandyValue(2);

            if(randomChance < 40)
            {
                newCandy.GetComponent<SpriteRenderer>().sprite = specialCandy;
                newCandy.GetComponent<CandyCollectable>().setCandyValue(3);

                if (randomChance < 30)
                {
                    newCandy.GetComponent<SpriteRenderer>().sprite = epicCandy;
                    newCandy.GetComponent<CandyCollectable>().setCandyValue(5);

                    if (randomChance < 20)
                    {
                        newCandy.GetComponent<SpriteRenderer>().sprite = legendCandy;
                        newCandy.GetComponent<CandyCollectable>().setCandyValue(10);

                        if (randomChance < 10)
                        {
                            newCandy.GetComponent<SpriteRenderer>().sprite = godCandy;
                            newCandy.GetComponent<CandyCollectable>().setCandyValue(20);

                        }
                    }
                }

            }

        }

        Destroy(newCandy.gameObject, 4);
    }


    [SerializeField] private TMP_Text finalScore;



    public void gameEnded()
    {
        finalScore.color = Color.HSVToRGB(231f, 255f, 90f);




    }

}
