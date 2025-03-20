using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 100)
        {
            throw new ArgumentException("Judul tidak boleh kosong dan maksimal 100 karakter.");
        }

        Random rand = new Random();
        this.id = rand.Next(10000, 99999); // Generate ID 5 digit
        this.title = title;
        this.playCount = 0;
    }

    
    public void IncreasePlayCount(int count)
    {
        if (count < 0)
        {
            throw new ArgumentException("Jumlah play count tidak boleh negatif.");
        }
        playCount += count;
    }

    
    public void PrintVideoDetails()
    {
        Console.WriteLine("ID Video      : " + id);
        Console.WriteLine("Judul Video   : " + title);
        Console.WriteLine("Jumlah Play   : " + playCount);
    }
}

class Program
{
    static void Main()
    {   
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – Alya Rabani");
        
        video.IncreasePlayCount(10);

        video.PrintVideoDetails();
    }
}
