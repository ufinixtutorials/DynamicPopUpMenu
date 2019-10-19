using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;

namespace DynamicPopUp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RadioButton bestplacesRadio, bestmealsRadio;
        TextView optionsTextView;
        ImageView sortDownImageView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            bestplacesRadio = (RadioButton)FindViewById(Resource.Id.bestPlacesRadio);
            bestmealsRadio = (RadioButton)FindViewById(Resource.Id.bestMealsRadio);

            optionsTextView = (TextView)FindViewById(Resource.Id.optionTextView);
            sortDownImageView = (ImageView)FindViewById(Resource.Id.sortDownImageView);

            bestmealsRadio.Click += BestmealsRadio_Click;
            bestplacesRadio.Click += BestplacesRadio_Click;

            optionsTextView.Click += OptionsTextView_Click;
            sortDownImageView.Click += OptionsTextView_Click;
        }

        private void OptionsTextView_Click(object sender, System.EventArgs e)
        {
            PopupMenu popupMenu = new PopupMenu(this, optionsTextView);
            popupMenu.MenuItemClick += PopupMenu_MenuItemClick;
            if(bestmealsRadio.Checked == true)
            {
                popupMenu.Menu.Add(Menu.None, 1, 1, "Fried Rice");
                popupMenu.Menu.Add(Menu.None, 2, 2, "Grilled Chilli Meat");
                popupMenu.Menu.Add(Menu.None, 3, 3, "Egg Sauce");
                popupMenu.Show();
            }
            else if(bestplacesRadio.Checked == true)
            {
                popupMenu.Menu.Add(Menu.None, 1, 1, "Beverly Hills, USA");
                popupMenu.Menu.Add(Menu.None, 2, 2, "Java, Indonesia");
                popupMenu.Menu.Add(Menu.None, 3, 3, "Rio de jenairo, Brazil");
                popupMenu.Show();
            }
           
        }

        private void PopupMenu_MenuItemClick(object sender, PopupMenu.MenuItemClickEventArgs e)
        {
            optionsTextView.Text = e.Item.TitleFormatted.ToString();

            if (e.Item.TitleFormatted.ToString().Contains("Java"))
            {
                Toast.MakeText(this, e.Item.TitleFormatted.ToString(), ToastLength.Short).Show();
            }

        }

        private void BestplacesRadio_Click(object sender, System.EventArgs e)
        {
            bestmealsRadio.Checked = false;
        }

        private void BestmealsRadio_Click(object sender, System.EventArgs e)
        {
            bestplacesRadio.Checked = false;
        }
    }
}