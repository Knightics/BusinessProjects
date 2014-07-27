using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Marshmallow
{
    /// <summary>
    /// Interaction logic for TestTree.xaml
    /// </summary>
    public partial class TestTree : Window
    {
        public TestTree()
        {
            InitializeComponent();
            ShowTreeView();
        }

        private void TreeViewItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var treeViewItem = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            if (treeViewItem != null)
            {
                treeViewItem.Focus();
                e.Handled = true;
            }
        }

        static DependencyObject VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(T))
                source = VisualTreeHelper.GetParent(source);

            return source;
        }

        private void ShowTreeView()
        {
            List<PropertyNodeItem> itemList = new List<PropertyNodeItem>();
            PropertyNodeItem node1 = new PropertyNodeItem()
            {
                DisplayName = "Node No.1",
                Name = "This is the discription of Node1. This is a folder.",
                Icon = Constants.CAR_GROUP_ICON,
            };

            PropertyNodeItem node1tag1 = new PropertyNodeItem()
            {
                DisplayName = "Tag No.1",
                Name = "This is the discription of Tag 1. This is a tag.",
                EditIcon = Constants.TRUCK_ICON
            };
            node1.Children.Add(node1tag1);

            PropertyNodeItem node1tag2 = new PropertyNodeItem()
            {
                DisplayName = "Tag No.2",
                Name = "This is the discription of Tag 2. This is a tag.",
                EditIcon = Constants.TRUCK_ICON
            };
            node1.Children.Add(node1tag2);
            itemList.Add(node1);

            PropertyNodeItem node2 = new PropertyNodeItem()
            {
                DisplayName = "Node No.2",
                Name = "This is the discription of Node 2. This is a folder.",
                Icon = Constants.CAR_GROUP_ICON,
            };

            PropertyNodeItem node2tag3 = new PropertyNodeItem()
            {
                DisplayName = "Tag No.3",
                Name = "This is the discription of Tag 3. This is a tag.",
                EditIcon = Constants.TRUCK_ICON
            };
            node2.Children.Add(node2tag3);

            PropertyNodeItem node2tag4 = new PropertyNodeItem()
            {
                DisplayName = "Tag No.4",
                Name = "This is the discription of Tag 4. This is a tag.",
                EditIcon = Constants.TRUCK_ICON
            };
            node2.Children.Add(node2tag4);
            itemList.Add(node2);

            this.tvProperties.ItemsSource = itemList;
        }
    }
}
