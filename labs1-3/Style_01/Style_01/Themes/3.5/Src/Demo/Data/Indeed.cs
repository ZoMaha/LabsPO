using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.IO;

namespace Demo.Data
{
	[DataContract]
	public class Indeed
	{
		[DataMember]
		public string JobKey { get; set; }
		[DataMember]
		public string JobTitle { get; set; }
		[DataMember]
		public string Company { get; set; }
        [DataMember]
        public string Location { get; set; }
		[DataMember]
		public string Source { get; set; }
		[DataMember]
		public string Date { get; set; }
		[DataMember]
		public string Url { get; set; }
		[DataMember]
		public string OnMouseDown { get; set; }
        public string Snippet { get; set; }				
	}
    public class IndeedList : ObservableCollection<Indeed>
    {
        public IndeedList()
        {
			Stream stream;
            using (stream = GetResourceStream("IndeedList.xml"))
            {
                var serializer = new DataContractSerializer(typeof(List<Indeed>));
                var list = serializer.ReadObject(stream) as List<Indeed>;
                foreach (var indeed in list)
                    Add(indeed);
            }
        }

		public static Stream GetResourceStream(string fileName)
		{
			Stream stream;
			string location = string.Format("{0}.{1}", typeof(IndeedList).Namespace, fileName);
			stream = typeof(IndeedList).Assembly.GetManifestResourceStream(location);			
			return stream;
		}

    }
}
