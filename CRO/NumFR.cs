using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CRO
{
	public partial class FrTitle
	{
		[JsonProperty("library_title")]
		public string LibraryTitle { get; set; }

		[JsonProperty("ean")]
		public string Ean { get; set; }

		[JsonProperty("order")]
		public string Order { get; set; }

		[JsonProperty("us_title")]
		public UsTitle[] UsTitle { get; set; }
	}

	public partial class UsTitle
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("title_name")]
		public string TitleName { get; set; }
	}


	public partial class FrTitle
	{
		public static FrTitle[] FromJson(string json)
		{
			return JsonConvert.DeserializeObject<FrTitle[]>(json, Converter.Settings);
		}
	}

	public static class Serialize
	{
		public static string ToJson(this FrTitle[] self)
		{
			return JsonConvert.SerializeObject(self, Converter.Settings);
		}
	}

	public class Converter
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		{
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
		};
	}
}
