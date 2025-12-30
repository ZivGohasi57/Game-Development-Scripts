using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObjectManager : MonoBehaviour
{
    public static PersistentObjectManager instance = null;

    [Header("Player Data")]
    public float playerHP = 100f;
    public int weaponType = -1;
    public bool hasSword = false;
    public bool hasFists = false;
    public bool hasSwordInHand = false;
    public bool hasSwordOnWall = true;

    [Header("World Data")]
    public HashSet<string> collectedItems = new HashSet<string>();
    public HashSet<string> openDoors = new HashSet<string>();
    public HashSet<string> openedContainers = new HashSet<string>();
    public HashSet<string> deadEnemies = new HashSet<string>();
    public string lastSceneName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        
        EventManager.OnPlayerHealthChanged += UpdateHP;
        EventManager.OnItemCollected += CollectItem;
        EventManager.OnWeaponCollected += UnlockWeapon;
        EventManager.OnWeaponSwitched += SetWeaponType;
    }

    private void OnDisable()
    {
        EventManager.OnPlayerHealthChanged -= UpdateHP;
        EventManager.OnItemCollected -= CollectItem;
        EventManager.OnWeaponCollected -= UnlockWeapon;
        EventManager.OnWeaponSwitched -= SetWeaponType;
    }

    

    private void UpdateHP(float newHP) => playerHP = newHP;
    private void SetWeaponType(int type) => weaponType = type;

    private void UnlockWeapon(string weaponName)
    {
        if (weaponName == "Sword") { hasSword = true; hasSwordInHand = true; }
        if (weaponName == "Fists") { hasFists = true; }
    }

    public void CollectItem(string itemName)
    {
        if (!collectedItems.Contains(itemName)) collectedItems.Add(itemName);
    }

    
    
    public bool IsContainerOpen(string id) => openedContainers.Contains(id);
    public void SetContainerOpen(string id) => openedContainers.Add(id);
    
    public bool IsDoorOpen(string id) => openDoors.Contains(id);
    public void SetDoorOpen(string id) => openDoors.Add(id);

    public bool IsEnemyDead(string id) => deadEnemies.Contains(id);
    public void SetEnemyDead(string id) => deadEnemies.Add(id);

    public void SetLastScene(string scene) => lastSceneName = scene;
    public string GetLastScene() => lastSceneName;

    public void ClearData()
    {
        playerHP = 100f;
        weaponType = -1;
        hasSword = false;
        hasFists = false;
        collectedItems.Clear();
        openDoors.Clear();
        openedContainers.Clear();
        deadEnemies.Clear();
    }
}
