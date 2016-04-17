using UnityEngine;
using System.Collections;

namespace Controller
{
    public class GUI_C : MonoBehaviour 
    {
        private static GUI_C instance;
        
        private GameObject go_score_tens;
        private GameObject go_score_units;
        
        void Awake()
        {
            instance = this;
            
            go_score_tens = null;
            go_score_units = null;
        }
        
        // Update is called once per frame
        void Update () 
        {
        
        }
        
        public void Set_Score()
        {
            if(go_score_tens == null || go_score_units == null)
            {
                go_score_tens = GameObject.Find("Tens");
                go_score_units = GameObject.Find("Units");
            }
            
            int score_tens = Game_C.Instance.Get_Player_Object().Ask_For_Score() / 10;
            int score_units = Game_C.Instance.Get_Player_Object().Ask_For_Score() % 10;
            
            go_score_tens.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Score/spr_" + score_tens);
            go_score_units.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Score/spr_" + score_units);
        }
       
        public static GUI_C Instance 
        {
            get { return instance; }
        }
    }

}
