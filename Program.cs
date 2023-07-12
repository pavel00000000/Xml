
using System;
using System.Xml;
using System.Xml.Serialization;

static void Serialize<T>(T obj, string  filePath)
{
    XmlSerializer serializer = new XmlSerializer(typeof(T));

    using (TextWriter writer = new StreamWriter(filePath))
    {
        serializer.Serialize(writer, obj);
    }

    Console.WriteLine("Cериализация  xml файла выполненена успешна: " + filePath);
}
static T Deserialize<T>(string filePath)
{
    XmlSerializer serializer = new XmlSerializer(typeof(T));
    Console.WriteLine(" Десиарилизация xml файла выполненена успешна: " + filePath);

    using (TextReader reader = new StreamReader(filePath))
    {
        return (T)serializer.Deserialize(reader);

    }

}

do
{
    Console.WriteLine("1. Сериализация");
    Console.WriteLine("2. Десериализация");
    Console.WriteLine("3. Выход");
    int number = Convert.ToInt32(Console.ReadLine());

    switch (number)
    {
        case 1:

            var product = new Product
            {
                Name = "огурец",
                Price = 30,
                Category = "овощ"
            };
            Serialize(product, "shop.xml");
            Console.WriteLine("Объект сериализован в XML.");
            break;
        case 2:
            var deserializedProduct = Deserialize<Product>("shop.xml");
            Console.WriteLine("Десериализованный объект:");
            Console.WriteLine("Название: " + deserializedProduct.Name);
            Console.WriteLine("Цена: " + deserializedProduct.Price);
            Console.WriteLine("Категория: " + deserializedProduct.Category);
            break;
        case 3:
            return;
        default:
            Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
            break;
    }

    Console.WriteLine();
} while (true);
    

public class Product
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string Category { get; set; }
}
