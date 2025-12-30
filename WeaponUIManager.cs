using UnityEngine;
using UnityEngine.UI;

public class WeaponUIManager : MonoBehaviour
{
    public RawImage fistsImage;   
    public RawImage swordImage;  
    public Text fistsText;   
    public Text swordText;
    
    private void Start()
    {
        UpdateUI(-1);
    }

    private void OnEnable()
    {
        EventManager.OnWeaponSwitched += UpdateUI;
    }

    private void OnDisable()
    {
        EventManager.OnWeaponSwitched -= UpdateUI;
    }

    public void UpdateUI(int currentWeaponType)
    {
        bool hasFists = PersistentObjectManager.instance.hasFists;
        bool hasSword = PersistentObjectManager.instance.hasSword;

        fistsImage.enabled = hasFists;
        swordImage.enabled = hasSword;
        fistsText.enabled = hasFists;
        swordText.enabled = hasSword;

        Color fullColor = new Color(1f, 1f, 1f, 1f);
        Color fadedColor = new Color(1f, 1f, 1f, 0.5f); 

        fistsImage.color = (currentWeaponType == 0) ? fullColor : fadedColor;
        fistsText.color = (currentWeaponType == 0) ? fullColor : fadedColor;

        swordImage.color = (currentWeaponType == 1) ? fullColor : fadedColor;
        swordText.color = (currentWeaponType == 1) ? fullColor : fadedColor;
    }
}