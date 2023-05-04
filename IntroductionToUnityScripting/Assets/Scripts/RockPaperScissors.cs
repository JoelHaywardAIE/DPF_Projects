using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Random = UnityEngine.Random;

public class RockPaperScissors : MonoBehaviour
{
    private int playerLives;
    private int enemyLives;
    private int playerChoice;
    private int enemyChoice;

    [Header("Text Objects")]
    public TMP_Text gameOutputText;
    public TMP_Text playerLifeCounter;
    public TMP_Text enemyLifeCounter;

    [Header("Button Objects")]
    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;
    public Button restartButton;

    private bool gameRestarting = false;

    // Start is called before the first frame update
    void Start()
    {
        SetUpGame();
    }

    private void SetUpGame()
    {
        playerLives = 3;
        enemyLives = 3;
        gameRestarting = false;

        //Change text of the output text box
        gameOutputText.text = "Make a choice human! Rock, Paper, or Scissors?!";

        UpdateUI();
    }

    public void SelectHand(int buttonClicked)
    {
        gameRestarting = false;

        if (buttonClicked == 1)
        {
            gameOutputText.text = "You chose Rock...";
            playerChoice = 1;
            DoBattle();
        }
        else if (buttonClicked == 2)
        {
            gameOutputText.text = "You chose Paper...";
            playerChoice = 2;
            DoBattle();
        }
        else if (buttonClicked == 3)
        {
            gameOutputText.text = "You chose Scissors...";
            playerChoice = 3;
            DoBattle();
        }
    }

    private void DoBattle()
    {
        //generate enemy's random choice
        enemyChoice = Random.Range(1, 3);

        //compare hands
        if(playerChoice == enemyChoice)
        {
            gameOutputText.text = "It's a draw! Boring!!";
        }
        else if(playerChoice == 1 && enemyChoice == 2)
        {
            gameOutputText.text = "Lol what a loser!!";
            playerLives--;
        }
        else if (playerChoice == 1 && enemyChoice == 3)
        {
            gameOutputText.text = "What how did you know?!?!";
            enemyLives--;
        }
        else if (playerChoice == 2 && enemyChoice == 1)
        {
            gameOutputText.text = "What how did you know?!?!";
            enemyLives--;
        }
        else if (playerChoice == 2 && enemyChoice == 3)
        {
            gameOutputText.text = "Lol what a loser!!";
            playerLives--;
        }
        else if (playerChoice == 3 && enemyChoice == 1)
        {
            gameOutputText.text = "Lol what a loser!!";
            playerLives--;
        }
        else if (playerChoice == 3 && enemyChoice == 2)
        {
            gameOutputText.text = "What how did you know?!?!";
            enemyLives--;
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        playerLifeCounter.text = playerLives.ToString();
        enemyLifeCounter.text = enemyLives.ToString();

        CheckForWinner();
    }

    private void CheckForWinner()
    {
        if (playerLives <= 0)
        {
            gameOutputText.text = "Game Over! You lose!";

            rockButton.gameObject.SetActive(false);
            paperButton.gameObject.SetActive(false);
            scissorsButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);

        }
        else if (enemyLives <= 0)
        {
            gameOutputText.text = "Dammit, you the champ!";

            rockButton.gameObject.SetActive(false);
            paperButton.gameObject.SetActive(false);
            scissorsButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
        }
    }
    public void RestartGame()
    {
        gameRestarting = true;
        SetUpGame();
        rockButton.gameObject.SetActive(true);
        paperButton.gameObject.SetActive(true);
        scissorsButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
    }
}
