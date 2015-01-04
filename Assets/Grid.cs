using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[ExecuteInEditMode]
public class Grid : MonoBehaviour {

	Sprite ice = Resources.Load("blocks2", typeof(Sprite)) as Sprite;
	Sprite grass = Resources.Load("blocks3", typeof(Sprite)) as Sprite;
	//public float Rseed = 0.1625827449f;
	public float Rseed = 0.0f;

	public float cell_size = 1f; // = larghezza/altezza delle celle
	private float x, y, z;

	void Start() {
		x = Mathf.Round(transform.position.x / cell_size) * cell_size;
		y = Mathf.Round(transform.position.y / cell_size) * cell_size;
		z = transform.position.z;
		transform.position = new Vector3(x, y, z);
		float seed = Mathf.PerlinNoise(transform.position.x*Rseed, transform.position.y*Rseed);
		if (seed > 0.9)
		{
			this.GetComponent<SpriteRenderer>().sprite = ice;
		}
		if (seed < 0.9 && seed > 0.65)
		{
			this.GetComponent<SpriteRenderer>().sprite = grass;
		}
	}



	void Update () {

	}
	
}
