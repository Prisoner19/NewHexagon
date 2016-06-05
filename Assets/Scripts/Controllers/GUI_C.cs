using UnityEngine;
using System.Collections;

namespace Controller
{
    public class GUI_C : MonoBehaviour 
    {
        private static GUI_C instance;
        
        private GameObject go_timer_tens;
        private GameObject go_timer_units;
        
        private GameObject go_indication;
        
        void Awake()
        {
            instance = this;
            
            go_timer_tens = null;
            go_timer_units = null;
            
            go_indication = null;
        }
        
        // Update is called once per frame
        void Update () 
        {
            Update_Timer();
        }
        
        public void Update_Timer()
        {
            if(go_timer_tens == null || go_timer_units == null)
            {
                go_timer_tens = GameObject.Find("Tens");
                go_timer_units = GameObject.Find("Units");
            }
            
            int timer_tens = Mathf.FloorToInt(Game_C.Instance.timer / 10);
            int timer_units = Mathf.FloorToInt(Game_C.Instance.timer % 10);
            
            go_timer_tens.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Timer/spr_" + timer_tens);
            go_timer_units.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Timer/spr_" + timer_units);

            Debug.Log(timer_tens + "" + timer_units);
        }
        
        public void Hide_Indication()
        {
            go_indication = GameObject.Find("Indication");
            
            LeanTween.alpha(go_indication, 0, 2);
        }
       
        public static GUI_C Instance 
        {
            get { return instance; }
        }
    }

}
