using RestPunk.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestPunk.ViewModels
{
    public class QueryBodyViewModel : ViewModelBase
    {
        private QueryLayoutViewModel parentViewModel;

        public List<string> Verbs { get; } = VerbType.VerbTypes.ToList();

        public SavedQuery Query { get; set; }

        public AuthSettingsViewModel AuthSettingsViewModel { get; private set; } = new AuthSettingsViewModel();

        private string queryBody;
        public string QueryBody { get => queryBody; 
            set 
            {
                if (!ReferenceEquals(queryBody, value))
                {
                    queryBody = value;
                    OnPropertyChanged();                    
                }
            } 
        }

        private QueryResponse queryResponse;
        public QueryResponse QueryResponse
        {
            get => queryResponse;
            set
            {
                if (!ReferenceEquals(queryResponse, value))
                {
                    queryResponse = value;
                    OnPropertyChanged();                    
                }
            }
        }

        

        public ICommand OnSendRequest { get; }
        public ICommand OnSaveCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
        

        public QueryBodyViewModel()
        {
            OnSendRequest = new PunkRelayCommand(SendRequest);
            OnSaveCommand = new PunkRelayCommand(UpdateQuery);
        }

        public QueryBodyViewModel(QueryLayoutViewModel parentVm) : this()
        {
            parentViewModel = parentVm;
            Query = new SavedQuery();
        }

        public QueryBodyViewModel(SavedQuery query, QueryLayoutViewModel parentVm) : this()
        {
            parentViewModel = parentVm;
            Query = query;
        }

        public void UpdateQuery(object? _)
        {
            parentViewModel.UpdateQuery(Query);
        }

        public async void SendRequest(object? _)
        {
            
            
            PunkHttpClient client = new PunkHttpClient();
            var response = await client.SendRequestAsync(Query);
            //if (queryBody == null) queryBody = new QueryBody();
            //var qb = QueryBody;
            //qb.Body = retVal;
            //QueryBody = qb;
            var qResponse = new QueryResponse();
            qResponse.ParseResponse(response);
            QueryResponse = qResponse;
            //return retVal;
        }

        

    }
}
