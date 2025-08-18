using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using Wpf.Ui.Controls;

namespace Keycap.Windows
{
    public partial class KeystrokeWindow : FluentWindow
    {
        public ObservableCollection<string> Keys { get; } = [];

        public KeystrokeWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Keys.CollectionChanged += Keys_CollectionChanged;
            KeystrokeDispatcher.CapturedKeys = Keys;
        }

        private void Keys_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                Dispatcher.BeginInvoke(new Action(TrimKeysToFit));
        }

        private void TrimKeysToFit()
        {
            if (KeystrokeDisplay == null || Keys.Count == 0) return;

            KeystrokeDisplay.UpdateLayout();

            double maxWidth = KeystrokeDisplay.ActualWidth;
            double totalWidth = 0;

            foreach (var item in KeystrokeDisplay.Items)
            {
                var container = KeystrokeDisplay.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                if (container != null)
                {
                    container.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
                    totalWidth += container.DesiredSize.Width;
                }
            }

            while (totalWidth > maxWidth && Keys.Count > 0)
            {
                var firstContainer = KeystrokeDisplay.ItemContainerGenerator.ContainerFromItem(Keys[0]) as FrameworkElement;
                double firstWidth = firstContainer?.DesiredSize.Width ?? 0;

                Keys.RemoveAt(0);
                totalWidth -= firstWidth;
            }
        }

        private void FluentWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) this.DragMove();
        }
    }
}
