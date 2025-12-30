using System;
using UnityEngine;

public static class EventManager
{
    
    public static event Action<GameState> OnGameStateChanged;
    
    
    public static event Action<float> OnPlayerHealthChanged;
    public static event Action OnPlayerDeath;
    public static event Action<string> OnWeaponCollected;
    public static event Action<int> OnWeaponSwitched;

    
    public static event Action<int> OnGoldCollected;
    public static event Action<string> OnItemCollected;

    
    public static event Action OnMissionAdvanced;
    public static event Action<string> OnMissionUpdated;

    

    public static void TriggerGameStateChanged(GameState newState) => OnGameStateChanged?.Invoke(newState);
    
    public static void TriggerPlayerHealthChanged(float currentHP) => OnPlayerHealthChanged?.Invoke(currentHP);
    public static void TriggerPlayerDeath() => OnPlayerDeath?.Invoke();
    public static void TriggerWeaponCollected(string weaponName) => OnWeaponCollected?.Invoke(weaponName);
    public static void TriggerWeaponSwitched(int weaponType) => OnWeaponSwitched?.Invoke(weaponType);

    public static void TriggerGoldCollected(int amount) => OnGoldCollected?.Invoke(amount);
    public static void TriggerItemCollected(string itemId) => OnItemCollected?.Invoke(itemId);

    public static void TriggerMissionAdvanced() => OnMissionAdvanced?.Invoke();
    public static void TriggerMissionUpdated(string missionText) => OnMissionUpdated?.Invoke(missionText);
}
