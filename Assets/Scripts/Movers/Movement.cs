using UnityEngine;
using Enums;

namespace Mover
{
    public class Movement : MonoBehaviour 
    {
        private Model obj_model;
        
        private float speed;
        private Vector2 v2_dir;
        
        private Vector3 v3_logic_position;

        void Start()
        {
            v3_logic_position = transform.position;
        }
        
        // Update is called once per frame
        void Update () 
        {
            Move();
        }
        
        private void Move()
        {
            v3_logic_position =  v3_logic_position + (Vector3)v2_dir * speed * Time.deltaTime * Controller.Game_C.Instance.speedFactor;
            
            float posX = Mathf.RoundToInt(v3_logic_position.x) + 0.5f;
            float posY = Mathf.RoundToInt(v3_logic_position.y) + 0.5f;
            
            transform.SetPositionXY(posX, posY);
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
