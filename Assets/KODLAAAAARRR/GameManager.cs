using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Zorluk State;
    public PlayerController playerController; 

    public void Start()
    {
        playerController.slider.maxValue = playerController._hp;
        StartGameState(State);
       
    }

    // Update is called once per frame
   
    public void StartGameState(Zorluk newState)
    {
        State = newState;
        switch (newState)
        {
            case Zorluk.Kolay:
                playerController._hp = 600;
                break;
            case Zorluk.Orta:
                playerController._hp = 500;
                break;
            case Zorluk.Zor:
                playerController._hp = 400;
                break;
        }

    }

    public enum Zorluk
    {
        Kolay,
        Orta,
        Zor,
    }
}
