using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Reward
    {
        public enum InfoField { Title, Description }

        public Reward() { }
        public Reward(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public string[] GetFieldsValues()
        {
            return new string[] { ID.ToString(), Title, Description };
        }
        public static string[] GetFieldsNames()
        {
            return new string[] { nameof(ID), nameof(Title), nameof(Description) };
        }
    }
}
