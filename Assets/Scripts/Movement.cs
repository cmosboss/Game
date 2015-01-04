using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public int speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//float sample = Mathf.PerlinNoise(transform.position.x, transform.position.y);

		if (Input.GetAxis("Horizontal") != 0)
		{
			transform.Translate(new Vector3(Input.GetAxis("Horizontal"),0,0) * Time.deltaTime * speed);
		}
		if (Input.GetAxis("Vertical") != 0)
		{
			transform.Translate(new Vector3(0,Input.GetAxis("Vertical"),0) * Time.deltaTime * speed);
		}
	}
}
