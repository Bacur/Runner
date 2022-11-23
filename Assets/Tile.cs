using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public Tile Next;
	public Transform PosCharacter;
	public Transform NextPos;

	public Tile CreateNextTile(Tile tile) 
	{
		Next = Instantiate(tile);
		Next.SetPosition(NextPos.position,NextPos.forward);
		return Next;
	}

	public Vector3 GetPosToCharacter() 
	{
		return PosCharacter.position;
	}

	public void SetPosition(Vector3 pos,Vector3 forward)		
	{
		transform.position = pos;
		transform.forward = forward;
	}
}
