using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ShowMessage : MonoBehaviour
{
    public GameObject messagePanel;
    public TextMeshProUGUI messageText;
    public float fadeSpeed = 2f;
    Image panel;

    void Start()
    {
        panel = messagePanel.GetComponent<Image>();
    }

    public void ShowMessageBox()
    {
        messagePanel.SetActive(true);
        StartCoroutine(FadeTextToZeroAlpha(fadeSpeed, messageText));
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a - (Time.deltaTime / t));
            yield return null;
        }
        messagePanel.SetActive(false);
    }
}
