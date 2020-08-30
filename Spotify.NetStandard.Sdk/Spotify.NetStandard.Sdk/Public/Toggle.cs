using System.Windows.Input;

namespace Spotify.NetStandard.Sdk
{
    /// <summary>
    /// Toggle
    /// </summary>
    public class Toggle : BaseNotifyPropertyChanged
    {
        #region Private Members
        private ToggleType _toggleType;
        private byte _itemType; 
        private string _id;
        private bool _value;
        #endregion Private Members

        #region Public Properties
        /// <summary>
        /// Toggle Type
        /// </summary>
        public ToggleType ToggleType
        {
            get => _toggleType;
            set { _toggleType = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Item Type
        /// </summary>
        public byte ItemType
        {
            get => _itemType;
            set { _itemType = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Id
        /// </summary>
        public string Id
        {
            get => _id;
            set { _id = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Value
        /// </summary>
        public bool Value
        {
            get => _value;
            set { _value = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Command
        /// </summary>
        public ICommand Command { get; set; }
        #endregion Public Properties
    }
}
