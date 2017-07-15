using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void StartFight(Enemy controller);
    public static event StartFight Fight;


    public static void F_Fight(Enemy controller)
    {
        Fight(controller);
    }
}
