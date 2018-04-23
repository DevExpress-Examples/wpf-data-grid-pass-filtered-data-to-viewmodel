using DevExpress.Xpf.Mvvm;
using ExpressionEvaluator_Filter.Model;
using System.Collections.ObjectModel;

namespace ExpressionEvaluator_Filter.ViewModel {
    class DataViewModel : ObservableObject {
        public DataViewModel(int length) {
            CreateData(length);
        }

        private void CreateData(int length) {
            Data = new ObservableCollection<DataModel>();
            VisibleData = new ObservableCollection<DataModel>();
            for(int i = 0; i < length; i++) {
                Data.Add(new DataModel { Text = "Row" + i, Number = i });
            }
            foreach(DataModel item in Data)
                VisibleData.Add(new DataModel { Text = item.Text, Number = item.Number });
        }

        private ObservableCollection<DataModel> _Data;
        private ObservableCollection<DataModel> _VisibleData;

        public ObservableCollection<DataModel> Data {
            get {
                return _Data;
            }
            set {
                _Data = value;
                OnPropertyChanged("Data");
            }
        }

        public ObservableCollection<DataModel> VisibleData {
            get {
                return _VisibleData;
            }
            set {
                _VisibleData = value;
                OnPropertyChanged("FilteredData");
            }
        }
    }
}
