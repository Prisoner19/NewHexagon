using UnityEngine;
using System.Collections;
using Enums;

public static class Helper
{
    public static Direction String_To_Direction(string dir)
    {
        dir = dir.ToLower();
        
        switch (dir)
        {
            case "left": return Direction.Left;
            case "up": return Direction.Up;
            case "right": return Direction.Right;
            case "down": return Direction.Down;
            default: return Direction.None;
        }
    }
    
    public static MoverType String_To_MoverType(string dir)
    {
        dir = dir.ToLower();
        
        switch (dir)
        {
            case "enemy": return MoverType.Enemy;
            case "friend": return MoverType.Friend;
        }
        
        return MoverType.Enemy;
    }
    
    public static Enums.Color Get_Color_Different_From(Enums.Color color)
    {
        Enums.Color new_color;
        
        do
        {
            new_color = Get_Random_Color();
        } 
        while (new_color == color);
        
        return new_color;
    }
    
    public static Enums.Color Get_Random_Color()
    {
        int rand_value = 0;
        int enum_count = System.Enum.GetNames(typeof(Enums.Direction)).Length;
        
        rand_value = Random.Range(0, enum_count);
        
        return (Enums.Color)System.Enum.GetValues(typeof(Enums.Direction)).GetValue(rand_value);
    }
    
    public static Vector2 Get_Movement_Direction_From(Direction origin)
    {
        switch (origin)
        {
            case Direction.Left: return Vector2.right;
            case Direction.Up: return Vector2.down;
            case Direction.Right: return Vector2.left;
            case Direction.Down: return Vector2.up;
            default: return Vector2.zero;
        }
    }
}
