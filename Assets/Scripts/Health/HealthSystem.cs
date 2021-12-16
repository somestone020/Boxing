using UnityEngine;

public class HealthSystem : MonoBehaviour {

	[Header("Health Settings")]
	public int MaxHp = 20;
	private int MaxMp = 20;
	public int CurrentHp = 20;
	private float CurrentMp = 20;
	public bool invulnerable;

	public float mpAddSpeed = 10;
	private bool isAddMp = true;
	private float mpAddRecoveryTime = 0;

	#if UNITY_EDITOR
	[HelpAttribute("Change these settings if you want to change the player portrait or player name in the healthbar located in the upperleft corner of the screen.", UnityEditor.MessageType.Info)]
	#endif

	[Header("Healthbar Settings")]
	public Sprite HUDPortrait;
	public string PlayerName;

	public delegate void OnHealthChange(float percentage, GameObject GO);
	public static event OnHealthChange onHealthChange;
	public delegate void OnSkillValueChange(float percentage);
	public static event OnSkillValueChange onSkillValueChange;

	void Start(){
		SendHealthUpdateEvent();
		
		SendSkillValueUpdate();
	}

	void Update() {
		AddSkillValue();
	}

	//substract health
	public void SubstractHealth(int damage){
		if(!invulnerable){

			//reduce hp
			CurrentHp = Mathf.Clamp(CurrentHp -= damage, 0, MaxHp);

			//Health reaches 0
			if (isDead()) gameObject.SendMessage("Death", SendMessageOptions.DontRequireReceiver);
		}

		SendHealthUpdateEvent();
	}

	//add health
	public void AddHealth(int amount){
		CurrentHp = Mathf.Clamp(CurrentHp += amount, 0, MaxHp);
		SendHealthUpdateEvent();
	}

	//health update event
	void SendHealthUpdateEvent(){
		float CurrentHealthPercentage = 1f/MaxHp * CurrentHp;
		if (onHealthChange != null) onHealthChange(CurrentHealthPercentage, gameObject);
	}

	//death
	bool isDead(){
		return CurrentHp == 0;
	}

	public bool CheckSkillValue(int consume)
    {
		if(CurrentMp - consume <= 0) return false;
		return true;
    }

	public void SendSkillValueUpdate()
    {
		float CurrentSkillValue = 1f / MaxMp * CurrentMp;
		if (onSkillValueChange != null) onSkillValueChange(CurrentSkillValue);
    }

	public void AddSkillValue()
	{
		if(mpAddRecoveryTime > 0)
        {
			mpAddRecoveryTime -= Time.deltaTime;
			return;
		}
        if (isAddMp && mpAddRecoveryTime <= 0)
        {
			mpAddRecoveryTime = 0;
			CurrentMp = Mathf.Clamp(CurrentMp += mpAddSpeed * Time.deltaTime, 0, MaxMp);
			if(CurrentMp >= MaxMp) isAddMp = false;
			SendSkillValueUpdate();
		}
	}

	public void SubstractSkillValue(int amount,float recoveryTime)
	{
		mpAddRecoveryTime = recoveryTime;
		CurrentMp = Mathf.Clamp(CurrentMp -= amount, 0, MaxMp);
		if (CurrentMp <= MaxMp) isAddMp = true;
		SendSkillValueUpdate();
	}

}
