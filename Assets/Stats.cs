using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Stats : MonoBehaviour {
	public  int strength = 100;
	public  int defense = 0;
	public  int agility = 0;
	public  int intel = 0;

	public int level = 1;

	public float health = 0;
	public float maxHealth = 0;
	public static float damage = 0;
	public static float critChance = 10;
	public static float critDamage = 0;
	public float protection = 0;
	public float castRate = 0;

	public int fStats = 10;

	public Slider expSlider;
	public Slider hpSlider;
	public Text expValue;
	public Text StrValue;
	public Text DefValue;
	public Text AgiValue;
	public Text IntValue;

	public Button strAdd;
	public Button defAdd;
	public Button agiAdd;
	public Button intAdd;


	public int TNL = 0;
	public int EXP = 0;

	// Use this for initialization
	void Start () {
		TNL = (1500*level)+(1500);
		health = strength*3+defense*1.5f;
		maxHealth = strength*3+defense*1.5f;
		damage = strength*3;
		critChance = 1.5f*level/2;
		critDamage = strength*6.75f;
		protection = defense*2+agility*1.5f;
		castRate = intel*2+agility;
		expValue.text = EXP.ToString()+"/"+TNL.ToString();
		expSlider.maxValue = TNL;
		expSlider.minValue = 0;
		expSlider.value = EXP;
		StrValue.text = strength.ToString();
		DefValue.text = defense.ToString();
		AgiValue.text = agility.ToString();
		IntValue.text = intel.ToString();
	}

	void updateAllStats()
	{
		maxHealth = strength*3+defense*1.5f;
		damage = strength*3;
		critChance = 1.5f*level/2;
		critDamage = strength*6.75f;
		protection = defense*2+agility*1.5f;
		castRate = intel*2+agility;
	}
	// Update is called once per frame
	void Update () {
		if (EXP > TNL)
		{
			LevelUp();
		}
		if (fStats <= 0)
		{
			removeAddStat();
		}
	}

	void removeAddStat()
	{
		strAdd.gameObject.SetActive(false);
		defAdd.gameObject.SetActive(false);
		agiAdd.gameObject.SetActive(false);
		intAdd.gameObject.SetActive(false);
	}
	void showAddStat()
	{
		strAdd.gameObject.SetActive(true);
		defAdd.gameObject.SetActive(true);
		agiAdd.gameObject.SetActive(true);
		intAdd.gameObject.SetActive(true);
	}
	void showStats()
	{
		StrValue.text = strength.ToString();
		DefValue.text = defense.ToString();
		AgiValue.text = agility.ToString();
		IntValue.text = intel.ToString();
	}
	public void addStats(string type)
	{
		if (fStats > 0)
		{
			if (type == "str")
			{
				strength = strength+1;
				fStats = fStats-1;
				showStats();
			}
			if (type == "def")
			{
				defense = defense+1;
				fStats = fStats-1;
				showStats();
			}
			if (type == "agi")
			{
				agility = agility+1;
				fStats = fStats-1;
				showStats();
			}
			if (type == "int")
			{
				intel = intel+1;
				fStats = fStats-1;
				showStats();
			}
		}
		updateAllStats();

	}
	void ApplyDmg(int dmg)
	{
		health = health-dmg;
		hpSlider.maxValue = maxHealth;
		hpSlider.minValue = 0;
		hpSlider.value = health;
	}

	void ApplyExp(int exp)
	{
		EXP = EXP+exp;
		expSlider.maxValue = TNL;
		expSlider.minValue = 0;
		expSlider.value = EXP;
		expValue.text = EXP.ToString()+"/"+TNL.ToString();
	}
	void LevelUp()
	{
		level = level+1;
		EXP = EXP - TNL;
		TNL = (1500*level)+(1500);
		fStats = fStats+5;
		health = health+25;
		showAddStat();
		ApplyExp(0);
	}

}










