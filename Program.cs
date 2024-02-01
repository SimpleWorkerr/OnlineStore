using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using OnlineStore.Model;

namespace OnlineStore;

class Program
{
    private static OnlineStoreDbContext _dbContext = new OnlineStoreDbContext();

    private static void Main(string[] args)
    {
        //Метод выводящий информацию о считанных заказах на консоль в формате xml
        ReadObjectsFromFile("ResourcesXML/Orders.xml", (outerOrders) =>
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Order>));

            using var writer = new StringWriter();
                
            xmlSerializer.Serialize(writer, outerOrders);
            
            Console.WriteLine(writer.ToString());
        });
        //Метод добавляющий заказы из файла в базу данных
        ReadObjectsFromFile("ResourcesXML/Orders.xml", (outerOrders =>
        {
            try
            {
                foreach (var tempOrder in outerOrders)
                {
                    _dbContext?.Orders?.Add(tempOrder);
                }
                
                _dbContext?.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }));
    }

    //Сериализация списка заказов в определённый файл
    private static void SerializeOrdersToXmlString(string filePath,List<Order> orders)
    {
        var xmlSerializer = new XmlSerializer(typeof(List<Order>));

        using var writer = new FileStream(filePath, FileMode.Create);

        xmlSerializer.Serialize(writer, orders);
    }

    //Десериализация списка заказов из определённого файла
    private static void ReadObjectsFromFile(string filePath, Action<List<Order>> outputOrderMethod)
    {
        var xmlDeserializer = new XmlSerializer(typeof(List<Order>));
        
        try
        {
            using var reader = new FileStream(filePath, FileMode.OpenOrCreate);
            if (xmlDeserializer.Deserialize(reader) is List<Order> result)
            {
                outputOrderMethod(result);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}