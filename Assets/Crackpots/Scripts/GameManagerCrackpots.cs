using System.Collections.Generic;
using Minigames.SecondGame;
using TMPro;
using UnityEngine;

public class GameManagerCrackpots : MonoBehaviour
{
    [SerializeField] private TMP_Text ratLeftCounter;
    [SerializeField] private List<Mole> moles;
    [SerializeField] private GameObject checker;
    [SerializeField] private CrackPotsWindow window;
    // Global variables
    private HashSet<Mole> currentMoles = new HashSet<Mole>();
    private int score;
    private bool playing = false;
    private int TotalLeft = 5;

    // This is public so the play button can see it.
    public void Start()
    {
        // Hide all the visible moles.
        for (int i = 0; i < moles.Count; i++)
        {
            moles[i].Hide();
            moles[i].SetIndex(i);
        }

        // Remove any old game state.
        currentMoles.Clear();
        score = 0;
        playing = true;
        RefreshText();
        checker.SetActive(false);
    }

    private void RefreshText()
    {
        ratLeftCounter.text = (TotalLeft - score).ToString();
    }

    public void GameOver()
    {
        // Hide all moles.
        foreach (Mole mole in moles)
        {
            mole.StopGame();
        }

        // Stop the game and show the start UI.
        playing = false;

        checker.SetActive(true);
        window.InternalClose();
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            // Check if we need to start any more moles.
            if (currentMoles.Count <= (Mathf.Abs(score / 10)))
            {
                // Choose a random mole.
                int index = Random.Range(0, moles.Count);
                // Doesn't matter if it's already doing something, we'll just try again next frame.
                if (!currentMoles.Contains(moles[index]))
                {
                    currentMoles.Add(moles[index]);
                    moles[index].Activate(score / 1);
                }
            }
        }
    }

    public void AddScore(int moleIndex)
    {
        // Add and update score.
        score += 1;
        // Remove from active moles.
        currentMoles.Remove(moles[moleIndex]);
        RefreshText();
        if(score >= TotalLeft)
        {
            GameOver();
        }
    }

    public void Missed(int moleIndex, bool isMole)
    {
        if (isMole)
        {
            // Decrease time by a little bit.
            score -= 1;
            RefreshText();
        }

        // Remove from active moles.
        currentMoles.Remove(moles[moleIndex]);
    }

    public void BombActivated()
    {
        score -= 10;
        RefreshText();
    }
}