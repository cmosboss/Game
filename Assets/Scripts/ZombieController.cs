using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {
	//health and armour
	public float Health = 50.0f;
	public float exp = 0;
	public int moveSpeed;
	//this is the player variable, this is used to find the people to chase
	private GameObject player;
	//if the enemy is hit, and if so set the text alpha
	bool hit = false;
	public GUIStyle style;

	private float damage;
	float alpha = 1;
	public Vector3 hitColor;
	//amount to get knocked back and what direction to do it
	float KnockBackAmmount;
	Vector2 KnockBackDirection;

	//function to knock back, basically this is the got hit function
	public void KnockedBack(float knockbackForce, Vector2 rot,float damage, Vector3 hitColor)
	{
		Health = Health - damage;
		this.hitColor = hitColor;
		if (Health <= 0)
		{
			player.gameObject.SendMessage("ApplyExp", exp/2);
			player.gameObject.SendMessage("ApplyDmg", 1);

			Destroy(this.gameObject);
		}
		KnockBackAmmount = knockbackForce;
		KnockBackDirection = rot;
		rigidbody2D.AddForce(KnockBackDirection * KnockBackAmmount);
		hit = true;
		if (this.alpha > 0.7)
		{
			this.damage = this.damage + damage;
		}
		else
		{
			this.damage = damage;
		}
		this.alpha = 1;
	}
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		exp = Health;
	}

	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .01f* moveSpeed);
	}

	void OnGUI(){
		if (hit) 
		{
			Vector3 getPixelPos = Camera.main.WorldToScreenPoint( transform.position );
			getPixelPos.y = Screen.height - getPixelPos.y;
			float x = hitColor.x;
			float y = hitColor.y;
			float z = hitColor.z;
			GUI.color = new Color(x,y,z,alpha);
			GUI.Label( new Rect(getPixelPos.x,getPixelPos.y + -(transform.localScale.x*200),200f,100f), damage.ToString("f1"), style);
			alpha = alpha - 0.01f;
		}
	}
}
