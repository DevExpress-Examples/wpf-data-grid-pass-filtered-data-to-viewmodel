using DevExpress.Mvvm;
using System.Collections.ObjectModel;

namespace ExpressionEvaluator_Filter {
    class DataViewModel : ViewModelBase {
        public DataViewModel() {
            CreateData(10);
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
