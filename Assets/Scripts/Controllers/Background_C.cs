using UnityEngine;
using System.Collections;

namespace Controller
{
    public class Background_C : MonoBehaviour 
    {
        private static Background_C instance;
        
        public SpriteRenderer sprRnd_bg;
        
        private Sprite spr_bg_red;
        private Sprite spr_bg_yellow;
        private Sprite spr_bg_blue;
        
        private Enums.Color enum_color;
        
        void Awake()
        {
            instance = this;
        }

        // Use this for initialization
        void Start () 
        {
            enum_color = Enums.Color.Red;
            Load_Sprites();
        }
        
        public void Change_Color()
        {
            int new_color_value = 1;
            
            do
            {
                new_color_value = Random.Range(1,4);
            } 
            while ((int)enum_color == new_color_value);
            
            enum_color = (Enums.Color)new_color_value;
            
            switch (enum_color)
            {
                case Enums.Color.Blue: sprRnd_bg.sprite = spr_bg_blue; break;
                case Enums.Color.Red: sprRnd_bg.sprite = spr_bg_red; break;
                case Enums.Color.Yellow: sprRnd_bg.sprite = spr_bg_yellow; break;
                default: break;
            }
        }
        
        public void Change_Color(Enums.Color color)
        {
            enum_color = color;
            
            switch (color)
            {
                case Enums.Color.Blue: sprRnd_bg.sprite = spr_bg_blue; break;
                case Enums.Color.Red: sprRnd_bg.sprite = spr_bg_red; break;
                case Enums.Color.Yellow: sprRnd_bg.sprite = spr_bg_yellow; break;
                default: break;
            }
        }
        
        public Enums.Color Ask_For_Color()
        {
            return enum_color;
        }
        
        public bool Ask_For_Color(Enums.Color color)
        {
            return enum_color == color;
        }
        
        private void Load_Sprites()
        {
            spr_bg_red = Resources.Load<Sprite>("Sprites/Environment/spr_bg_red");
            spr_bg_yellow = Resources.Load<Sprite>("Sprites/Environment/spr_bg_yellow");
            spr_bg_blue = Resources.Load<Sprite>("Sprites/Environment/spr_bg_blue");
        }
        
        public static Background_C Instance
        {
            get { return instance; }
        }
    }
}