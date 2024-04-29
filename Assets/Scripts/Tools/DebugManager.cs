using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public KeyCode statGameInput;
    public KeyCode ResetInput;

#if UNITY_EDITOR // this code will only run in the editor, not in the build
    void Update()
    {
        if (Input.GetKeyDown(statGameInput))
        {
            GameManager.Instance.StartGame();
        }

        if (Input.GetKeyDown(ResetInput))
        {
            GameManager.Instance.RestartGame();
        }
    }
#endif
}
