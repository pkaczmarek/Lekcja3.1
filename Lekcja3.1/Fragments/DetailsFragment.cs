using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Lekcja3._1.Model;

namespace Lekcja3._1.Fragments
{
    public class DetailsFragment : Fragment
    {
        public Product SelectedProduct { get; set; }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var mainView = inflater.Inflate(Resource.Layout.DetailsFragment, container, false);
            var productImageView = mainView.FindViewById<ImageView>(Resource.Id.ProductPictureImageView);
            var productNameTextView = mainView.FindViewById<TextView>(Resource.Id.ProductNameTextView);
            productNameTextView.Text = SelectedProduct.Name;
            int imageResoureId = Activity.Resources.GetIdentifier(SelectedProduct.Image, "drawable", Activity.PackageName);
            productImageView.SetImageResource(imageResoureId);

            return mainView;
        }
    }
}