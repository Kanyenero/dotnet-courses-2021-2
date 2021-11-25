using System;
using System.Collections.Generic;
using System.Text;

namespace WinForms
{
    public class Reward
    {
        private string title;
        private string description;

        public Reward() { }
        public Reward(string title, string description)
        {
            this.title = title;
            this.description = description;
        }

        public int ID { get; set; }
        public string Title 
        { 
            get { return title; } 
            set { title = value; } 
        }
        public string Description 
        { 
            get { return description; } 
            set { description = value; } 
        }
    }
}
