using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngameMenuController : MonoBehaviour
{
    [SerializeField] Slider m_timeSlider;
    [SerializeField] Text m_timeValue;

    private void Start()
    {
        m_timeSlider.onValueChanged.AddListener(ChangeTimeMultiplier);
    }

    public void BackPressed()
    {
        SceneManager.LoadScene((int)SceneId.Menu, LoadSceneMode.Single);
    }

    public void ChangeTimeMultiplier(float a_newMultiplier)
    {
        Time.timeScale = a_newMultiplier;
        m_timeValue.text = a_newMultiplier.ToString("0.00");
    }
}
