using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour {
	public GameObject EnemyPreset;
	public GameObject Map;
	private tile[,] mymap; //saves the tilemap array
	private int mapx; //saves the dimensions of the map
	private int mapz;
	private tile mytile; // the class of the tile currently being stood on by enemy.
	private GameObject Me;

	// ran when the class object is created
	void Start()
	{
		mymap = Map.GetComponent<spawnmap>().MAP; //gets certain components from the "spawnmap" class
		mapz = Map.GetComponent<spawnmap>().mapZ;
		mapx = Map.GetComponent<spawnmap>().mapX;
		for (int z = 0; z < mapz; z += 1)
		{
			StartCoroutine(spawn(0, z)); //spawns the unity gameobject, whilst allowing to do other jobs
		}
	}

	IEnumerator spawn(int x, int z)
	{
		Vector3 pos;
		float ycoor;
		mytile = mymap[x, z];
		ycoor = (mytile.height / 2f) + 1f;
		pos = Vector3.right * x + Vector3.up * ycoor + Vector3.forward * z;
		Me = Instantiate(EnemyPreset, pos, EnemyPreset.transform.rotation) as GameObject;
		Me.GetComponent<enemy>().map = Map;
		yield return null;
	}
}
