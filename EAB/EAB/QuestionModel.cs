using System.Windows.Input;
using Xamarin.Forms;

namespace EAB
{
    public class QuestionModel
    {
        public string Text { get; set; }
        public string Detail { get; set; }
        public string FileName { get; set; }
        public ICommand NavigationCommand { get; set; }
        public ICommand ImageCommand { get; set; }
        public ImageSource Thumbnail {
            get { return ImageSource.FromResource(string.Format("EAB.Images.{0}", FileName)); }
        }
       
        public ImageSource Arrow
        {
            get { return ImageSource.FromResource("EAB.Images.arrow.png"); }
        }

        public ImageSource CSU
        {
            get { return ImageSource.FromResource("EAB.Images.csu_extension.png"); }
        }

        public ImageSource CSFS
        {
            get { return ImageSource.FromResource("EAB.Images.csfs.png"); }
        }

    }
}
