using System;
using System.Collections.Generic;

using Entities;

namespace PersonsAndAwardsMVC.Models
{
    public class AwardViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Award ToAward()
        {
            return new Award
            {
                ID = ID,
                Title = Title,
                Description = Description
            };
        }

        public static AwardViewModel GetViewModel(Award item)
        {
            return new AwardViewModel
            {
                ID = item.ID,
                Title = item.Title,
                Description = item.Description
            };
        }
    }
}
