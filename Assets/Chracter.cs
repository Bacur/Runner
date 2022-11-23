using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chracter : MonoBehaviour
{
    Vector3 CurrentPos = default;
	Vector3 NextPos = default;
	[SerializeField]
	private Tile NextTile;
	[SerializeField]
	private float speed = 0.95f;
	private Rigidbody rigidbody;

	private bool isMove = false;

	[SerializeField]
	private float Max = 2f;
	private float min = 0.95f;
	private float cofficient = 0.001f;
	private void Awake()
	{
		CurrentPos = transform.position;
		rigidbody = GetComponent<Rigidbody>();
		NextPos = NextTile.GetPosToCharacter();
		StartCoroutine(Move());
	}

	private void MoveNext()
	{

			NextTile = NextTile.Next;
			NextPos = NextTile.GetPosToCharacter();
			StartCoroutine(Move());
		
	}

	private void CanMove() 
	{
		if (NextTile.Next != null)
		{
			MoveNext();
		}
		else
		{
			speed = min;
			StartCoroutine(WaitNexTile());
		}
	}

	IEnumerator Move() 
	{
		isMove = true;
		float time = default;
		Vector3 tempPos = CurrentPos;
		while (time != 1f)
		{
			tempPos = Vector3.Lerp(CurrentPos, NextPos, time);
			transform.position = tempPos;
			time = Mathf.Clamp(Time.deltaTime * speed + time,0,1);
			speed = Mathf.Clamp(speed + (min * cofficient),min,Max);
			yield return null;
		}
		CurrentPos = transform.position;

			CanMove();

		isMove = false;
		yield return null;
	}

	IEnumerator WaitNexTile() 
	{
		while (NextTile.Next == null)
			yield return null;

		MoveNext();
		yield return null;
	}
}
