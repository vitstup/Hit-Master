using UnityEngine;
using UnityEngine.UI;

public class HpUI : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image hpValue;

    public void SetHpValue(float value)
    {
        hpValue.fillAmount = value;

        if (value > 0) canvas.gameObject.SetActive(true);
        else canvas.gameObject.SetActive(false);
    }
}