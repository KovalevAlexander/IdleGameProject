using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
