using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;

    private void Awake() {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        _textMeshProUGUI.text = "Kills : " + CiviliansAI.killCount;
    }

    private void Update() {
        _textMeshProUGUI.text = "Kills : " + CiviliansAI.killCount;
    }
}
