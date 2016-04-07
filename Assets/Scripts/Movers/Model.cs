using UnityEngine;
using System.Collections;
using System;

namespace Mover
{
    public class Model : MonoBehaviour 
    {
        private Movement obj_movement;
        private Rendering obj_rendering;
        
        private Enums.Color enum_color;
        
        void Awake()
        {
             Get_Component_References();
        }
        
        void Start () 
        {
           
        }

        private void Get_Component_References()
        {
            obj_movement = gameObject.GetComponent<Movement>();
            obj_rendering = gameObject.GetComponent<Rendering>();
            
            obj_movement.Set_Model(this);
            obj_rendering.Set_Model(this);
        }

        // Update is called once per frame
        void Update () 
        {
        
        }
        
        public void Change_Color(Enums.Color color)
        {
            enum_color = color;
            obj_rendering.Change_Color(color);
        }
        
        public void Get_Killed()
        {
            Destroy(this.gameObject);
        }
        
        public bool Check_Color(Enums.Color color)
        {
            return enum_color == color;
        }
    }
}

