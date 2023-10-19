using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CandyCollectable : MonoBehaviour
{
    int candyValue = 1;
    [SerializeField] private Player myPlayer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            myPlayer.gotCandy(candyValue);
            Destroy(gameObject);
        }

        if (other.transform.tag == "Ground")
        {
            Destroy(gameObject);
        }

        if (other.transform.tag == "Holder")
        {
            
        }

    }

    public void setCandyValue(int newCandyValue)
    {
        candyValue = newCandyValue;
    }

}
