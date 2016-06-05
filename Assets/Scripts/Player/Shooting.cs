using UnityEngine;
using System.Collections;
using Enums;
using Controller;

namespace Player
{
    public class Shooting : MonoBehaviour 
    {
        private Model obj_model;

        public Object pfb_shot;

        void Start()
        {
            pfb_shot = Resources.Load<Object>("Prefabs/pfb_shot");
        }

        internal void Set_Model(Model m)
        {
            obj_model = m;
        }
        
        internal void Start_To_Shoot(Direction dir)
        {
            Rotate(dir);
            Execute_Shooting(dir);
        }
        
        private void Rotate(Direction dir)
        {
            gameObject.transform.RotateZ(Helper.Direction_To_Angles(dir));
        }

        private void Execute_Shooting(Direction dir)
        {
            obj_model.Change_Facing_Direction(dir);
            RaycastHit2D hit = Physics2D.Raycast (Vector2.zero, Helper.Direction_To_Vector2(dir), 32f, 1 << LayerMask.NameToLayer("Mover"));
            Instantiate_Shot_Prefab(dir);

            if (hit.collider != null) 
            {
                Event_C.Instance.On_Mover_Destroyed(hit.collider.gameObject, obj_model);
            }
        }

        private void Instantiate_Shot_Prefab(Direction dir)
        {
            GameObject goShot = Instantiate(pfb_shot) as GameObject;

            goShot.SetPositionZ(-1);
            
            switch (dir)
            {
                case Direction.Left: goShot.SetPositionXY(-16,0); goShot.transform.RotateZ(90); break;
                case Direction.Up: goShot.SetPositionXY(0,17); goShot.transform.RotateZ(0); break;
                case Direction.Right: goShot.SetPositionXY(17,1); goShot.transform.RotateZ(270); break;
                case Direction.Down: goShot.SetPositionXY(1,-16); goShot.transform.RotateZ(180); break;
            }
            
        }
    }
}