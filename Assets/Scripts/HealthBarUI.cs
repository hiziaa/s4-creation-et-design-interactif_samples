using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [Header("ScriptableObjects")]
    public PlayerData playerData;
    
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = playerData.maxHealth;
        slider.value = playerData.currentHealth;
    }

    void Update()
    {
        slider.value = playerData.currentHealth;
    }
}