using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FpsShower : MonoBehaviour
{
    Text m_textField;

    private void Start()
    {
        m_textField = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float unscaledFPS = 1f / Time.unscaledDeltaTime;
        m_textField.text = $"FPS: {unscaledFPS:N2}";

        /*float unscaledFPS = 1f / Time.unscaledDeltaTime;
        float scaledFPS = 1f / Time.deltaTime;
        Debug.Log($"uscaledFPS = {unscaledFPS}; scaledFPS = {scaledFPS}");*/
    }
}
