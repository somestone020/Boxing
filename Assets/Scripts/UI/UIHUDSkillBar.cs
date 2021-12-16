using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHUDSkillBar : MonoBehaviour
{
	public Slider HpSlider;
	void Start()
    {
        
    }
	void OnEnable()
	{
		HealthSystem.onSkillValueChange += UpdateSkillValue;
	}

	void OnDisable()
	{
		HealthSystem.onSkillValueChange -= UpdateSkillValue;

	}
	void UpdateSkillValue(float percentage)
	{
		HpSlider.value = percentage;
		
	}
}
