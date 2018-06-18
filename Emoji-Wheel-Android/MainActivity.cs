using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Github.Hellocsl.Cursorwheel;
using System;
using System.Collections.Generic;
using Emoji_Wheel_Android.Adapter;
using Emoji_Wheel_Android.Data;
using static Github.Hellocsl.Cursorwheel.CursorWheelLayout;
using Android.Views;

namespace Emoji_Wheel_Android
{
    [Activity(Label = "Emoji_Wheel_Android", MainLauncher = true, Icon = "@mipmap/icon",Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity, IOnMenuSelectedListener
    {
        CursorWheelLayout wheel_image { get; set; }
        //CursorWheelLayout wheel_text;
        List<ImageData> FirstImage { get; set; }
        //List<MenuItemData> FirstText;
        ImageView eclipse { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            
            
            InitViews();
            LoadData();
            wheel_image.SetOnMenuSelectedListener(this);
            //wheel_text.SetOnMenuSelectedListener(this);
            
            wheel_image.SetBackgroundColor(Android.Graphics.Color.Transparent);
            //wheel_image.SetBackgroundResource(Resource.Drawable.wheel_bg);
            
        }

        private void LoadData()
        {
            eclipse.SetBackgroundResource(Resource.Drawable.eclipse_cover);

            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_happy, ImageDescription = "Happy" });
            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_peacefull, ImageDescription = "Peaceful" });
            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_content, ImageDescription = "Content" });
            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_okay, ImageDescription = "Okay" });
            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_sad, ImageDescription = "Sad" });
            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_bored, ImageDescription = "Bored" });
            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_worried, ImageDescription = "Worried" });
            FirstImage.Add(new ImageData() { ImageResource = Resource.Drawable.emoji_angry, ImageDescription = "Angry" });
            WheelImageAdapter imageAdapter = new WheelImageAdapter(BaseContext, FirstImage);
            wheel_image.SetAdapter(imageAdapter);

            //Number Wheel Start
            //FirstText = new List<MenuItemData>();
            //for (int i = 0; i < 9; i++)
            //    FirstText.Add(new MenuItemData() { mTitle = Convert.ToString(i) });
            //FirstText.Add(new MenuItemData() { mTitle = "OFF" });
            //WheelTextAdapter textAdapter = new WheelTextAdapter(BaseContext, FirstText);
            //wheel_text.SetAdapter(textAdapter);
            //Number Wheel End
        }

        private void InitViews()
        {
            wheel_image = FindViewById<CursorWheelLayout>(Resource.Id.wheel_image);
            FirstImage = new List<ImageData>();
            eclipse = FindViewById<ImageView>(Resource.Id.WheelContainer);
            //wheel_text = FindViewById<CursorWheelLayout>(Resource.Id.wheel_text);
        }

        public void OnItemSelected(CursorWheelLayout wheel, View view, int position)
        {
            //if (wheel.Id == Resource.Id.wheel_text)
            //{
            //    Toast.MakeText(BaseContext, "Selected: " + FirstText[position].mTitle, ToastLength.Short).Show();
            //}
            //else 
            if (wheel.Id == Resource.Id.wheel_image)
            {
                Toast.MakeText(BaseContext, "Selected: " + FirstImage[position].ImageDescription, ToastLength.Short).Show();
            }
        }
    }
}

