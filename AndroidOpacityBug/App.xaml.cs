using System.Diagnostics;

namespace AndroidOpacityBug {
    public partial class App : Application {
        public App() {

            bool SET_TRUE_TO_SEE_ANDROID_BUG = true;

            //=============
            //BUG:
            //=============
            //in Windows whether you set the above bool to true or false you will see the red border, label, and cat with reduced opacity
            //in Android if you set the above bool to true everything gets clipped out by the absolutelayout's size setting and you see nothing

            ContentPage mainPage = new();
            this.MainPage = mainPage;

            AbsoluteLayout absDummy = new();
            mainPage.Content = absDummy;

            AbsoluteLayout absRoot = new();

            if (SET_TRUE_TO_SEE_ANDROID_BUG) {
                absRoot.WidthRequest = 1;
                absRoot.HeightRequest = 50;
            }
            
            absDummy.Add(absRoot);

            Border border = new();
            border.BackgroundColor = Colors.Red;
            border.WidthRequest = border.HeightRequest = 200;
            absRoot.Add(border);

            Label label = new();
            label.Text = "HELLO";
            absRoot.Add(label);

            Image image = new();
            image.Source = ImageSource.FromResource( "AndroidOpacityBug.Resources.Images.cat.jpg");
            image.WidthRequest = image.HeightRequest = 100;
            absRoot.Add(image);
            absRoot.Opacity = 0.4;

            //debugResources();
        }

        public static void debugResources() {
            foreach (string currentResource in System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames()) {
                Debug.WriteLine(currentResource);
            }
        }
    }
}
