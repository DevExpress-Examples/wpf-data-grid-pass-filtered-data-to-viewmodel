using DevExpress.Mvvm;
using ExpressionEvaluator_Filter.Model;
using System.Collections.ObjectModel;

namespace ExpressionEvaluator_Filter.ViewModel {
    class DataViewModel : ViewModelBase {
        public DataViewModel(int length) {
            CreateData(length);
        }

        private void CreateData(int length) {
            Data = new ObservableCollection<DataModel>();
            for(int i = 0; i < length; i++) {
                Data.Add(new DataModel { Text = "Row" + i, Number = i });
            }
        }

        public ObservableCollection<DataModel> Data {
            get { return GetProperty(() => Data); }
            set { SetProperty(() => Data, value); }
        }

        public ObservableCollection<object> VisibleData {
            get { return GetProperty(() => VisibleData); }
            set { SetProperty(() => VisibleData, value); }
        }
    }
}
