using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTile : MonoBehaviour
{
	[SerializeField]
	private Tile current;
	public void SetNewTile(Tile tile) 
	{
		current = current.CreateNextTile(tile);
	}
}
