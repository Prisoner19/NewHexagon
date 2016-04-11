using UnityEngine;
using System.Collections;

namespace Controller
{
    public class GUI_C : MonoBehaviour 
    {
        private static GUI_C instance;
        
        private GameObject go_score;
        
        void Awake()
        {
            instance = this;
        }
        
        // Update is called once per frame
        void Update () 
        {
        
        }
        
        public void Set_Score()
        {
            go_score = GameObject.Find("Score");
            
            if(go_score != null)
            {
                int score = Game_C.Instance.Get_Player_Object().Ask_For_Score();
                go_score.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Score/spr_" + score);
            }
        }
       
        public static GUI_C Instance 
        {
            get { return instance; }
        }
    }

}
