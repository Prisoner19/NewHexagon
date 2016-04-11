using UnityEngine;
using Enums;

namespace Mover
{
    public class Movement : MonoBehaviour 
    {
        private Model obj_model;
        
        private float speed;
        private Rigidbody2D comp_rb2d;
        private Vector2 v2_dir;

        void Awake()
        {
            comp_rb2d = GetComponent<Rigidbody2D>();
        }
        
        // Update is called once per frame
        void Update () 
        {
            Update_Speed();
        }
        
        private void Update_Speed()
        {
            comp_rb2d.velocity = v2_dir * speed * Controller.Game_C.Instance.speedFactor;
        }
        
        internal void Set_Model(Model m)
        {
            obj_model = m;
        }
        
        internal void Set_Initial_Position(Direction dir)
        {
            switch (dir)
            {
                case Direction.Left:  transform.SetPositionXY(-36,0); break;
                case Direction.Up:    transform.SetPositionXY(0,36); break;
                case Direction.Right: transform.SetPositionXY(36,0); break;
                case Direction.Down:  transform.SetPositionXY(0,-36); break;
                default: break;
            }
            
            v2_dir = Helper.Get_Movement_Direction_From(dir);
        }
        
        internal void Set_Speed(float speed)
        {
            this.speed = speed;
        }
    }
}
