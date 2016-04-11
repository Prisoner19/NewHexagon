using UnityEngine;
using System.Collections;
using Enums;
using Controller;

namespace Player
{
    public class Shooting : MonoBehaviour 
    {
        private Model obj_model;
        
        private Direction new_direction;
        
        internal void Set_Model(Model m)
        {
            obj_model = m;
        }
        
        internal void Start_To_Shoot(Direction dir)
        {
            Rotate(dir);
        }
        
        private void Rotate(Direction dir)
        {
            new_direction = dir;
            LeanTween.rotateZ (gameObject, Helper.Direction_To_Angles(dir), 0.05f).setEase (LeanTweenType.easeInCubic).setOnComplete (Execute_Shooting);
        }
        
        private void Execute_Shooting()
        {
            obj_model.Change_Facing_Direction(new_direction);
            RaycastHit2D hit = Physics2D.Raycast (Vector2.zero, Helper.Direction_To_Vector2(new_direction), 32f, 1 << LayerMask.NameToLayer("Mover"));

            if (hit.collider != null) 
            {
                CameraShake.Instance.Small_Shake ();
                Destroy (hit.collider.gameObject);
                obj_model.Increase_Score();
                Controller.GUI_C.Instance.Set_Score();
            }
        }
    }
}