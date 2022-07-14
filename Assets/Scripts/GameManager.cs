using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gameState
{
	menu,
	inGame,
	gameOver
}

public class GameManager : MonoBehaviour
{
	public gameState curGameState = gameState.menu;
	public static GameManager sharedInstance;
	PlayerController spaceMan;

	void Awake ()
	{
		if(sharedInstance == null)
		{
			sharedInstance = this;
		}
	}

	void Start()
	{
		spaceMan = GameObject.Find("Space Man").GetComponent<PlayerController>();
	}

	void Update()
	{
		if(Input.GetButtonDown("Submit") && curGameState != gameState.inGame)
		{
			inGame();
		}
		else if(Input.GetButtonDown("Cancel"))
		{
			inMenu();
		}
		else if(Input.GetKeyDown(KeyCode.E))
		{
			inGameOver();
		}
	}

	public void inMenu()
	{
		setGameState(gameState.menu);
	}

	public void inGame()
	{
		setGameState(gameState.inGame);
	}

	public void inGameOver()
	{
		setGameState(gameState.gameOver);
	}

	void setGameState(gameState newGameState)
	{
		if(newGameState == gameState.menu)
		{
			//Estado menu
		}
		else if(newGameState == gameState.inGame)
		{
			spaceMan.startGame();
		}
		else
		{
			
		}

		this.curGameState = newGameState;
	}
}
