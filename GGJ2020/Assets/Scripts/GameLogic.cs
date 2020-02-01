/*adapted from tutorial by Clipper on YouTube, "TINDER LIKE SWIPE MECHANICS"*/

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
    public TMP_Text dialogue; //text on the card
    public TMP_Text characterName;
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

    void Update()
    {
		/////////////////////TEXT COLOR HANDLING///////////////////////////////////
    	textColor.a = Mathf.Min(Mathf.Sqrt(Mathf.Abs(card.transform.position.x/4)/divideValue), 1);
    	dialogue.color = textColor;

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
		//////////////////////SIDE CHECKS///////////////////////////////////

        if (card.transform.position.x> fSideMargin)//check the right side of the card
        { 
        	dialogue.text = rightQuote;
        	if (!Input.GetMouseButton(0) && card.transform.position.x> fSideTrigger){
        		currentCard.Right();
        	}
        }
        else if (card.transform.position.x< -fSideMargin)// check the left side of the card 
        { 
        	dialogue.text = leftQuote;
        	if (!Input.GetMouseButton(0) && card.transform.position.x> fSideTrigger){
        		currentCard.Left();
        	}
        }
        else 
        {
        	sr.color = Color.white;
        }
    }

        public void LoadCard(Card card)
    {
    	sr.sprite = resourceManager.sprites[(int)card.sprite];
    	leftQuote = card.leftQuote;
    	rightQuote = card.rightQuote;
    	currentCard = card;
    }

}



  //  public TMP_Text display; // for debugging the distance

    /*private void OnMouseUp(){
        	if(!Input.GetMouseButton(0) && card.transform.position.x> fSideTrigger){
        	}
        	 else if(!Input.GetMouseButton(0)&& card.transform.position.x> fSideTrigger){
        	}
    }*/

        	   	//dialogue.alpha = Mathf.Min(-card.transform.position.x,1); //as the card gets to the left its text is less faded
        	//dialogue.alpha = Mathf.Min(card.transform.position.x,1); //as the card gets to the right margin its text gets less faded

    			//////////////////////UI DEBUG///////////////////////////////////

     //   display.text = "" + dialogue;
    	//
