using System;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Store.View;

public sealed partial class ImagePickPage : Page
{
    public ImagePickPage()
    {
        InitializeComponent();
    }

    private async void PickImageButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
        var filePicker = new FileOpenPicker()
        {
            SuggestedStartLocation = PickerLocationId.PicturesLibrary,
            ViewMode = PickerViewMode.Thumbnail
        };

        filePicker.FileTypeFilter.Add(".jpeg");
        filePicker.FileTypeFilter.Add(".jpg");
        filePicker.FileTypeFilter.Add(".");

        var file = await filePicker.PickSingleFileAsync();

        using var stream = await file.OpenReadAsync();

        var bitmap = new BitmapImage();
        await bitmap.SetSourceAsync(stream);

        UpdateLayout();

        Gallery.Items.Add(new Image()
        {
            Source = bitmap
        });
    }
}
