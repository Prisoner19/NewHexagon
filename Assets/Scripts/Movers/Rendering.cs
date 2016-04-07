using UnityEngine;
using System.Collections;
using Enums;
using System;

namespace Mover
{
    public class Rendering : MonoBehaviour 
    {
        private Model obj_model;
        
        private SpriteRenderer sprRnd;
        
        // Use this for references
        void Awake()
        {
               sprRnd = gameObject.GetComponent<SpriteRenderer>();
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

        internal void Change_Color(Enums.Color color)
        {
            switch (color)
            {
                case Enums.Color.Blue: sprRnd.sprite = Resources.Load<Sprite>("Sprites/spr_mover_blue"); break;
                case Enums.Color.Yellow: sprRnd.sprite = Resources.Load<Sprite>("Sprites/spr_mover_yellow"); break;
                case Enums.Color.Red: sprRnd.sprite = Resources.Load<Sprite>("Sprites/spr_mover_red"); break;
                default: break;
            }
        }
    }
}

