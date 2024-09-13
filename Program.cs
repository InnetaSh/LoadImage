
using LoadImage;



string imageName = "Good dog";
string filePath = "E:\\STEP\\SQLlite\\dog.png";
string outputPath = "E:\\STEP\\SQLlite\\dogGetImg.png";



string imageName_2 = "pretty cat";
string filePath_2 = "E:\\STEP\\SQLlite\\cat.jpg";
string outputPath_2 = "E:\\STEP\\SQLlite\\catGetImg.png";


string imageName_3 = "happy cat";
string filePath_3 = "E:\\STEP\\SQLlite\\happy cat.jpg";
string outputPath_3 = "E:\\STEP\\SQLlite\\happy catGetImg.png";


AddImage(filePath, imageName);
GetImage(imageName, outputPath);


AddImage(filePath_2, imageName_2);
GetImage(imageName_2, outputPath_2);

AddImage(filePath_3, imageName_3);
GetImage(imageName_3, outputPath_3);

void AddImage(string filePath, string imageName)
{
    using (var db = new ApplicationContext())
    {
        byte[] image_bytes = File.ReadAllBytes(filePath);

        var image = new ImageRecord
        {
            Name = imageName,
            Data = image_bytes
        };

        db.ImageRecords.Add(image);
        db.SaveChanges();
        Console.WriteLine($"Изображение {imageName} загружено.");
    }
}




void GetImage(string imageName, string outputPath)
{
    using (var db = new ApplicationContext())
    {
        
        var image = db.ImageRecords
            .FirstOrDefault(img => img.Name == imageName);

        if (image != null)
        {
            if (image.Data != null)
            {
                if (!string.IsNullOrWhiteSpace(outputPath))
                {
                    File.WriteAllBytes(outputPath, image.Data);
                    Console.WriteLine($"Изображение {imageName} скачено.");
                }
                else 
                {
                    Console.WriteLine("некорректный путь");
                }
            }
            else
            {
                Console.WriteLine("данные об изображении отсутствуют.");
            }
        }
        else
        {
            Console.WriteLine("Изображение не найдено.");
        }
    }
}