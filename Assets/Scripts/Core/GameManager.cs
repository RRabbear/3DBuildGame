using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.BaseUtils;
using Assets.Scripts.InputActions;

public class GameManager : MonoSingleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
        InputActionsHandler.Instance.Initialize();
    }
    private void OnDestroy()
    {
        InputActionsHandler.Instance.Dispose();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
