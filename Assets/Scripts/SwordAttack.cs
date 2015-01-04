using UnityEngine;
using System.Collections;

public class SwordAttack : MonoBehaviour {

	//min and max damage of this item type
	public float MinDamage;
	public float MaxDamage;
	//current most recent damage delt
	public float Damage = 0;
	public Vector3 hitColor = new Vector3(1,0,0);

	//crit chance and damage
	public float critChance;
	public float critDamage;

	void Start()
	{
		Damage = Stats.damage;
		MinDamage = Damage*0.9f;
		MaxDamage = Damage*1.1f;
		critChance = Stats.critChance;
		critDamage = Stats.critDamage;
	}

	public float CritCheck(float critChance, float critDamage)
	{
		//get attack dmg
		float weaponDmg = Random.Range(MinDamage,MaxDamage);
		//apply crit
		hitColor = new Vector3(0,1,1);
		float rand = Random.Range(0,100);
		if (critChance > rand)
		{
			hitColor = new Vector3(1,0,0);
			weaponDmg = weaponDmg * critDamage;
		}
		return weaponDmg;
	}

	//amount to knock someone back with this item
	public int knockBackAmount;

	//amount to spin around, swords probably alot.
	public float SpinAmmount;
	//speed in which you rotater
	public int RotAmmount;

	//current spin value, speed and if you are swinging
	float spinValue;
	float spinSpeed;
	bool swinging;

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown("space"))
		{
			Damage = Random.Range(MinDamage,MaxDamage);
			Attack(330,20);
		}
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			Damage = Random.Range(MinDamage,MaxDamage);
			Attack(60,10);
		}
		Damage = Stats.damage;
		MinDamage = Damage*0.9f;
		MaxDamage = Damage*1.1f;
		critChance = Stats.critChance;
		critDamage = Stats.critDamage;
	if(swinging)
	{
		transform.Rotate(new Vector3(0,0,1) * spinSpeed);
	}
	float angle = Quaternion.Angle(transform.rotation, Quaternion.Euler(0,0,spinValue));

	if(angle <= 3)
	{
		swinging = false;
		transform.rotation = Quaternion.Euler(0,0,-30);
	}
	}
	
	void Attack(float RotValue, float SpinSpeed)
	{
		spinValue = RotValue;
		spinSpeed = SpinSpeed;
		swinging = true;
	}
	
	void OnTriggerExit2D(Collider2D collider)
	{
		if (swinging)
		{
			GameObject ObjectOBJ = collider.gameObject;
			if(ObjectOBJ.tag == "Enemy")
			{
				ObjectOBJ.GetComponent<ZombieController>().KnockedBack(knockBackAmount,transform.up, CritCheck(critChance, critDamage), hitColor);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (swinging)
		{
			GameObject ObjectOBJ = collider.gameObject;
			if(ObjectOBJ.tag == "Enemy")
			{
				ObjectOBJ.GetComponent<ZombieController>().KnockedBack(knockBackAmount,transform.up, CritCheck(critChance, critDamage),hitColor);
			}
		}
	}
	
}
