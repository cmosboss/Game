using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateWorld : MonoBehaviour {

	public static List<Vector3> Vectors = new List<Vector3>();
	public float size = 0;
	public float boundX = 0;
	public float boundY = 0;
	public float boundXX = 0;
	public float boundYY = 0;

	// Use this for initialization
	void Start () {
		//addBaseTile();
		GameObject Cam = GameObject.FindGameObjectWithTag("MainCamera");
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		size = Cam.camera.orthographicSize+10;
		boundX = player.transform.position.x+size;
		boundY = player.transform.position.y+size/2;
		boundXX = player.transform.position.x-size;
		boundYY = player.transform.position.y-size/2;

		addBaseTile();
	}
	
	// Update is called once per frame
	void Update()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");

		if (Input.GetKeyDown("space"))
		{
			delTiles();
		}
		if (player.transform.position.x+size > boundX+1)
		{
			boundX = boundX+1;
			boundXX = boundXX+1;
			addTileCol(1);
			delTiles();
		}
		if (player.transform.position.x-size < boundXX-1)
		{
			boundXX = boundXX-1;
			boundX = boundX-1;
			addTileCol(0);
			delTiles();
		}
		if (player.transform.position.y-size/2 < boundYY-1)
		{
			boundYY = boundYY-1;
			boundY = boundY-1;
			addTileRow(0);
			delTiles();
		}
		if (player.transform.position.y+size/2 > boundY+1)
		{
			boundYY = boundYY+1;
			boundY = boundY+1;
			addTileRow(1);
			delTiles();
		}
	}

	void delTiles()
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Tiles");
		foreach (GameObject o in objects)
		{
			if (o.transform.position.x < boundXX)
			{
				Destroy(o);
			}
			if (o.transform.position.x > boundX)
			{
				Destroy(o);
			}
			if (o.transform.position.y > boundY+2)
			{
				Destroy(o);
			}
			if (o.transform.position.y < boundYY-2)
			{
				Destroy(o);
			}
		}
	}

	void addTileRow(int side)
	{
		//int side, 0 is down and 1 is up;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (side == 1)
		{
			Vector3 spawn = new Vector3 (player.transform.position.x-size,player.transform.position.y+size/2+1,0);
			for (int i = 0; i <= size*2; i++) 
			{
				GameObject tile = (GameObject)Instantiate(Resources.Load("block1"));
				tile.transform.position = spawn;
				spawn.x = spawn.x+1;
			}
		}
		else
		{
			Vector3 spawn = new Vector3 (player.transform.position.x-size,player.transform.position.y-size/2-1,0);
			for (int i = 0; i <= size*2; i++) 
			{
				GameObject tile = (GameObject)Instantiate(Resources.Load("block1"));
				tile.transform.position = spawn;
				spawn.x = spawn.x+1;
			}
		}
	}
	void addTileCol(int side)
	{
		//int side, 0 is left and 1 is right;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (side == 1)
		{
			Vector3 spawn = new Vector3 (player.transform.position.x+size-1,player.transform.position.y-size,0);
			for (int i = 0; i <= size*2; i++) 
			{
				GameObject tile = (GameObject)Instantiate(Resources.Load("block1"));
				tile.transform.position = spawn;
				spawn.y = spawn.y+1;
			}
		}
		else
		{
			Vector3 spawn = new Vector3 (player.transform.position.x-size+1,player.transform.position.y-size,0);
			for (int i = 0; i <= size*2; i++) 
			{
				GameObject tile = (GameObject)Instantiate(Resources.Load("block1"));
				tile.transform.position = spawn;
				spawn.y = spawn.y+1;
			}
		}
	}

	void addBaseTile()
	{

		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Vector3 spawn = new Vector3 (player.transform.position.x-size,player.transform.position.y-size,0);

		for (int i = 0; i < size*2; i++) 
		{
			for (int j = 0; j < size*2; j++) 
			{
				GameObject tile = (GameObject)Instantiate(Resources.Load("block1"));
				tile.transform.position = spawn;
				spawn.x = spawn.x+1;
			}
			spawn.x = spawn.x-size*2;
			spawn.y = spawn.y+1;
		}
	}
}
