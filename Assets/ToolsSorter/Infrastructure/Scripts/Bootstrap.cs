using Presenters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Views.Game.InteractableObjects.Tools;

public class Bootstrap : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
        
        MovementPresenterFactory movementPresenterFactory = new MovementPresenterFactory();
    }
}
