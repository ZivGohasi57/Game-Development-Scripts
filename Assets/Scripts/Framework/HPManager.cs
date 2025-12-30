using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class HPManager : MonoBehaviour
{
    public Slider hpSlider;
    public TextMeshProUGUI hpText;
    public float maxHP = 100f; 
    private float currentHP; 
    
    public Color normalColor = Color.green; 
    public Color lowHpColor = Color.yellow; 
    public Color criticalHpColor = Color.red;

    private void Start()
    {
        
        if(PersistentObjectManager.instance != null)
            currentHP = PersistentObjectManager.instance.playerHP;
        else
            currentHP = maxHP;
            
        UpdateHPUI();
    }

    private void OnEnable()
    {
        EventManager.OnPlayerHealthChanged += UpdateHP;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerHealthChanged -= UpdateHP;
    }

    private void UpdateHP(float newHP)
    {
        currentHP = newHP;
        UpdateHPUI();
    }

    public void UpdateHPUI()
    {
        if (hpSlider != null)
        {
            hpSlider.value = currentHP / maxHP;
            if (currentHP / maxHP >= 0.4f)
                hpSlider.fillRect.GetComponent<Image>().color = normalColor;
            else if (currentHP / maxHP >= 0.2f)
                hpSlider.fillRect.GetComponent<Image>().color = lowHpColor;
            else
                hpSlider.fillRect.GetComponent<Image>().color = criticalHpColor;
        }

        if (hpText != null)
            hpText.text = Mathf.RoundToInt(currentHP) + "/" + Mathf.RoundToInt(maxHP);
    }
}
