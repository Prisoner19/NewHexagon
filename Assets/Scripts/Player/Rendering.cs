using UnityEngine;
using System.Collections;

namespace Player
{
    public class Rendering : MonoBehaviour 
    {
        private Model obj_model;
        
        private SpriteRenderer sprRnd;
        
        // Use this for references
        void Awake()
        {

        }

        // Use this for initialization
        void Start () 
        {
        
        }
        
        // Update is called once per frame
        void Update () 
        {
        
        }
        
        internal void Set_Model(Model m)
        {
            obj_model = m;
        }
    } 
}

