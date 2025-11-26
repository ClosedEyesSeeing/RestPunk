using CommunityToolkit.Mvvm.ComponentModel;
using RestPunk.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk.Models
{
    public class SavedQuery : ObservableObject, ITreeItem
    {
        private Guid _id = Guid.NewGuid();
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _name = "New Query";
        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
                OnPropertyChanged("DisplayName");
            }
        }

        private string _uri;
        public string Uri
        {
            get => _uri;
            set => SetProperty(ref _uri, value);
        }

        private string _httpVerb = VerbType.Get;
        public string HttpVerb
        {
            get => _httpVerb;
            set
            {
                SetProperty(ref _httpVerb, value);
                OnPropertyChanged("DisplayName");
            }
        }

        private AuthorizationOption _authorizationOption;
        public AuthorizationOption AuthorizationOption
        {
            get => _authorizationOption;
            set => SetProperty(ref _authorizationOption, value);
        }

        private QueryParams _params;
        public QueryParams Params
        {
            get => _params;
            set => SetProperty(ref _params, value);
        }

        private QueryHeaders _headers;
        public QueryHeaders Headers
        {
            get => _headers;
            set => SetProperty(ref _headers, value);
        }

        private QueryBody _body;
        public QueryBody Body
        {
            get => _body;
            set => SetProperty(ref _body, value);
        }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set => SetProperty(ref _isExpanded, value);
        }

        public string DisplayName
        {
            get => this.ToString();
        }

        public SavedQuery()
        {
            HttpVerb = VerbType.Get;
        }

        public override string ToString() => $"[{HttpVerb}] {Name}";

        public void Copy(SavedQuery query)
        {
            Id = query.Id;
            Name = query.Name;
            Uri = query.Uri;
            HttpVerb = query.HttpVerb;
            AuthorizationOption = query.AuthorizationOption;
            Params = query.Params;
            Headers = query.Headers;
            Body = query.Body;
        }
    }

}
