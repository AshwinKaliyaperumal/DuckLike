using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuLogic : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        CoinManager.AddIncoming();
    }

    public void ExitToHome()
    {
        SceneManager.LoadScene("Home");
        CoinManager.AddIncoming();
    }
}
