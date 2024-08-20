namespace LSWindowStateManager
{
    [Serializable]
    public class WindowStateSettings : ObservableObject
    {
        private double _windowTop;

        public double WindowTop
        {
            get => _windowTop;
            set => Set(ref _windowTop, value);
        }


        private double _windowLeft;

        public double WindowLeft
        {
            get => _windowLeft;
            set => Set(ref _windowLeft, value);
        }


        private double _windowHeight;

        public double WindowHeight
        {
            get => _windowHeight;
            set => Set(ref _windowHeight, value);
        }


        private double _windowWidth;

        public double WindowWidth
        {
            get => _windowWidth;
            set => Set(ref _windowWidth, value);
        }


        private System.Windows.WindowState _windowState;

        public System.Windows.WindowState WindowState
        {
            get => _windowState;
            set => Set(ref _windowState, value);
        }
    }
}
