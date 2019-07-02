using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private FreeCell freeCell;

    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = FreeCell.GenerateDeck();
        freeCell = FindObjectOfType<FreeCell>();

        int i = 0;
        foreach (string card in deck){
            if (this.name == card){
                cardFace = freeCell.cardFaces[i];
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = cardFace;
    }
}
