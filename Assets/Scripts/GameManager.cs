using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Deck deck;
    void Start()
    {
        deck.NewRun();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
