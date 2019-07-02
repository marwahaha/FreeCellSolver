using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FreeCell : MonoBehaviour {

        public Sprite[] cardFaces;
        public GameObject cardPrefab;
        public GameObject[] tableauPos;
        public GameObject[] homeCellPos;
        public GameObject[] freeCellPos;

        public static string[] suits = new string[] { "C", "D", "H", "S"};
        public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
        public List<string>[] tableaus;
        public List<string>[] homecells;
        public List<string>[] freecells;

        private List<string> pos0 = new List<string>();
        private List<string> pos1 = new List<string>();
        private List<string> pos2 = new List<string>();
        private List<string> pos3 = new List<string>();
        private List<string> pos4 = new List<string>();
        private List<string> pos5 = new List<string>();
        private List<string> pos6 = new List<string>();
        private List<string> pos7 = new List<string>();

        public List<string> deck;


	// Use this for initialization
	void Start () {
                tableaus = new List<string>[] {pos0, pos1, pos2, pos3, pos4, pos5, pos6, pos7 };
		PlayCards();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

        public void PlayCards(){
            deck = GenerateDeck();
            Shuffle(deck);

            //test the cards in the deck
            foreach(string card in deck){
                print(card);
            }
            FreeCellSort();
            StartCoroutine(FreeCellDeal());

        }

        public static List<string> GenerateDeck(){
            List<string> newDeck = new List<string>();

            foreach (string s in suits){
                foreach (string v in values){
                    newDeck.Add(s + v);
                }
            }

            return newDeck;
        }

        void Shuffle<T>(List<T> list){
            System.Random random = new System.Random();
            int n = list.Count;
            while (n > 1){
                int k = random.Next(n);
                n--;
                T temp = list[k];
                list[k] = list[n];
                list[n] = temp;
            }
        }

        IEnumerator FreeCellDeal(){
            for (int i = 0; i < 8; i++){
                float yOffset = 0;
                float zOffset = 0.03f;
                foreach (string card in tableaus[i]){
                    yield return new WaitForSeconds(0.03f);
                    GameObject newCard = Instantiate(cardPrefab,
                            new Vector3(
                                tableauPos[i].transform.position.x,
                                tableauPos[i].transform.position.y - yOffset,
                                tableauPos[i].transform.position.z - zOffset
                                ),
                            Quaternion.identity,tableauPos[i].transform);
                    newCard.name = card;

                    yOffset = yOffset + 0.6f;
                    zOffset = zOffset + 0.3f;
                }
            }
        }

        void FreeCellSort(){
            for (int i = 0; i < 52; i++){
                tableaus[i % 8].Add(deck.Last<string>());
                deck.RemoveAt(deck.Count - 1);
            }
        }

}


