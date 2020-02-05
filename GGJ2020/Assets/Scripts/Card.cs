using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class Card : ScriptableObject 
// This lets us quickly make new cards by when
// in project hierarchy going assets->scripts->cards.
// Right click and you will see cards in the menu in the hover menu!!
{
	public int cardID;
	public string cardName;
	public CardSprite sprite;
	public string leftQuote;
	public string rightQuote;
    public string dialogue;  
    public string cardPrompt;

    public void Left()
    {
    	Debug.Log(cardName + " swiped left");

    }

    public void Right()
    {
    	Debug.Log(cardName + " swiped right");
    }
}
