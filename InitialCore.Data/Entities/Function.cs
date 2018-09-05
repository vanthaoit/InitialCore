﻿using System.ComponentModel.DataAnnotations;
using InitialCore.Data.Enums;
using InitialCore.Data.Interfaces;
using InitialCore.Infrastructure.SharedKernel;

namespace InitialCore.Data.Entities
{
	public class Function : DomainEntity<string>, ISwitchable, ISortable
	{
		public Function()
		{
		}

		public Function(string name, string url, string parentId, string iconCss, int sortOrder)
		{
			this.Name = name;
			this.URL = url;
			this.ParentId = parentId;
			this.IconCss = iconCss;
			this.SortOrder = sortOrder;
			this.Status = Status.Active;
		}

		[Required]
		[StringLength(128)]
		public string Name { set; get; }

		[Required]
		[StringLength(250)]
		public string URL { set; get; }

		[StringLength(128)]
		public string ParentId { set; get; }

		public string IconCss { get; set; }

		public int SortOrder { set; get; }

		public Status Status { set; get; }
	}
}