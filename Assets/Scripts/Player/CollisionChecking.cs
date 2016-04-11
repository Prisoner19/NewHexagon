using UnityEngine;
using System.Collections;

namespace Player
{
    public class CollisionChecking : MonoBehaviour 
    {
        private Model obj_model;
        
        void Awake()
        {

        }

        internal void Set_Model(Model m)
        {
            obj_model = m;
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            Mover.Model obj_mover = other.gameObject.GetComponent<Mover.Model>();
            Enums.MoverType type;
             
            if(obj_model != null)
            {
               type = obj_mover.Ask_For_MoverType();
               
               if(type == Enums.MoverType.Enemy)
               {
                   CameraShake.Instance.Big_Shake();
               }
               
               obj_mover.Get_Killed();
            }
        }
    }  
}

