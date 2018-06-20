using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	public GameObject map;
	private tile[,] mymap; //saves the tilemap array
	private int mapx; //saves the dimensions of the map
	private int mapz;
	public tile mytile; // the class of the tile currently being stood on by enemy.
	private GameObject Me;

	// ran when the class object is created
	void Start () {
		mymap = map.GetComponent<spawnmap>().MAP; //gets certain components from the "spawnmap" class
		mapz = map.GetComponent<spawnmap>().mapZ;
		mapx = map.GetComponent<spawnmap>().mapX;
		mytile = mymap[(int)this.transform.position.x, (int)this.transform.position.z];
	}
}
