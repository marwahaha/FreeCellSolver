using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solver : MonoBehaviour
{
    public GameObject slot1;
    private FreeCell freeCell;
    private UserInput userInput;
    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = FreeCell.GenerateDeck();
        freeCell = FindObjectOfType<FreeCell>();
        userInput = FindObjectOfType<UserInput>();
        
        foreach(string card in deck)
            print(card);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
