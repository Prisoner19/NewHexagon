using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Player
{
    public class CollisionChecking : MonoBehaviour 
    {
        private Model obj_model;
        
        void Awake()
        {

        }
        
        void Update()
        {
            Check_Collision_With_Movers();
        }

        internal void Set_Model(Model m)
        {
            obj_model = m;
        }
        
        private void Check_Collision_With_Movers()
        {
            GameObject[] array_movers = GameObject.FindGameObjectsWithTag("Mover");
            
            foreach(GameObject go in array_movers)
            {
                float difX = Mathf.Abs(go.GetPositionX() - transform.position.x);
                float difY = Mathf.Abs(go.GetPositionY() - transform.position.y);
                
                if(difX < 5 && difY < 5)
                {
                    Collide_With_Mover(go);
                }
            }
        }
        
        private void Collide_With_Mover(GameObject go_mover)
        {
            Mover.Model obj_mover = go_mover.GetComponent<Mover.Model>();
            Enums.MoverType type;
            
            if(obj_mover != null)
            {
               type = obj_mover.Ask_For_MoverType();
               
               if(type == Enums.MoverType.Enemy)
               {
                   CameraShake.Instance.Big_Shake();
               }
               else
               {
                   
               }
               obj_mover.Get_Killed();
            }
        }
    }  
}

