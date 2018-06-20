using System.Collections;
using UnityEngine;

public class tile : MonoBehaviour{
	public GameObject tilepreset; //used to initalise a copy of the tile
	public GameObject parent; //used to have the transform postion of created tile, referenced through TileMap object
	public float height; //the tile height
	public Vector3 mapPos; //the tiles position, in refernce to the grid
	private GameObject block;

	// method tile() is a construcctor for the class
	public tile(float _height, Vector3 _mapPos, GameObject _tilepreset, GameObject _parent)
	{
		//sets the tiles position, height, tilepreset, and parent
		height = _height;
		mapPos = _mapPos;
		tilepreset = _tilepreset;
		parent = _parent;
		create();
	}

	// creates a new tile as unity game object, which is displayed in game
	private void create()
	{
		//instantiateses the cube object into the world
		block = Instantiate(tilepreset, mapPos, tilepreset.transform.rotation) as GameObject;
		//references the tile transform position, from the parent object.
		//also this puts all cloned tiles uber the "TileMap" object, not filling up the hierachy editor window
		block.transform.parent = parent.transform;
		// transforms the scale of the y axis, therefore stretching cube in y axis by factor height
		block.transform.localScale += Vector3.up * height;
		// by adding, ensures height 0 is high therefore, still visible in game, otherwise if set to 0 would be invisible

		//chaning the color of block depeding on height of tile
		//block.GetComponent<Renderer>().material.color = new Color(height / 30f, height/30f, height / 30f); // BLACK TO WHITE
		block.GetComponent<Renderer>().material.color = new Color(0.5f, 0.75f, Mathf.Pow((height/12f),-1.5f));
	}
}
