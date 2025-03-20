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
        if (count < 0 || count > 10000000)
        {
            throw new ArgumentException("Jumlah play count harus antara 0 hingga 10.000.000.");
        }

        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Terjadi overflow! Tidak dapat menambahkan play count.");
        }
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

        // Uji validasi input normal
        video.IncreasePlayCount(100);
        video.PrintVideoDetails();

        // Uji batas maksimal play count
        video.IncreasePlayCount(10000000);  // Harus valid
        video.PrintVideoDetails();

        // Uji play count negatif (harus error)
        try
        {
            video.IncreasePlayCount(-5);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        // Uji overflow dengan loop
        try
        {
            for (int i = 0; i < 100; i++)
            {
                video.IncreasePlayCount(10000000); // Berulang kali menambah play count
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception tertangkap: " + e.Message);
        }
    }
}
