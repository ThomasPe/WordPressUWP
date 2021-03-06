﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Data;
using WordPressPCL.Models;

namespace WordPressUWP.Helpers
{
    public class DisplayTermsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var terms = value as IEnumerable<IEnumerable<Term>>;
            var taxonomy = parameter as string;
            if (String.IsNullOrEmpty(taxonomy))
                taxonomy = "category";

            ObservableCollection<Term> outputList = new ObservableCollection<Term>();
            foreach (var list in terms)
            {
                var search = list.Where(x => x.Taxonomy.ToString() == taxonomy);
                foreach (var s in search)
                {
                    outputList.Add(s);
                }
            }

            string output = "";
            foreach (var term in outputList)
            {
                output += $"{term.Name}, ";
            }
            return output.Remove(output.Length - 2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
