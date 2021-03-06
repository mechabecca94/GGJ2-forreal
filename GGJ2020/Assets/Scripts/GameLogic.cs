﻿/*adapted from tutorial by Clipper on YouTube, "TINDER LIKE SWIPE MECHANICS"*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
	//////////////Gameobjects////////////////
    public GameObject card;
    public CardLogic cl; //checks for mouse over sprite using CardLogic
    public SpriteRenderer sr; //controls sprite being draw
    public ResourceManager resourceManager; //stores the info on what card to be used
    public Vector2 origin; // where the card is on run
    /////////////Tweaking variables///////////
    public float fMovingSpeed = 1f;
    public float fSideMargin;
    public float fSideTrigger;
    float alphaText;
    public Color textColor;
    Vector3 pos;
    public float divideValue;
    ////////////UI////////////
    public TMP_Text actionQuote; //text on the card
    public TMP_Text characterDialogue;
    ////////////Card variables////////////
    public string leftQuote;
    public string rightQuote;
    public Card currentCard;
    public Card testCard;

    void Start()
    {
    	LoadCard(testCard);
       origin = new Vector2(card.transform.position.x, card.transform.position.y); // so that the card snaps to beginning
    }
    void UpdateDialogue(){
        actionQuote.color = textColor;
        if(card.transform.position.x < 0) //left dialogue update
        {
              textColor.a = Mathf.Min((Mathf.Abs(card.transform.position.x)/divideValue), 1);
                actionQuote.text = leftQuote;
        }
        else //right dialogue update
        {
                actionQuote.text = rightQuote;
        }
    }

    void Update()
    {   
        textColor.a = Mathf.Min((Mathf.Abs(card.transform.position.x) - fSideMargin) /divideValue, 1);
		/////////////////////TEXT DIALOGUE HANDLING///////////////////////////////////
        if(card.transform.position.x > fSideTrigger) //if the card reaches to the left trigger and mouse up
        {
            if(Input.GetMouseButtonUp(0))
            {
            currentCard.Right();
            NewCard();
            }
        }
        else if(card.transform.position.x > fSideMargin) //if the card is before the left trigger, in left margin
        {

        }
        else if(card.transform.position.x > -fSideMargin) // if the card is in the middle between left and right margins
        {
            textColor.a = 0;
        }
        else if(card.transform.position.x > -fSideTrigger) //if the card is before the right trigger, in right margin
        {

        }
        else// if the card reaches to the right trigger and mouse up
        {
            if(Input.GetMouseButtonUp(0))
            {
            currentCard.Left();
            NewCard();
            }
        }
        UpdateDialogue();
		//////////////////////MOVEMENT///////////////////////////////////
        if (Input.GetMouseButton(0) && cl.isMouseOver) //if left mouse is pressed 
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get x y of mouse
            card.transform.position = pos; //and assign that x y to our card so it moves
        }
        else // if the card is not moving it goes to original position
        {
        	card.transform.position = Vector2.MoveTowards(transform.position, origin, 1);
        }

    }

        //////////////////////CARD LOADER///////////////////////////////////

        public void LoadCard(Card card)
    {
    	sr.sprite = resourceManager.sprites[(int)card.sprite];
    	leftQuote = card.leftQuote;
    	rightQuote = card.rightQuote;
    	currentCard = card;
        characterDialogue.text = card.dialogue;
    }

        //////////////////////CARD CHOOSER///////////////////////////////////
    public void NewCard()
    {
        int rollDice = Random.Range(0, resourceManager.cards.Length);
        LoadCard(resourceManager.cards[rollDice]); 
    }
}


