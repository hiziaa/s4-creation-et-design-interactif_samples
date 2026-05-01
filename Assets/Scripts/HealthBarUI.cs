using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [Header("ScriptableObjects")]
    public PlayerData playerData;
    
    private Slider slider;

   void Awake()
{
    slider = GetComponent<Slider>();
    slider.maxValue = playerData.maxHealth;
    slider.value = playerData.maxHealth;
}

    void Update()
    {
        slider.value = playerData.currentHealth;
    }
}