using System.Collections.Generic;
using System.Linq;

namespace TestMvc2.Models
{
	public class RewardViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; }
		public string Description { get; set; }

		public bool Checked { get; set; }

		public static RewardViewModel GetViewModel(Reward reward, List<Reward> userRewards)
		{
			var model = new RewardViewModel();
			model.Id = reward.Id;
			model.Title = reward.Title;
			model.Description = reward.Description;
			model.Checked = userRewards.Any(r => r.Id == reward.Id);
			return model;
		}
	}
}