﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventLogController : MonoBehaviour {

	public GameObject textbox;
	public Transform parent;

	private Event[] events;
	// Use this for initialization
	void Start () {
		events = EventManager.GetPreviousEvents();
		float y = 0;
		//parent.transform.position = new Vector2(0, 0);
		if (events != null)
		{
			foreach (Event name in events)
			{
				GameObject text = Instantiate(textbox) as GameObject;
				Text description = text.GetComponentInChildren<Text>();
				text.GetComponent<EventHolder>().eventName = name;
				description.text = name.guiName + "\n\n Turn: " + name.turn;
				text.transform.SetParent(parent.transform);
				text.name = name.nameID;
				y = y + text.transform.lossyScale.y;
				Vector2 pos = new Vector2(text.transform.position.x, y);
				text.transform.position = pos;
				text.transform.localScale = new Vector3(1f, 1f, 1f);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (parent.GetComponent<VerticalLayoutGroup>().preferredHeight > parent.GetComponent<RectTransform>().sizeDelta.y)
		{
			parent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, parent.GetComponent<VerticalLayoutGroup>().preferredHeight);
		}
	}

	public void DisplayEvent()
	{
		GameManager.eventManager.DisplayEvent(EventSystem.current.currentSelectedGameObject.GetComponent<EventHolder>().eventName);
	}
	
}
