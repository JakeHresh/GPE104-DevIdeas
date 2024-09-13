using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectFourManager : MonoBehaviour
{
    public enum PlayerTurn { playerOne, playerTwo}
    public PlayerTurn playerTurn = PlayerTurn.playerOne;

    private bool playerOneVictory = false;
    private bool playerTwoVictory = false;

    public KeyCode firstCol;
    public KeyCode secondCol;
    public KeyCode thirdCol;
    public KeyCode fourthCol;
    public KeyCode fifthCol;
    public KeyCode sixthCol;
    public KeyCode seventhCol;

    public GameObject tokenPrefab;
    public Token[,] tokenGrid = new Token[6, 7];
    public int rows;
    public int columns;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                GameObject spawnedToken = Instantiate(tokenPrefab, new Vector3(0.5f + j, 0.5f, -0.5f + i), Quaternion.identity) as GameObject;
                Token tokenComponent = spawnedToken.GetComponent<Token>();
                tokenComponent.tokenValue = Token.TokenType.noPlayer;
                tokenGrid[i, j] = tokenComponent;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPlayerOneVictory() && !IsPlayerTwoVictory() && !IsDraw())
        {
            if (Input.GetKeyDown(firstCol))
            {
                if (PlaceToken(1))
                {
                    Debug.Log("Player " + playerTurn + 1 + " placed a token! Changing players.");
                }
                else
                {
                    Debug.Log("Player " + playerTurn + 1 + " failed to place a token at that column! Try again.");
                }
            }
            else if (Input.GetKeyDown(secondCol))
            {
                if (PlaceToken(2))
                {
                    Debug.Log("Player " + playerTurn + 1 + " placed a token! Changing players.");
                }
                else
                {
                    Debug.Log("Player " + playerTurn + 1 + " failed to place a token at that column! Try again.");
                }
            }
            else if (Input.GetKeyDown(thirdCol))
            {
                if (PlaceToken(3))
                {
                    Debug.Log("Player " + playerTurn + 1 + " placed a token! Changing players.");
                }
                else
                {
                    Debug.Log("Player " + playerTurn + 1 + " failed to place a token at that column! Try again.");
                }
            }
            else if (Input.GetKeyDown(fourthCol))
            {
                if (PlaceToken(4))
                {
                    Debug.Log("Player " + playerTurn + 1 + " placed a token! Changing players.");
                }
                else
                {
                    Debug.Log("Player " + playerTurn + 1 + " failed to place a token at that column! Try again.");
                }
            }
            else if (Input.GetKeyDown(fifthCol))
            {
                if (PlaceToken(5))
                {
                    Debug.Log("Player " + playerTurn + 1 + " placed a token! Changing players.");
                }
                else
                {
                    Debug.Log("Player " + playerTurn + 1 + " failed to place a token at that column! Try again.");
                }
            }
            else if (Input.GetKeyDown(sixthCol))
            {
                if (PlaceToken(6))
                {
                    Debug.Log("Player " + playerTurn + 1 + " placed a token! Changing players.");
                }
                else
                {
                    Debug.Log("Player " + playerTurn + 1 + " failed to place a token at that column! Try again.");
                }
            }
            else if (Input.GetKeyDown(seventhCol))
            {
                if (PlaceToken(7))
                {
                    Debug.Log("Player " + playerTurn + 1 + " placed a token! Changing players.");
                }
                else
                {
                    Debug.Log("Player " + playerTurn + 1 + " failed to place a token at that column! Try again.");
                }
            }
        }
        else if (IsPlayerOneVictory())
        {
            Debug.Log("Player One Wins!");
        }
        else if (IsPlayerTwoVictory())
        {
            Debug.Log("Player Two Wins!");
        }
        else if (IsDraw())
        {
            Debug.Log("DRAW!");
        }
    }

    public bool PlaceToken(int columnSelection)
    {
        for (int i = 0; i < rows; i++)
        {
            if (tokenGrid[i, columnSelection - 1].tokenValue == Token.TokenType.noPlayer)
            {
                if (playerTurn == PlayerTurn.playerOne)
                {
                    tokenGrid[i, columnSelection - 1].tokenValue = Token.TokenType.playerOne;
                    playerTurn = PlayerTurn.playerTwo;
                }
                else
                {
                    tokenGrid[i, columnSelection - 1].tokenValue = Token.TokenType.playerTwo;
                    playerTurn = PlayerTurn.playerOne;
                }
                return true;
            }
        }
        return false;
    }

    public bool IsPlayerOneVictory()
    {
        // Horizontal check
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (tokenGrid[i, j].tokenValue == Token.TokenType.playerOne && tokenGrid[i, j + 1].tokenValue == Token.TokenType.playerOne && tokenGrid[i, j + 2].tokenValue == Token.TokenType.playerOne && tokenGrid[i, j + 3].tokenValue == Token.TokenType.playerOne)
                {
                    return true;
                }
            }
        }

        // Vertical check
        for (int j = 0; j < columns; j++)
        {
            for (int i = 0; i < 3; i++)
            {
                if (tokenGrid[i, j].tokenValue == Token.TokenType.playerOne && tokenGrid[i + 1, j].tokenValue == Token.TokenType.playerOne && tokenGrid[i + 2, j].tokenValue == Token.TokenType.playerOne && tokenGrid[i + 3, j].tokenValue == Token.TokenType.playerOne)
                {
                    return true;
                }
            }
        }

        // Right diagonal check
        if (tokenGrid[3, 0].tokenValue == Token.TokenType.playerOne && tokenGrid[2, 1].tokenValue == Token.TokenType.playerOne && tokenGrid[1, 2].tokenValue == Token.TokenType.playerOne && tokenGrid[0, 3].tokenValue == Token.TokenType.playerOne)
        {
            return true;
        }
        if (tokenGrid[5, 3].tokenValue == Token.TokenType.playerOne && tokenGrid[4, 4].tokenValue == Token.TokenType.playerOne && tokenGrid[3, 5].tokenValue == Token.TokenType.playerOne && tokenGrid[2, 6].tokenValue == Token.TokenType.playerOne)
        {
            return true;
        }
        for (int k = 0; k < 2; k++)
        {
            if (tokenGrid[4 - k, 0 + k].tokenValue == Token.TokenType.playerOne && tokenGrid[3 - k, 1 + k].tokenValue == Token.TokenType.playerOne && tokenGrid[2 - k, 2 + k].tokenValue == Token.TokenType.playerOne && tokenGrid[1 - k, 3 + k].tokenValue == Token.TokenType.playerOne)
            {
                return true;
            }
            if (tokenGrid[5 - k, 2 + k].tokenValue == Token.TokenType.playerOne && tokenGrid[4 - k, 3 + k].tokenValue == Token.TokenType.playerOne && tokenGrid[3 - k, 4 + k].tokenValue == Token.TokenType.playerOne && tokenGrid[2 - k, 5 + k].tokenValue == Token.TokenType.playerOne)
            {
                return true;
            }
        }
        for (int k = 0; k < 3; k++)
        {
            if (tokenGrid[5 - k, 0 + k].tokenValue == Token.TokenType.playerOne && tokenGrid[4 - k, 1 + k].tokenValue == Token.TokenType.playerOne && tokenGrid[3 - k, 2 + k].tokenValue == Token.TokenType.playerOne && tokenGrid[2 - k, 3 + k].tokenValue == Token.TokenType.playerOne)
            {
                return true;
            }
            if (tokenGrid[5 - k, 1 + k].tokenValue == Token.TokenType.playerOne && tokenGrid[4 - k, 2 + k].tokenValue == Token.TokenType.playerOne && tokenGrid[3 - k, 3 + k].tokenValue == Token.TokenType.playerOne && tokenGrid[2 - k, 4 + k].tokenValue == Token.TokenType.playerOne)
            {
                return true;
            }
        }

        // Left diagonal check (needs testing)
        if (tokenGrid[3, 6].tokenValue == Token.TokenType.playerOne && tokenGrid[2, 5].tokenValue == Token.TokenType.playerOne && tokenGrid[1, 4].tokenValue == Token.TokenType.playerOne && tokenGrid[0, 3].tokenValue == Token.TokenType.playerOne)
        {
            return true;
        }
        if (tokenGrid[5, 3].tokenValue == Token.TokenType.playerOne && tokenGrid[4, 2].tokenValue == Token.TokenType.playerOne && tokenGrid[3, 1].tokenValue == Token.TokenType.playerOne && tokenGrid[2, 0].tokenValue == Token.TokenType.playerOne)
        {
            return true;
        }
        for (int k = 0; k < 2; k++)
        {
            if (tokenGrid[4 - k, 6 - k].tokenValue == Token.TokenType.playerOne && tokenGrid[3 - k, 5 - k].tokenValue == Token.TokenType.playerOne && tokenGrid[2 - k, 4 - k].tokenValue == Token.TokenType.playerOne && tokenGrid[1 - k, 3 - k].tokenValue == Token.TokenType.playerOne)
            {
                return true;
            }
            if (tokenGrid[5 - k, 4 - k].tokenValue == Token.TokenType.playerOne && tokenGrid[4 - k, 3 - k].tokenValue == Token.TokenType.playerOne && tokenGrid[3 - k, 2 - k].tokenValue == Token.TokenType.playerOne && tokenGrid[2 - k, 1 - k].tokenValue == Token.TokenType.playerOne)
            {
                return true;
            }
        }
        for (int k = 0; k < 3; k++)
        {
            if (tokenGrid[5 - k, 5 - k].tokenValue == Token.TokenType.playerOne && tokenGrid[4 - k, 4 - k].tokenValue == Token.TokenType.playerOne && tokenGrid[3 - k, 3 - k].tokenValue == Token.TokenType.playerOne && tokenGrid[2 - k, 2 - k].tokenValue == Token.TokenType.playerOne)
            {
                return true;
            }
            if (tokenGrid[5 - k, 6 - k].tokenValue == Token.TokenType.playerOne && tokenGrid[4 - k, 5 - k].tokenValue == Token.TokenType.playerOne && tokenGrid[3 - k, 4 - k].tokenValue == Token.TokenType.playerOne && tokenGrid[2 - k, 3 - k].tokenValue == Token.TokenType.playerOne)
            {
                return true;
            }
        }

        return false;
    }

    public bool IsPlayerTwoVictory()
    {
        // Horizontal check
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (tokenGrid[i, j].tokenValue == Token.TokenType.playerTwo && tokenGrid[i, j + 1].tokenValue == Token.TokenType.playerTwo && tokenGrid[i, j + 2].tokenValue == Token.TokenType.playerTwo && tokenGrid[i, j + 3].tokenValue == Token.TokenType.playerTwo)
                {
                    return true;
                }
            }
        }

        // Vertical check
        for (int j = 0; j < columns; j++)
        {
            for (int i = 0; i < 3; i++)
            {
                if (tokenGrid[i, j].tokenValue == Token.TokenType.playerTwo && tokenGrid[i + 1, j].tokenValue == Token.TokenType.playerTwo && tokenGrid[i + 2, j].tokenValue == Token.TokenType.playerTwo && tokenGrid[i + 3, j].tokenValue == Token.TokenType.playerTwo)
                {
                    return true;
                }
            }
        }

        // Right diagonal check
        if (tokenGrid[3, 0].tokenValue == Token.TokenType.playerTwo && tokenGrid[2, 1].tokenValue == Token.TokenType.playerTwo && tokenGrid[1, 2].tokenValue == Token.TokenType.playerTwo && tokenGrid[0, 3].tokenValue == Token.TokenType.playerTwo)
        {
            return true;
        }
        if (tokenGrid[5, 3].tokenValue == Token.TokenType.playerTwo && tokenGrid[4, 4].tokenValue == Token.TokenType.playerTwo && tokenGrid[3, 5].tokenValue == Token.TokenType.playerTwo && tokenGrid[2, 6].tokenValue == Token.TokenType.playerTwo)
        {
            return true;
        }
        for (int k = 0; k < 2; k++)
        {
            if (tokenGrid[4 - k, 0 + k].tokenValue == Token.TokenType.playerTwo && tokenGrid[3 - k, 1 + k].tokenValue == Token.TokenType.playerTwo && tokenGrid[2 - k, 2 + k].tokenValue == Token.TokenType.playerTwo && tokenGrid[1 - k, 3 + k].tokenValue == Token.TokenType.playerTwo)
            {
                return true;
            }
            if (tokenGrid[5 - k, 2 + k].tokenValue == Token.TokenType.playerTwo && tokenGrid[4 - k, 3 + k].tokenValue == Token.TokenType.playerTwo && tokenGrid[3 - k, 4 + k].tokenValue == Token.TokenType.playerTwo && tokenGrid[2 - k, 5 + k].tokenValue == Token.TokenType.playerTwo)
            {
                return true;
            }
        }
        for (int k = 0; k < 3; k++)
        {
            if (tokenGrid[5 - k, 0 + k].tokenValue == Token.TokenType.playerTwo && tokenGrid[4 - k, 1 + k].tokenValue == Token.TokenType.playerTwo && tokenGrid[3 - k, 2 + k].tokenValue == Token.TokenType.playerTwo && tokenGrid[2 - k, 3 + k].tokenValue == Token.TokenType.playerTwo)
            {
                return true;
            }
            if (tokenGrid[5 - k, 1 + k].tokenValue == Token.TokenType.playerTwo && tokenGrid[4 - k, 2 + k].tokenValue == Token.TokenType.playerTwo && tokenGrid[3 - k, 3 + k].tokenValue == Token.TokenType.playerTwo && tokenGrid[2 - k, 4 + k].tokenValue == Token.TokenType.playerTwo)
            {
                return true;
            }
        }

        // Left diagonal check (needs testing)
        if (tokenGrid[3, 6].tokenValue == Token.TokenType.playerTwo && tokenGrid[2, 5].tokenValue == Token.TokenType.playerTwo && tokenGrid[1, 4].tokenValue == Token.TokenType.playerTwo && tokenGrid[0, 3].tokenValue == Token.TokenType.playerTwo)
        {
            return true;
        }
        if (tokenGrid[5, 3].tokenValue == Token.TokenType.playerTwo && tokenGrid[4, 2].tokenValue == Token.TokenType.playerTwo && tokenGrid[3, 1].tokenValue == Token.TokenType.playerTwo && tokenGrid[2, 0].tokenValue == Token.TokenType.playerTwo)
        {
            return true;
        }
        for (int k = 0; k < 2; k++)
        {
            if (tokenGrid[4 - k, 6 - k].tokenValue == Token.TokenType.playerTwo && tokenGrid[3 - k, 5 - k].tokenValue == Token.TokenType.playerTwo && tokenGrid[2 - k, 4 - k].tokenValue == Token.TokenType.playerTwo && tokenGrid[1 - k, 3 - k].tokenValue == Token.TokenType.playerTwo)
            {
                return true;
            }
            if (tokenGrid[5 - k, 4 - k].tokenValue == Token.TokenType.playerTwo && tokenGrid[4 - k, 3 - k].tokenValue == Token.TokenType.playerTwo && tokenGrid[3 - k, 2 - k].tokenValue == Token.TokenType.playerTwo && tokenGrid[2 - k, 1 - k].tokenValue == Token.TokenType.playerTwo)
            {
                return true;
            }
        }
        for (int k = 0; k < 3; k++)
        {
            if (tokenGrid[5 - k, 5 - k].tokenValue == Token.TokenType.playerTwo && tokenGrid[4 - k, 4 - k].tokenValue == Token.TokenType.playerTwo && tokenGrid[3 - k, 3 - k].tokenValue == Token.TokenType.playerTwo && tokenGrid[2 - k, 2 - k].tokenValue == Token.TokenType.playerTwo)
            {
                return true;
            }
            if (tokenGrid[5 - k, 6 - k].tokenValue == Token.TokenType.playerTwo && tokenGrid[4 - k, 5 - k].tokenValue == Token.TokenType.playerTwo && tokenGrid[3 - k, 4 - k].tokenValue == Token.TokenType.playerTwo && tokenGrid[2 - k, 3 - k].tokenValue == Token.TokenType.playerTwo)
            {
                return true;
            }
        }

        return false;
    }

    public bool IsDraw()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (tokenGrid[i, j].tokenValue == Token.TokenType.noPlayer)
                {
                    return false;
                }
            }
        }
        if (IsPlayerOneVictory())
        {
            return false;
        }
        if (IsPlayerTwoVictory())
        {
            return false;
        }
        return true;
    }
}
