using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.SqlGeneration.Schema;

namespace SampleISeriesSubSonic.Data
{
	//using table name override to avoid pluralized translation to SQL.  Default would be: SMPTACCTS
	[SubSonicTableNameOverride("SMPACCT")]
	public partial class SmpAcct
	{
		[SubSonicPrimaryKey]
		public decimal Acctnbr { get; set; }
		public string Name { get; set; }
		public string Cmpny { get; set; }
		public string Desc { get; set; }
	}
}
