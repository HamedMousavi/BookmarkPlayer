using System.Text.Json.Serialization;


namespace MemoRun.Windows.Desktop.Actors
{

    public interface IPersistSerializer
    {
        object Serialize(object plain);
        T Deserialize<T>(object serialized);
    }


    public class JsonPersistSerializer : IPersistSerializer
    {
        public T Deserialize<T>(object serialized)
        {
            return JsonSerializer.Parse<T>((string)serialized);
        }

        public object Serialize(object plain)
        {
            return JsonSerializer.ToString(plain);
        }
    }
}
