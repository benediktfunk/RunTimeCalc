using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Caliburn.Micro;
using RTC.Storage;
using RTC.ViewModels;
using System.Linq;

namespace RTC.DataSource
{
    public class DS
    {
        private ObjectStorageHelper<List<ResultViewModel>> _objectStorageHelper;  

        public async Task<BindableCollection<ResultViewModel>> Initialize()
        {
            _objectStorageHelper = new ObjectStorageHelper<List<ResultViewModel>>(StorageType.Local);
            var storageList = await _objectStorageHelper.LoadAsync();
            
         
            var result = new BindableCollection<ResultViewModel>();
            foreach (var item in storageList)
                result.Add(item);
            return result;
        }
    }
}