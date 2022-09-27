using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    public static GameManager Instance { get; private set; }

    public int gunAmmo = 10;

    private void Awake()
    {
        Instance = this;
    }

}
