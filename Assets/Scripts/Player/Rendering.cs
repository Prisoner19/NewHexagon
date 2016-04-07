using UnityEngine;

namespace Player
{
    public class Rendering : MonoBehaviour 
    {
        private Model obj_model;
        
        private SpriteRenderer sprRnd;
        
        void Awake()
        {

        }

        internal void Set_Model(Model m)
        {
            obj_model = m;
        }
    } 
}

