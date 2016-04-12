using UnityEngine;

namespace Controller
{
    public class Event_C : MonoBehaviour 
    {
        private static Event_C instance;
        
        void Awake()
        {
            instance = this;
        }
        
        public void On_Mover_Destroyed(GameObject go_mover, Player.Model obj_player)
        {
            Enums.MoverType type = go_mover.GetComponent<Mover.Model>().Ask_For_MoverType();
            Destroy (go_mover);
            
            if(type == Enums.MoverType.Friend)
            {
                CameraShake.Instance.Big_Shake();
                obj_player.Decrease_Score();
            }
            else
            {
                CameraShake.Instance.Small_Shake();
                obj_player.Increase_Score();
            }
            
            Controller.GUI_C.Instance.Set_Score();
        }
        
        public static Event_C Instance
        {
            get { return instance; }
        }
    }

}
