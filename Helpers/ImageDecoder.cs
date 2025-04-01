using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Store.Helpers;

public class ImageDecoder
{
    public string PathToImage { get; set; }
    
    public ImageDecoder() : this(string.Empty) { }

    public ImageDecoder(string pathToFile)
    {
        PathToImage = pathToFile;
    }
   
    public async Task<BitmapImage> DecodeImage() =>
        await DecodeImage(new StreamReader(File.OpenRead(PathToImage)));

    public async Task<BitmapImage> DecodeImage(string path) =>
        await DecodeImage(new StreamReader(File.OpenRead(path)));

    private async Task<BitmapImage> DecodeImage(StreamReader reader)
    {
        using (reader)
        {
            var bitmap = new BitmapImage();

            await bitmap.SetSourceAsync((IRandomAccessStream)reader);

            return bitmap;
        }
    }
}