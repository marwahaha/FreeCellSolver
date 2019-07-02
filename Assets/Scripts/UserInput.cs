using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UserInput : MonoBehaviour
{
    public GameObject selected;
    private FreeCell freeCell;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, 
                        Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(
                    Camera.main.ScreenToWorldPoint(Input.mousePosition),
                    Vector2.zero);
            if (hit)
            {
                // what has been hit? Deck/Card/EmptySlot...
                if (hit.collider.CompareTag("Card"))
                {
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
        } else if (Input.GetKeyDown(KeyCode.Keypad1) 
                || Input.GetKeyDown(KeyCode.Alpha1)){
                    // clicked card
                    Card();
        } else if (Input.GetKeyDown(KeyCode.Keypad2) 
                || Input.GetKeyDown(KeyCode.Alpha2)){
                    // clicked card
                    Card();
        } else if (Input.GetKeyDown(KeyCode.Keypad3) 
                || Input.GetKeyDown(KeyCode.Alpha3)){
                    // clicked card
                    Card();
        } else if (Input.GetKeyDown(KeyCode.Keypad4) 
                || Input.GetKeyDown(KeyCode.Alpha4)){
                    // clicked card
                    Card();
        } else if (Input.GetKeyDown(KeyCode.Keypad5) 
                || Input.GetKeyDown(KeyCode.Alpha5)){
                    // clicked card
                    Card();
        } else if (Input.GetKeyDown(KeyCode.Keypad6) 
                || Input.GetKeyDown(KeyCode.Alpha6)){
                    // clicked card
                    Card();
        } else if (Input.GetKeyDown(KeyCode.Keypad7) 
                || Input.GetKeyDown(KeyCode.Alpha7)){
                    // clicked card
                    Card();
        } else if (Input.GetKeyDown(KeyCode.Keypad8) 
                || Input.GetKeyDown(KeyCode.Alpha8)){
                    // clicked card
                    Card();
        } else if (Input.GetKeyDown(KeyCode.A)){
                    // clicked homecell
                    HomeCell();
        } else if (Input.GetKeyDown(KeyCode.S)){
                    // clicked homecell
                    HomeCell();
        } else if (Input.GetKeyDown(KeyCode.D)){
                    // clicked homecell
                    HomeCell();
        } else if (Input.GetKeyDown(KeyCode.F)){
                    // clicked homecell
                    HomeCell();
        } else if (Input.GetKeyDown(KeyCode.J)){
                    // clicked freecell
                    FreeCell();
        } else if (Input.GetKeyDown(KeyCode.K)){
                    // clicked freecell
                    FreeCell();
        } else if (Input.GetKeyDown(KeyCode.L)){
                    // clicked freecell
                    FreeCell();
        } else if (Input.GetKeyDown(KeyCode.Semicolon)){
                    // clicked freecell
                    FreeCell();
        }
    }

    void Card(GameObject selected = null)
    {
        // card click actions
        print("Clicked on Card");
    }
    void FreeCell(GameObject selected = null)
    {
        // freecell click actions
        print("Clicked on FreeCell");
    }
    void HomeCell(GameObject selected = null)
    {
        // homecell click actions
        print("Clicked on HomeCell");

    }
    void EmptyPos(GameObject selected = null)
    {
        // EmptyPos click actions
        print("Clicked on Empty Position");

    }
}

