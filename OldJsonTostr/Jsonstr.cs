using Abstractions;
using Newtonsoft.Json;

namespace OldJsonTostr
{
    public class Jsonstr : Ijsonstr
    {
        public string JsonToStr<T>(T p)
        {
            return JsonConvert.SerializeObject(p);
        }
    }
}