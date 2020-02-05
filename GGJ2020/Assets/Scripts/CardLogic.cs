using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//this script is used to check if the player mouse is over the card 
public class CardLogic : MonoBehaviour
{

	public Card card;
	BoxCollider2D thisCard;
	public bool isMouseOver = false;

	private void Start(){
		thisCard = gameObject.GetComponent<BoxCollider2D>();
	}

    private void OnMouseOver(){
    	isMouseOver = true;
    }

    private void OnMouseExit(){
    	isMouseOver = false;
    }

}


//STORED ON GAMEMANAGER OBJECT. CONTROLS SPRITES.
public enum CardSprite
{
	BIRD,
	MUSHROOM,
	GOBLIN,
	WORM,
	SCORPION
	//make sure sprite elements are uploaded in this order to gamemanager!
}