using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenuController : MonoBehaviour
{
    public void BackPressed()
    {
        SceneManager.LoadScene((int)SceneId.Menu, LoadSceneMode.Single);
    }
}
