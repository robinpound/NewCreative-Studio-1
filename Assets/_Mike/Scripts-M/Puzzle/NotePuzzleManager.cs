using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Created by Michael
// Validator Refactored by Robin
public class NotePuzzleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] noteBlocksInPuzzle; // How many note blocks in puzzle.
    private List<int> noteBlockPlayOrder = new List<int>(); // How many notes have been played in game.

    private int orderCheckSuccess = 0; // How many notes have been played in order.

    private void Update()
    {    
        // Check if all note blocks have been played
        if (noteBlocksInPuzzle.Length == noteBlockPlayOrder.Count)
        {
            Debug.Log("All notes have been played");
            ValidateOrderOfNotesPlayed();
        }

        Debug.Log("@@@ List of added notes played " + noteBlockPlayOrder.Count);

        //Debug.Log("how many notes in order " + check);


        if (orderCheckSuccess == 3) Debug.Log("PUZZLE SOLVED");
        
       
    }

    public void NoteBlockSoundHasPlayed(int noteId)
    {
        noteBlockPlayOrder.Add(noteId);
        //Debug.Log(noteId + "has been added to the list");
    }

    private void ValidateOrderOfNotesPlayed()
    {
        for (int i = 0; i < noteBlockPlayOrder.Count; i++) 
        {
            if (noteBlockPlayOrder[i] != i+1)
            {
                noteBlockPlayOrder.Clear();
                return;
            } 
            else { orderCheckSuccess++;}
        }
    }
}