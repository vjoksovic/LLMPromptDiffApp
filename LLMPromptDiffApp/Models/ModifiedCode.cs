using System;
using System.ComponentModel;

namespace LLMPromptDiffApp.Models
{
    public class ModifiedCode : INotifyPropertyChanged
    {
        private string _originalCode = "";
        private string _currentCode = "";
        private string _codeDiff = "";

        public ModifiedCode(string originalCode)
        {
            _originalCode = originalCode;
            _currentCode = originalCode;
            _codeDiff = "";
        }

        public ModifiedCode() {}

        public string OriginalCode
        {
            get => _originalCode;
            set
            {
                if (_originalCode != value)
                {
                    _originalCode = value ?? throw new ArgumentNullException(nameof(value));
                    OnPropertyChanged(nameof(OriginalCode));
                }
            }
        }

        public string CurrentCode
        {
            get => _currentCode;
            set
            {
                if (_currentCode != value)
                {
                    _currentCode = value ?? throw new ArgumentNullException(nameof(value));
                    OnPropertyChanged(nameof(CurrentCode));
                }
            }
        }

        public string CodeDiff
        {
            get => _codeDiff;
            set
            {
                if (_codeDiff != value)
                {
                    _codeDiff = value ?? throw new ArgumentNullException(nameof(value));
                    OnPropertyChanged(nameof(CodeDiff));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}