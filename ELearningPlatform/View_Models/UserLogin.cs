﻿using System.ComponentModel.DataAnnotations;

namespace ELearningPlatform.View_Models
{
	public class UserLogin
	{
		public string UserName { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public string Email { get; set; }
		public bool RememberMe {  get; set; }
	}
}
