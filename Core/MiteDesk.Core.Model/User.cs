﻿namespace SixtyNineDegrees.MiteDesk.Core.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
