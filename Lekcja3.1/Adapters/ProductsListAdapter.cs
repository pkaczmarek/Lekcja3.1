using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Lekcja3._1.Model;

namespace Lekcja3._1.Adapters
{
    class ProductsListAdapter : BaseAdapter<Product>
    {
        private IList<Product> _productsList;
        private Activity _context;

        public ProductsListAdapter(Activity context, IList<Product> producList)
        {
            _context = context;
            _productsList = producList;
        }

        public override Product this[int position]
        {
            get
            {
                return _productsList[position];
            }
        }

        public override int Count
        {
            get
            {
               return _productsList.Count;
            
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ProductViewHolder holder;
            var product = _productsList[position];
            convertView = _context.LayoutInflater.Inflate(Resource.Layout.ProductRow, null);
            if (convertView.Tag == null)
            {
                holder = new ProductViewHolder(convertView.FindViewById<TextView>(Resource.Id.ProductNameTextView), convertView.FindViewById<ImageView>(Resource.Id.productImageView));
                convertView.Tag = holder;
            }
            else
            {
                holder = (ProductViewHolder)convertView.Tag;
            }

            holder.ProductNameTextView.Text = product.Name;
            int imageResourceId = _context.Resources.GetIdentifier(product.Image, "drawable,", _context.PackageName);
            holder.ProductPictureView.SetImageResource(imageResourceId);

            return convertView;
        }
    }
    public class ProductViewHolder: Java.Lang.Object
    {
        public TextView ProductNameTextView;
        public ImageView ProductPictureView;

        public ProductViewHolder(TextView productNameTextView,ImageView productPictureView)
        {
            ProductNameTextView = productNameTextView;
            ProductPictureView = productPictureView;
        }
    }
}