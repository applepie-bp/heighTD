using System.Collections;
using UnityEngine;

public class spawnmap : MonoBehaviour
{
	public GameObject tilePreset;
	public int mapX = 40;
	public int mapZ = 40;
	public tile[,] MAP;
	private Vector3 Origin = Vector3.zero;
	public float heightScalar = 10F; // the range of values that height can take.
	public float zoomScalar = 10F; // how zoomed into perlin noise.
	public float xOffset; // randomly adds or subtracts from x and z coordinates to change terrain each game.
	public float zOffset; // otherwise corrdinates would always be the same

	//awake() called on inisialization of script, before start() so map loaded before spawning enemies etc.
	void Awake()
	{
		// run in a seprate thread to increase performance, allowing for other processes to be done at the same time.
		xOffset = Random.Range(-1.0f, 1.0f);
		zOffset = Random.Range(-1.0f, 1.0f);
		StartCoroutine(CreateMap());
	}

	//sperate job to increase performance
	IEnumerator CreateMap()
	{
		float height;
		MAP = new tile[mapX, mapZ];
		// cycle through each column of the grid
		for (int x = 0; x < mapX; x += 1)
		{
			//cycle through each tile in row
			for (int z = 0; z < mapZ; z += 1)
			{
				//vector addition of right(1,0,0) * by scalar, which enlarges 1 and so shifting further right, same for forward(0,0,1)
				Vector3 pos = Origin + Vector3.right * x + Vector3.forward * z;
				//generate height
				//height = z/2 + x/2 // <- DOESN'T give decimal answers ... needs to be divided by 2f
				//height = Mathf.Sin(z)+Mathf.Cos(x)*20f; // <- Test for floating point .. sin repeats not random enough 
				height = 40f * Mathf.PerlinNoise((float)x/10f + xOffset, z/10f + zOffset);
				//creates copy of block at pos, of type block1, with the parent being the unity object this class is in
				MAP[x, z] = new tile(height, pos, tilePreset, this.gameObject);
			}
		}
		// job needs to return something, but no need to return anything in program, so null returned
		yield return null;
	}
}
