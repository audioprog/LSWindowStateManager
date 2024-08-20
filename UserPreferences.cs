namespace LSWindowStateManager
{
    public class UserPreferences
    {
        #region Member Variables

        private double _windowTop;
        private double _windowLeft;
        private double _windowHeight;
        private double _windowWidth;
        private System.Windows.WindowState _windowState;
        private bool _isRemoteSesstion = false;
        private WindowStatesSettings _settings;

        #endregion //Member Variables

        #region Public Properties

        public double WindowTop
        {
            get { return _windowTop; }
            set { _windowTop = value; }
        }

        public double WindowLeft
        {
            get { return _windowLeft; }
            set { _windowLeft = value; }
        }

        public double WindowHeight
        {
            get { return _windowHeight; }
            set { _windowHeight = value; }
        }

        public double WindowWidth
        {
            get { return _windowWidth; }
            set { _windowWidth = value; }
        }

        public System.Windows.WindowState WindowState
        {
            get { return _windowState; }
            set { _windowState = value; }
        }

        public WindowStatesSettings Settings
        {
            get => _settings;
            private set => _settings = value;
        }

        #endregion //Public Properties

        #region Constructor

        public UserPreferences(bool isRemoteSession)
        {
            _isRemoteSesstion = isRemoteSession;

            //Load the settings
            Load();

            //Size it to fit the current screen
            SizeToFit();

            //Move the window at least partially into view
            MoveIntoView();
        }

        #endregion //Constructor

        #region Functions

        /// <summary>
        /// If the saved window dimensions are larger than the current screen shrink the
        /// window to fit.
        /// </summary>
        public void SizeToFit()
        {
            if (_windowHeight > System.Windows.SystemParameters.VirtualScreenHeight)
            {
                _windowHeight = System.Windows.SystemParameters.VirtualScreenHeight;
            }

            if (_windowWidth > System.Windows.SystemParameters.VirtualScreenWidth)
            {
                _windowWidth = System.Windows.SystemParameters.VirtualScreenWidth;
            }
        }

        /// <summary>
        /// If the window is more than half off of the screen move it up and to the left 
        /// so half the height and half the width are visible.
        /// </summary>
        public void MoveIntoView()
        {
            if (_windowTop + _windowHeight / 2 > System.Windows.SystemParameters.VirtualScreenHeight + System.Windows.SystemParameters.VirtualScreenTop)
            {
                _windowTop = System.Windows.SystemParameters.VirtualScreenHeight - _windowHeight + System.Windows.SystemParameters.VirtualScreenTop;
            }

            if (_windowLeft + _windowWidth / 2 > System.Windows.SystemParameters.VirtualScreenWidth + System.Windows.SystemParameters.VirtualScreenLeft)
            {
                _windowLeft = System.Windows.SystemParameters.VirtualScreenWidth - _windowWidth + System.Windows.SystemParameters.VirtualScreenLeft;
            }

            if (_windowTop < System.Windows.SystemParameters.VirtualScreenTop)
            {
                _windowTop = System.Windows.SystemParameters.VirtualScreenTop;
            }

            if (_windowLeft < System.Windows.SystemParameters.VirtualScreenLeft)
            {
                _windowLeft = System.Windows.SystemParameters.VirtualScreenLeft;
            }
        }

        private void Load()
        {
            if (_isRemoteSesstion)
            {
                _windowTop = Settings.RemoteWindowState.WindowTop;
                _windowLeft = Settings.RemoteWindowState.WindowLeft;
                _windowHeight = Settings.RemoteWindowState.WindowHeight;
                _windowWidth = Settings.RemoteWindowState.WindowWidth;
                _windowState = Settings.RemoteWindowState.WindowState;
            }
            else
            {
                _windowTop = Settings.LocalWindowState.WindowTop;
                _windowLeft = Settings.LocalWindowState.WindowLeft;
                _windowHeight = Settings.LocalWindowState.WindowHeight;
                _windowWidth = Settings.LocalWindowState.WindowWidth;
                _windowState = Settings.LocalWindowState.WindowState;
            }
        }

        public void Save()
        {
            if (_windowState != System.Windows.WindowState.Minimized)
            {
                if (_isRemoteSesstion)
                {
                    Settings.RemoteWindowState.WindowTop = _windowTop;
                    Settings.RemoteWindowState.WindowLeft = _windowLeft;
                    Settings.RemoteWindowState.WindowHeight = _windowHeight;
                    Settings.RemoteWindowState.WindowWidth = _windowWidth;
                    Settings.RemoteWindowState.WindowState = _windowState;
                }
                else
                {
                    Settings.LocalWindowState.WindowTop = _windowTop;
                    Settings.LocalWindowState.WindowLeft = _windowLeft;
                    Settings.LocalWindowState.WindowHeight = _windowHeight;
                    Settings.LocalWindowState.WindowWidth = _windowWidth;
                    Settings.LocalWindowState.WindowState = _windowState;
                }

                Settings.Save();
            }
        }

        #endregion //Functions

    }
}
