using UnityEngine;
using Enums;

namespace Controller
{
    public class Input_C : MonoBehaviour 
    {
        private static Input_C instance;
        
        void Awake()
        {
            instance = this;
        }

        void Start () 
        {
        
        }
        
        void Update () 
        {
            Check_For_Input();
        }
        
        private void Check_For_Input()
        {
            Check_For_Keyboard_Input();
        }

        private void Check_For_Keyboard_Input()
        {
            if (InputTracker.Has_Pressed_Key(KeyCode.A) || InputTracker.Has_Pressed_Key(KeyCode.LeftArrow))
			{
                Game_C.Instance.Get_Player_Object().Shoot(Direction.Left);
			} 
			else if (InputTracker.Has_Pressed_Key(KeyCode.W) || InputTracker.Has_Pressed_Key(KeyCode.UpArrow))
			{
				Game_C.Instance.Get_Player_Object().Shoot(Direction.Up);
			} 
			else if (InputTracker.Has_Pressed_Key(KeyCode.S) || InputTracker.Has_Pressed_Key(KeyCode.DownArrow))
			{
				Game_C.Instance.Get_Player_Object().Shoot(Direction.Down);
			} 
			else if (InputTracker.Has_Pressed_Key(KeyCode.D) || InputTracker.Has_Pressed_Key(KeyCode.RightArrow))
			{
				Game_C.Instance.Get_Player_Object().Shoot(Direction.Right);
			}
        }

        public static Input_C Instance
        {
            get { return instance; }
        }
    }
}