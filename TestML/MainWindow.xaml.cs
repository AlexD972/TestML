using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestML
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Btn_Charger_Img_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog() == true)
			{
				Uri fileUri = new Uri(openFileDialog.FileName);
				img.Source = new BitmapImage(fileUri);
			}
		}
		private void Btn_Classifier_Click(object sender, RoutedEventArgs e)
		{
			var input = new ModelInput();
			input.ImageSource = img.Source;

			ModelOutput result = ConsumeModel.Predict(input);

			MessageBox.Show("La classe du navire est : "+ result.Prediction);
		}
		
	}
}