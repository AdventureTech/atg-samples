using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleISeriesSubSonic
{
	class Program
	{
		static void Main(string[] args)
		{
			//setup a repository... disable migrations
			var repo = new SubSonic.Repository.SimpleRepository("Default", SubSonic.Repository.SimpleRepositoryOptions.None);

			var newItem = new Data.SmpAcct()
			{
				Acctnbr = 123,
				Cmpny = "Widget Inc",
				Desc = "test",
				Name = "test"
			};

			//insert a new item.
			repo.Add(newItem);


			//perform an update. 
			newItem.Desc = "just another test.";
			repo.Update(newItem); 

			//get record for acct# 123 using Lambda
			var item = repo.All<Data.SmpAcct>().Where(o => o.Acctnbr == 123).FirstOrDefault();

			//do the same thing, but with LINQ
			item = (from acct in repo.All<Data.SmpAcct>()
					 where acct.Acctnbr == 123
					 select acct).FirstOrDefault();


			//basic inner join
			var list = (from acct in repo.All<Data.SmpAcct>()
						  join detail in repo.All<Data.AccountDetail>() on acct.Acctnbr equals detail.Acctnbr
						  where acct.Cmpny == "Widget Inc"
						  select new
						  {
							  Account = acct,
							  Detail = detail
						  }).ToList();

			foreach (var account in list)
			{
//				account.Account.Cmpny 
			}
			

			//clever WHERE IN (a,b,...)
			decimal[] ids = new decimal[] { 123M, 1M, 2M, 3M, 4M, 5M }; //MUST use array for this to work
			var list2 = (from acct in repo.All<Data.SmpAcct>()
					  where ids.Contains(acct.Acctnbr) //translates to WHERE IN (123,1,2,3,4,5)
							 select acct).ToList(); ;

			//delete the item
			if (item != null)
				repo.Delete<Data.SmpAcct>(item.Acctnbr);
		}
	}
}
