using UnityEngine;
using System.Collections;
using Enums;
using Controller;

namespace Player
{
    public class Shooting : MonoBehaviour 
    {
        private Model obj_model;
        
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

            if (hit.collider != null) 
            {
                Event_C.Instance.On_Mover_Destroyed(hit.collider.gameObject, obj_model);
            }
        }
    }
}