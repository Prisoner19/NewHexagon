using UnityEngine;
using Controller;
using Enums;

namespace Mover
{
    public class Model : MonoBehaviour 
    {
        private Movement obj_movement;
        private Rendering obj_rendering;
        
        private Enums.Color enum_color;
        private Enums.MoverType enum_type;
        
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
        
        public void Initialize(Enums.MoverType type, string dir, float speed)
        {   
            enum_type = type;
            
            Enums.Color bg_color = Background_C.Instance.Ask_For_Color();
            Enums.Color mover_color = (type == MoverType.Enemy) ? bg_color : Helper.Get_Color_Different_From(bg_color);
            enum_color = mover_color;
            
            obj_rendering.Change_Color(mover_color);
            obj_movement.Set_Speed(speed);
            obj_movement.Set_Initial_Position(Helper.String_To_Direction(dir));
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
        
        public Enums.Color Ask_For_Color()
        {
            return enum_color;
        }
        
        public Enums.MoverType Ask_For_MoverType()
        {
            return enum_type;
        }
        
        public bool Check_Color(Enums.Color color)
        {
            return enum_color == color;
        }
    }
}

