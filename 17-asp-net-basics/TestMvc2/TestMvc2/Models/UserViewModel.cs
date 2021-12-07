using System;
using System.Collections.Generic;
using System.Linq;

namespace TestMvc2.Models
{
	public class UserViewModel
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public DateTime Birthdate { get; set; }

		public List<Reward> Rewards { get; set; }
		
		public List<RewardViewModel> AvailableRewards { get; set; }

		public User ToUser()
		{
			return new User
			{
				Id = Id,
				FirstName = FirstName,
				LastName = LastName,
				Birthdate = Birthdate,
				Rewards = AvailableRewards
					.Where(r => r.Checked == true)
					.Select(r => new Reward
					{
						Id = r.Id,
						Title = r.Title,
						Description = r.Description
					}).ToList()
			};
		}
		public static UserViewModel GetViewModel(User user, List<Reward> availableRewards)
		{
			var userModel = new UserViewModel();
			userModel.Id = user.Id;
			userModel.FirstName = user.FirstName;
			userModel.LastName = user.LastName;
			userModel.Birthdate = user.Birthdate;
			userModel.Rewards = user.Rewards;
			var rewards = new List<RewardViewModel>();
			foreach (var reward in availableRewards)
			{
				rewards.Add(RewardViewModel.GetViewModel(reward, user.Rewards));
			}

			userModel.AvailableRewards = rewards.ToList();
			return userModel;
		}
	}
}