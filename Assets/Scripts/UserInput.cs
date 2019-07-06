using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UserInput : MonoBehaviour
{
    public GameObject slot1;
    private FreeCell freeCell;

    // Start is called before the first frame update
    void Start()
    {
        freeCell = FindObjectOfType<FreeCell>();
        slot1 = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseClick();
    }

    void GetMouseClick()
    {
        if (Input.GetMouseButtonDown(0)){

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, 
                        Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(
                    Camera.main.ScreenToWorldPoint(Input.mousePosition),
                    Vector2.zero);
            if (hit){
                // what has been hit? Deck/Card/EmptySlot...
                if (hit.collider.CompareTag("Card"))
                {
                    print(hit.collider.gameObject.ToString());
                    // clicked card
                    Card(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("FreeCell"))
                {
                    // clicked freecell
                    FreeCell(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("HomeCell"))
                {
                    // clicked homecell
                    HomeCell(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("EmptyPos"))
                {
                    // clicked empty position
                    EmptyPos(hit.collider.gameObject);
                }
            }
        } 
    }


    void Card(GameObject selected)
    {
        // card click actions
        print("Clicked on Card");


        // if there is no card currently selected
        // select the card
        if(slot1 == this.gameObject){
            slot1 = selected;
        // if there is already a card selected (and it is not the same card)
        }else if (slot1 != selected){
            // if the new card eligable to stack on the old card
            if (Stackable(selected)){ // stack it
                Stack(selected);
            } else { // else select the new card
                slot1 = selected;
            }
        }
    }
    void FreeCell(GameObject selected)
    {
        // freecell click actions
        print("Clicked on FreeCell");
        if(slot1.CompareTag("Card")){
            Stack(selected);
        }
    }
    void HomeCell(GameObject selected)
    {
        // homecell click actions
        print("Clicked on HomeCell");
        if (slot1.CompareTag("Card")){
            // if the card is an ace and the empty slot is top then stack
            if (slot1.GetComponent<Selectable>().value == 1){
                Stack(selected);
            }
        }

    }
    void EmptyPos(GameObject selected)
    {
        // EmptyPos click actions
        print("Clicked on Empty Position");
        // if the card is a kink and the empty slot is bottom then stack
        if (slot1.CompareTag("Card")){
            Stack(selected);
        }

    }

    bool Stackable(GameObject selected){
        Selectable s1 = slot1.GetComponent<Selectable>();
        Selectable s2 = selected.GetComponent<Selectable>();
        // compare them to see if they stack

        if (s2.top){ //if in the top pile must stack suited Ace to King
            if (s1.suit == s2.suit || (s1.value == 1 && s2.suit == null)){
                if (s1.value == s2.value + 1){
                    return true;
                } 
            }else {
                return false;
            }
        } else { // if in the bottom pile must stack alternate colours King to Ace
            if (s1.value == s2.value - 1){
                bool card1Red = true;
                bool card2Red = true;

                if(s1.suit == "C" || s1.suit == "S"){
                    card1Red = false;
                }
                if(s2.suit == "C" || s2.suit == "S"){
                    card2Red = false;
                }
                if(card1Red == card2Red){
                    print("Not stackable");
                    return false;
                }else {
                    print("Stackable");
                    return true;
                }
            }
        }
            return false;
    }

    void Stack(GameObject selected){

        Selectable s1 = slot1.GetComponent<Selectable>();
        Selectable s2 = selected.GetComponent<Selectable>();
        float yOffset = 0.6f;


        // if on top of king or empty bottom stack the cards in place
        // else stack the cards with a negative y offset
        if(s2.top || (!s2.top && s1.value == 13)){
            yOffset = 0;
        }
        slot1.transform.position = new Vector3(selected.transform.position.x,
                selected.transform.position.y - yOffset,
                selected.transform.position.z - 0.03f);
        slot1.transform.parent = selected.transform; // this makes the children move with the parents

        if(s1.top && s2.top && s1.value == 1){
            freeCell.homeCellPos[s1.row].GetComponent<Selectable>().value = 0;
            freeCell.homeCellPos[s1.row].GetComponent<Selectable>().suit = null;
        } else if (s1.top){
            freeCell.homeCellPos[s1.row].GetComponent<Selectable>().value = s1.value - 1;
        } else {
            freeCell.tableaus[s1.row].Remove(slot1.name);
        }

        s1.row = s2.row;

        if(s2.top){ // moves a card to the top and assigns the top's value and suit
            freeCell.homeCellPos[s1.row].GetComponent<Selectable>().value = s1.value;
            freeCell.homeCellPos[s1.row].GetComponent<Selectable>().suit = s1.suit;
            s1.top = true;
        } else {
            s1.top = false;
        }

        // after completing move reset slot1 to be essentially null as being null will break the logic
        slot1 = this.gameObject;
    }

    bool Blocked(GameObject selected){
        Selectable s2 = selected.GetComponent<Selectable>();
        if (s2.name == freeCell.tableaus[s2.row].Last()){
            return false;
        } else {
            return true;
        }
    }
}

