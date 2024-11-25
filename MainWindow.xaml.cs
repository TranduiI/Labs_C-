using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Laba14_B
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<XmlData> data;
        public ObservableCollection<XmlData> Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                OnPropertyChanged("Data");
            }
        }

        private XmlDocument doc = new XmlDocument();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private XmlNode selectedNode;
        private string filePath;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            btnSave.IsEnabled = false;
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == true)
            {
                btnSave.IsEnabled = true;
                filePath = file.FileName;
                doc.Load(filePath);
                CreateTreeView(treeView, doc);
            }
        }

        private void CreateTreeView(TreeView treeView, XmlDocument doc)
        {
            TreeViewItem treeRoot = new TreeViewItem
            {
                Header = doc.ChildNodes[0].LocalName,
                IsExpanded = true
            };
            treeRoot.Tag = doc.ChildNodes[0];
            treeView.Items.Add(treeRoot);
            BuildNode(treeRoot, doc.ChildNodes[0]);
        }

        private void TreeItem(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            if (item.IsSelected)
            {
                selectedNode = item.Tag as XmlNode;
                ObservableCollection<XmlData> newData = new ObservableCollection<XmlData>();
                if (selectedNode.Attributes.Count == 0)
                {
                    newData.Add(new XmlData { Country = selectedNode.Name, Capital = selectedNode.InnerText });
                }
                Data = newData;
            }
        }

        private void BuildNode(TreeViewItem treeNode, XmlNode element)
        {
            foreach (XmlNode node in element.ChildNodes)
            {
                switch (node.NodeType)
                {
                    case XmlNodeType.Element:
                        TreeViewItem childTreeView = new TreeViewItem
                        {
                            Header = node.LocalName,
                            IsExpanded = true
                        };
                        childTreeView.Tag = node;
                        childTreeView.Selected += TreeItem;
                        treeNode.Items.Add(childTreeView);
                        BuildNode(childTreeView, node);
                        break;
                }
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            doc.Save(filePath);
            MessageBox.Show($"Сохранить в {filePath}");
        }

        private void CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            selectedNode.InnerText = (e.EditingElement as TextBox).Text;
        }
    }
}
