using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void StartFight(Enemy controller);
    public static event StartFight Fight;

    public delegate void GameOver();
    public static event GameOver gameOver;


    public static void F_Fight(Enemy controller)
    {
        Fight(controller);
    }

    public static void F_GameOver()
    {
        gameOver();
    }
}
