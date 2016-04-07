using UnityEngine;
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
        
        internal void Shoot(Direction dir)
        {
            switch (dir)
            {
                case Direction.Left: Rotate_Left(); break;
                case Direction.Up: Rotate_Up(); break;
                case Direction.Right: Rotate_Right(); break;
                case Direction.Down: Rotate_Down(); break;
                default: break;
            }
        }
        
        private void Rotate_Left()
        {
           LeanTween.rotateZ (Game_C.Instance.playerTransf.gameObject, 90, 0.05f).setEase (LeanTweenType.easeInCubic).setOnComplete (Shoot_Left);
        }
        
        private void Shoot_Left()
        {
            RaycastHit2D hit = Physics2D.Raycast (Vector2.zero, Vector2.left, 32f, 1 << LayerMask.NameToLayer("Object"));

            if (hit.collider != null) 
            {
                CameraShake.Instance.Small_Shake ();
                Destroy (hit.collider.gameObject);
            }
        }
        
        private void Rotate_Up()
        {
            LeanTween.rotateZ (Controller.Game_C.Instance.playerTransf.gameObject, 0, 0.05f).setEase (LeanTweenType.easeInCubic).setOnComplete (Shoot_Up);
        }

        private void Shoot_Up()
        {
            RaycastHit2D hit = Physics2D.Raycast (Vector2.zero, Vector2.up, 32f, 1 << LayerMask.NameToLayer("Object"));

            if (hit.collider != null) 
            {
                CameraShake.Instance.Small_Shake ();
                Destroy (hit.collider.gameObject);
            }
        }

        private void Rotate_Down()
        {
            LeanTween.rotateZ (Controller.Game_C.Instance.playerTransf.gameObject, 180, 0.05f).setEase (LeanTweenType.easeInCubic).setOnComplete (Shoot_Down);
        }

        private void Shoot_Down()
        {
            RaycastHit2D hit = Physics2D.Raycast (Vector2.zero, Vector2.down, 32f, 1 << LayerMask.NameToLayer("Object"));

            if (hit.collider != null) 
            {
                CameraShake.Instance.Small_Shake ();
                Destroy (hit.collider.gameObject);
            }
        }

        private void Rotate_Right()
        {
            LeanTween.rotateZ (Controller.Game_C.Instance.playerTransf.gameObject, 270, 0.05f).setEase (LeanTweenType.easeInCubic).setOnComplete (Shoot_Right);
        }

        private void Shoot_Right()
        {
            RaycastHit2D hit = Physics2D.Raycast (Vector2.zero, Vector2.right, 32f, 1 << LayerMask.NameToLayer("Object"));

            if (hit.collider != null) 
            {
                CameraShake.Instance.Small_Shake ();
                Destroy (hit.collider.gameObject);
            }
        }
    }
}