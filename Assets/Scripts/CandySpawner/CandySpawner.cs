using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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

        if(maxCandies == 0)
        {
            gameEnded();
        }
    }


    [SerializeField] private TMP_Text finalScore;
    [SerializeField] private Player myPlayer;
    [SerializeField] private UnityEngine.UI.Button resetButton;

    public void gameEnded()
    {
        finalScore.transform.Translate(new Vector3(0,6,0));
        int playerScore = myPlayer.getScore();

        if (playerScore >= 0)
        {
            finalScore.text = "Final Score Results:\nNot Enough Sugar!";

            if (playerScore > 15)
            {
                finalScore.text = "Final Score Results:\nSugar Rush!";

                if (playerScore > 35)
                {
                    finalScore.text = "Final Score Results:\nHalloween Mayham!";

                    if (playerScore > 50)
                    {
                        finalScore.text = "Final Score Results:\nCandy Craze!";

                    }
                }
            }

        }

        Vector3 buttonPos = new Vector3(0,10,0);
        resetButton.transform.Translate(buttonPos);

    }

    public void onButtonReset()
    {
        maxCandies = 15;
        candyRemaining.text = "Candy Left: " + maxCandies;
        timeBeforeSpawn = Random.Range(3f, 5f);
        myPlayer.setScore(0);

        Vector3 buttonPos = new Vector3(0, -800, 0);
        resetButton.transform.Translate(buttonPos);

        finalScore.transform.Translate(new Vector3(0, -1000, 0));
    }

}
