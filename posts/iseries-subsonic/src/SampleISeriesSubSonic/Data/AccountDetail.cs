using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.SqlGeneration.Schema;

namespace SampleISeriesSubSonic.Data
{
	//notice we can use a different class name. The table name override will allow 
	//the SQL generation to work properly. 
	[SubSonicTableNameOverride("ACCTDET")]
	public partial class AccountDetail 
	{
		[SubSonicPrimaryKey]
		public decimal Acctnbr { get; set; }
		public string LongDesc { get; set; }
	}
}
