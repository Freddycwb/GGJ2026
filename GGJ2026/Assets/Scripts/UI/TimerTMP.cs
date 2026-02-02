using UnityEngine;
using TMPro;

public class TimerTMP : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    [SerializeField] private FloatVariable time;

    [SerializeField] private bool update;
    [SerializeField] private bool reset;

    private void Start()
    {
        if (!reset)
        {
            string m = ((int)time.Value / 60).ToString("00");
            string s = Mathf.FloorToInt(time.Value % 60).ToString("0");
            tmp.text = $"{m}:{s}";
            return;
        }
        time.Value = 0;
    }

    private void Update()
    {
        if (!update) return;
        time.Value += Time.deltaTime;
        string m = ((int)time.Value / 60).ToString("00");
        string s = Mathf.FloorToInt(time.Value % 60).ToString("00");
        tmp.text = $"{m}:{s}";
    }
}
