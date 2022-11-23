using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNextTile : MonoBehaviour
{
	public Tile prefab;
	public ControllerTile Controller;

	private Button button;
	private void Awake()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(Click);
	}

	private void OnDestroy()
	{
		button.onClick.RemoveListener(Click);
	}

	private void Click() 
	{
		Controller.SetNewTile(prefab);
	}
}

